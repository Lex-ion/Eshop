using Eshop.Attributes;
using Eshop.Database;
using Eshop.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public partial class AdminController : BaseController
	{
		public AdminController(DatabaseContext context) : base(context)
		{
		}

		public IActionResult Index()
		{
			var aliases = AliasHelper.GetMethodAliases<AdminController>();

			return View(aliases);
		}

		[Alias("Produkty")]
		[ServiceFilter(typeof(ImportEntitiesAttribute))]
		public IActionResult Products()
		{


			return View();
		}


		[Alias("Kategorie")]
		[ServiceFilter(typeof(ImportEntitiesAttribute))]
		public IActionResult Categories()
		{


			return View();
		}


		[Alias("Výrobci")]
		[ServiceFilter(typeof(ImportEntitiesAttribute))]
		public IActionResult Manufacturers()
		{


			return View();
		}


	}
}
