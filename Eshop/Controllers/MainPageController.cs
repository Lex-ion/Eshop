using Eshop.Database;
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
	}
}
