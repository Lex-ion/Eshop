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
			var cart=CartHelper.GetCart(HttpContext, _context);

			return View(cart);
		}
	}
}
