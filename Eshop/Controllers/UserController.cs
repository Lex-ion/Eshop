using Eshop.Database;
using Eshop.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public class UserController : BaseController
	{
		public UserController(DatabaseContext context) : base(context)
		{
		}

		public IActionResult Index()
		{var ui = UserInfoExtractorHelper.GetUserInfo(_context, HttpContext); ;
			ViewBag.UserInfo = ui;
			ViewBag.Orders = _context.Orders.Where(o=>o.AccountId == ui.Id).ToList();
			ViewBag.Account = _context.Accounts.Find(HttpContext.Session.GetInt32("UID"));
			return View();
		}
	}
}
