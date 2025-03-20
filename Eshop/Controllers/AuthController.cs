using Eshop.Database;
using Eshop.Entities;
using Eshop.Helpers;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public class AuthController(DatabaseContext context) : Controller
	{
		private readonly DatabaseContext _context = context;

		public IActionResult Login()
		{

			if(UserInfoExtractorHelper.GetUserInfo(_context,HttpContext).IsAuthenticated)
			return RedirectToAction("Index", "Mainpage");
			return View();
		}
		[HttpPost]
		public IActionResult Login(LoginModel model)
		{
			Account? acc = _context.Accounts.SingleOrDefault(a => a.Mail == model.Mail);
			string pswd = SHA256Helper.HashPassword(model.Password);
			if (acc is null || pswd != acc.Password)
				return View();

            HttpContext.Session.SetInt32("UID", acc.Id);
            HttpContext.Session.SetInt32("RID", acc.AccountTypeId);

			acc.LastLogin = DateTime.Now;
			_context.Accounts.Update(acc);
			_context.SaveChanges();

            return RedirectToAction("Index", "Mainpage");
		}
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(RegistrationModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			string pswd = SHA256Helper.HashPassword(model.Password);
			Account account = new(0, 2, null!, model.Name, model.Lastname, model.Adress, model.Email, pswd, DateTime.Now, DateTime.Now, null!);
			_context.Accounts.Add(account);
			_context.SaveChanges();
			var acc = _context.Accounts.Single(a=>a.Mail == account.Mail);

            HttpContext.Session.SetInt32("UID", acc.Id);
            HttpContext.Session.SetInt32("RID", acc.AccountTypeId);


            return RedirectToAction("Index", "MainPage");
		}

		public IActionResult Logout()
		{

            HttpContext.Session.Remove("UID");
            HttpContext.Session.Remove("RID");
            return RedirectToAction("Index", "MainPage");
        }
    }
}
