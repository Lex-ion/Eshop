using Eshop.Attributes;
using Eshop.Database;
using Eshop.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public class AdminController : BaseController
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
/*
 Tyhle technologie jsou tak zbytečně moc reflexivní, tak proč to neudělat ještě víc zbytečně reflexivní. Proč něco někam přidávat ručně, když na to můžu mít reflexivní atribut, který ani nemusí fungovat. A to jen protože se mi jmenují dvě věci trochu jinak.
 
 */
