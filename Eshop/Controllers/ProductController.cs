using Eshop.Database;
using Eshop.Models;
using Eshop.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Eshop.Helpers;

namespace Eshop.Controllers
{
	public class ProductController : Controller
	{
		DatabaseContext _context;
		IWebHostEnvironment _environment;

		public ProductController(DatabaseContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}

		public IActionResult ProductDetail(int id)
		{
			var cart = CartHelper.GetCart(HttpContext,_context);

			var thisCartItem = cart.SingleOrDefault(ci => ci.ProductId == id);

			ViewBag.InCartCount = thisCartItem?.Count ?? 0;

			ViewBag.RootPath = _environment.WebRootPath;
			Product prod = _context.Products.Single(p => p.Id == id);
			OrderItemModel oi = new(prod,1);
			return View(oi);
		}

		public IActionResult AddToCart(OrderItemModel model)
		{
			CartHelper.AddToCart(HttpContext, model);

			int id = model.ProductId;
			return RedirectToAction("ProductDetail", new { id = id }); //💀
		}
		public IActionResult AddToCartSingle(int id)
		{
			Product prod = _context.Products.Single(p => p.Id == id);
			OrderItemModel oi = new(prod, 1);
			return AddToCart(oi);
		}
	}
}
