using Eshop.Database;
using Eshop.Helpers;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public class UserController : SecuredController
	{
		public UserController(DatabaseContext context) : base(context,false)
		{
		}

		public IActionResult Index()
		{
			var ui = UserInfoExtractorHelper.GetUserInfo(_context, HttpContext); ;
			ViewBag.UserInfo = ui;
			ViewBag.Orders = _context.Orders.Where(o => o.AccountId == ui.Id).ToList();
			ViewBag.Account = _context.Accounts.Find(HttpContext.Session.GetInt32("UID"));
			return View();
		}

		public IActionResult OrderDetail(int id)
		{

			var ui = UserInfoExtractorHelper.GetUserInfo(_context, HttpContext);
			var order = _context.Orders.Find(id);

			if (order is null)
				return RedirectToAction("Index");

			if (order.AccountId != ui.Id)
				return RedirectToAction("Index");

			List<OrderItemModel> model = order.OrderItems.Select(i => new OrderItemModel(i.Product, i.ProductCount, i.ProductCount)).ToList();
			return View(model);
		}

	}
}
