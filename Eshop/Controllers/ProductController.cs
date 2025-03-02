using Eshop.Database;
using Microsoft.AspNetCore.Mvc;

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
			return View(_context.Products.Single(p => p.Id == id));
		}

		public IActionResult AddToCart(int id)
		{

			return RedirectToAction("ProductDetail", id);
		}
	}
}
