using Eshop.Database;
using Eshop.Entities;
using Eshop.Helpers;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public class CartController : BaseController


	{
		public CartController(DatabaseContext context) : base(context)
		{
		}

		public IActionResult Index()
		{
			var cart = CartHelper.GetCart(HttpContext, _context);

			return View(cart);
		}

		public IActionResult UpdateQuantity(int productId, int count)
		{
			var prod = _context.Products.Find(productId);
			if (prod.AvailableCount < 1)
			{
				CartHelper.RemoveFromCart(HttpContext, productId);
			}
			else
			{

				count = Math.Clamp(count, 1, prod.AvailableCount!.Value);

				CartHelper.UpdateInCart(HttpContext, productId, count);
			}
			return RedirectToAction("Index");
		}

		public IActionResult RemoveFromCart(int productId)
		{
			CartHelper.RemoveFromCart(HttpContext, productId);
			return RedirectToAction("Index");
		}

		public IActionResult Checkout()
		{
			CheckoutModel model = new();
			UserInfo userInfo = UserInfoExtractorHelper.GetUserInfo(_context, HttpContext);
			if(userInfo.IsAuthenticated )
			{
				var user = _context.Accounts.Find(userInfo.Id);

				model.Adress = user.Adress;
				model.Name = user.Name;
				model.Lastname = user.Lastname;
				model.Mail = user.Mail;
			
			}
			ViewBag.PMethods = _context.PaymentMethods.ToList();
			ViewBag.DMethods = _context.DeliveryMethods.ToList();
			Console.WriteLine("Count of delivery methods: "+ViewBag.DMethods.Count);
			return View(model);
		}

		[HttpPost]
		public IActionResult Checkout(CheckoutModel model)
		{
			if (!ModelState.IsValid)
			{

				ViewBag.PMethods = _context.PaymentMethods.ToList();
				ViewBag.DMethods = _context.DeliveryMethods.ToList();
				return View(model);
			}

			UserInfo userInfo = UserInfoExtractorHelper.GetUserInfo(_context, HttpContext);

			Order order = new();
			order.OrderStateId = 1;
			order.Adress = model.Adress;
			order.PaymentMethodId = model.PaymentType;
			order.DeliveryMethodId = model.DeliveryType;
			order.IsDelivered = false;
			order.Lastname = model.Lastname;
			order.Mail = model.Mail;
			order.Name = model.Name;
			order.OrderDate = DateTime.Now;

			if (userInfo.IsAuthenticated)
				order.AccountId = userInfo.Id;

			var cartItems = CartHelper.GetCart(HttpContext, _context).Select(i => new OrderItem(0, order, i.ProductId, null!, i.Count)).ToList() ;

			order.OrderItems = cartItems;

			_context.Orders.Add(order);
			foreach (var item in cartItems)
			{
				_context.OrderItems.Add(item);
			}

			_context.SaveChanges();

			if (userInfo.IsAuthenticated)
				return RedirectToAction("Index","User");
			return RedirectToAction("Index", "MainPage");
		}
	}
}
