using Eshop.Database;
using Eshop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public class MainPageController : Controller
	{
		DatabaseContext _context;

		public MainPageController(DatabaseContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View(_context.Products.ToList()) ;
		}

		public IActionResult AddToCart(int id)
		{
			Product? prod = _context.Products.Single(p=> p.Id ==id);
			if(prod is not null)
			{
				TempData["Message"] = $"Do košíku přidáno: {prod.Name}";
				TempData["MessageType"] = "success";
			}
			else
			{
				TempData["Message"] = $"Něco se pokazilo";
				TempData["MessageType"] = "danger";
			}

			return RedirectToAction("Index");
		}
	}
}
