using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public class AuthController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(LoginModel model)
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
	}
}
