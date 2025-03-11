using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public partial class AdminController
	{
		public IActionResult AddProduct()
		{
			return View();
		}
		public IActionResult EditProduct(int id) { return View(); }
		public IActionResult DeleteProduct(int id) { return View(); }
	}
}
