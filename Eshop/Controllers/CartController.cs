using Eshop.Database;
using Eshop.Helpers;
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
			return View();
		}

	}
}
