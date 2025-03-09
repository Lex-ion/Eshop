using Eshop.Database;
using Eshop.Entities;
using Eshop.Helpers;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Controllers
{
	public class MainPageController : BaseController
	{
		public MainPageController(DatabaseContext context) : base(context)
		{
		}

		public IActionResult Index(MainPageModel? model = null)
		{
			if (model!.Products == null)
				model = new MainPageModel(_context.Products.ToList(), null);
			return View(model);
		}


		public IActionResult AddToCart(int id)
		{
			Product? prod = _context.Products.Single(p => p.Id == id);
			if (prod is not null)
			{
				TempData["Message"] = $"Do košíku přidáno: {prod.Name}";
				TempData["MessageType"] = "success";
			}
			else
			{
				TempData["Message"] = $"Něco se pokazilo";
				TempData["MessageType"] = "danger";
			}

			return RedirectToAction("Index");
		}

		public IActionResult Search(MainPageModel model)
		{
			if (string.IsNullOrEmpty(model.SearchString))
				return RedirectToAction("Index");

			Dictionary<Product, int> searchItems = new Dictionary<Product, int>();
			string[] searchParams = model.SearchString.ToLower().Split(' ');
			StringComparison c = StringComparison.OrdinalIgnoreCase;

			var prods = _context.Products.ToList();

			foreach (string param in searchParams)
			{
				foreach (var item in prods.Where(p => p.Name.ToLower().Contains(param)))
				{
					if (searchItems.ContainsKey(item))
						searchItems[item]++;
					else
						searchItems[item] = 1;
				}
				foreach (var item in prods.Where(p => p.Description.ToLower().Contains(param)))
				{
					if (searchItems.ContainsKey(item))
						searchItems[item]++;
					else
						searchItems[item] = 1;
				}
				
				foreach (var prod in prods)
				{
					foreach (var prodCats in prod.ProductCategories.Where(p => p.Category.Name.ToLower().Contains(param)))
					{
						if (searchItems.ContainsKey(prod))
							searchItems[prod]++;
						else
							searchItems[prod] = 1;
					}
				}
				foreach (var prod in prods)
				{
					foreach (var prodCats in prod.ProductCategories.Where(p => p.Category.Description?.ToLower().Contains(param) ?? false))
					{
						if (searchItems.ContainsKey(prod))
							searchItems[prod]++;
						else
							searchItems[prod] = 1;
					}
				}
			}

			List<Product> sorted = searchItems.OrderByDescending(entry => entry.Value).Select(entry => entry.Key).ToList();
			model.Products = sorted;

			return View("Index", model);

		}
	}
}