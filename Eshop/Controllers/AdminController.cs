﻿using Eshop.Attributes;
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
			return RedirectToAction("Products");
			var aliases = AliasHelper.GetMethodAliases<AdminController>();

			return View(aliases);
		}


		//------------------------ADMIN PAGE HEADERS------------------------\\
		//---SPECIFY HEADERS IN THE ORDER IN WHICH THEY WILL BE DISPLAYED---\\


		[Alias("Produkty")]
		[ServiceFilter(typeof(ImportEntitiesAttribute))]
		public IActionResult Products()
		{


			return View("EntitiesList");
		}

		
		[Alias("Kategorie")]
		[ServiceFilter(typeof(ImportEntitiesAttribute))]
		public IActionResult Categories()
		{



			return View("EntitiesList");
		}


		[Alias("Výrobci")]
		[ServiceFilter(typeof(ImportEntitiesAttribute))]
		public IActionResult Manufacturers()
		{


			return View("EntitiesList");
		}


		[Alias("Objednávky")]
		[ServiceFilter(typeof(ImportEntitiesAttribute))]
		public IActionResult Orders()
		{


			return View("EntitiesList");
		}
	}
}
