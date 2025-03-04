using Eshop.Database;
using Eshop.Models;
using Eshop.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
			ViewBag.RootPath = _environment.WebRootPath;
			Product prod = _context.Products.Single(p => p.Id == id);
			OrderItemModel oi = new(prod,1);
			return View(oi);
		}

		public IActionResult AddToCart(OrderItemModel model)
		{
			Dictionary<int,int> cart;
			string? cartJson = HttpContext.Session.GetString("CartJSON");
			if (cartJson is null)
				cart = new();
			else cart = JsonSerializer.Deserialize<Dictionary<int, int>>(cartJson);

			if( !cart.TryAdd(model.ProductId, model.Count))
			{
				cart[model.ProductId] += model.Count;
			}

			HttpContext.Session.SetString("CartJSON", JsonSerializer.Serialize(cart));

			int id = model.ProductId;
			return RedirectToAction("ProductDetail", new { id = id }); //💀
		}
	}
}
