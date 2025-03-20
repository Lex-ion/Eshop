using Eshop.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Controllers
{
	public class CategoryController(DatabaseContext context) : BaseController(context)
	{
		public IActionResult Index(int id)
		{
			return View(_context.Categories.Find( id));
		}
	}
}
