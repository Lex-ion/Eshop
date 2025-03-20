using Eshop.Database;
using Eshop.Models;
using Eshop.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Eshop.Helpers;

namespace Eshop.Controllers
{
	public class ProductController(DatabaseContext context, IWebHostEnvironment environment) : BaseController(context)
	{
		private readonly IWebHostEnvironment _environment = environment;

		public IActionResult ProductDetail(int id)
		{
			var cart = CartHelper.GetCart(HttpContext,_context);

			var thisCartItem = cart.SingleOrDefault(ci => ci.ProductId == id);

			ViewBag.InCartCount = thisCartItem?.Count ?? 0;

			ViewBag.RootPath = _environment.WebRootPath;
			Product prod = _context.Products.Single(p => p.Id == id);
			OrderItemModel oi = new(prod,1,prod.AvailableCount??0);
			return View(oi);
		}

		public IActionResult AddToCart(OrderItemModel model)
		{
			CartHelper.AddToCart(HttpContext, model);

			int id = model.ProductId;
			return RedirectToAction("ProductDetail", new { id }); //💀
		}
		public IActionResult AddToCartSingle(int id)
		{
			Product prod = _context.Products.Single(p => p.Id == id);
			OrderItemModel oi = new(prod, 1,prod.AvailableCount??0);
			return AddToCart(oi);
		}



		public IActionResult Review(int id)
		{

			ViewBag.RootPath = _environment.WebRootPath;
			Product prod = _context.Products.Single(p => p.Id == id);
			ViewBag.Product = prod;
			ReviewModel model = new()
			{
				ProductId = id
			};
			return View(model);
		}
		[HttpPost]
		public IActionResult Review(ReviewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			Review r = new()
			{
				Id = 0,
				Description = model.ReviewText,
				Rating = model.Rating,
				IsDeleted = false,
				ProductId = model.ProductId,
				AccountID = null
			};
			if (!model.Anonymous)
			{
				r.AccountID = UserInfoExtractorHelper.GetUserInfo(_context, HttpContext).Id;
			}

			_context.Reviews.Add(r);
			_context.SaveChanges();

			return RedirectToAction("ProductDetail", new {id =model.ProductId});
		}


	}
}
