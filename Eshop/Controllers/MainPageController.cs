﻿using Eshop.Database;
using Eshop.Entities;
using Eshop.Helpers;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Controllers
{
	public class MainPageController(DatabaseContext context) : BaseController(context)
	{
		public IActionResult Index(string? SearchString)
		{
			List<Product> products = [.. _context.Products];

			if(!string.IsNullOrWhiteSpace(SearchString))
				products = Search(SearchString, [.. _context.Products]);

			MainPageModel model = new(products, SearchString);
			
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

		public List<Product> Search(string? searchString,List<Product> prods)
		{
			if (string.IsNullOrWhiteSpace(searchString))
				return prods;


			Dictionary<Product, int> searchItems = [];
			string[] searchParams = searchString.ToLower().Split(' ');
			//StringComparison c = StringComparison.OrdinalIgnoreCase;


			foreach (string param in searchParams)
			{
				foreach (var item in prods.Where(p => p.Name.ToLower().Contains(param)))
				{
					if (searchItems.TryGetValue(item, out int value))
						searchItems[item] = ++value;
					else
						searchItems[item] = 1;
				}
				foreach (var item in prods.Where(p => p.Description?.ToLower().Contains(param)??false))
				{
					if (searchItems.TryGetValue(item, out int value))
						searchItems[item] = ++value;
					else
						searchItems[item] = 1;
				}


				foreach (var item in prods.Where(p => p.Manufacturer.Name.ToLower().Contains(param)))
				{
					if (searchItems.TryGetValue(item, out int value))
						searchItems[item] = ++value;
					else
						searchItems[item] = 1;
				}

				foreach (var prod in prods)
				{
					foreach (var prodCats in prod.ProductCategories.Where(p => p.Category.Name.ToLower().Contains(param)))
					{
						if (searchItems.TryGetValue(prod, out int value))
							searchItems[prod] = ++value;
						else
							searchItems[prod] = 1;
					}
				}
				foreach (var prod in prods)
				{
					foreach (var prodCats in prod.ProductCategories.Where(p => p.Category.Description?.ToLower().Contains(param) ?? false))
					{
						if (searchItems.TryGetValue(prod, out int value))
							searchItems[prod] = ++value;
						else
							searchItems[prod] = 1;
					}
				}
			}

			List<Product> sorted = searchItems.OrderByDescending(entry => entry.Value).Select(entry => entry.Key).ToList();


			return sorted;

		}

		public IActionResult AdvancedSearch(ProductSearchModel? model)
		{
			model ??= new ProductSearchModel();

			var filter = model.Filter;
			model.Categories= [.. _context.Categories];
			model.Manufacturers = [.. _context.Manufacturers];
			var semiFiltered = _context.Products.ToList()
				.Where(
				p =>
				filter.SelectedManufacturers.Count > 0 ? filter.SelectedManufacturers.Contains(p.ManufacturerID) : false ||
				filter.SelectedCategories.Count <= 0 || filter.SelectedCategories.All(c => p.ProductCategories.Select(pc => pc.CategoryId).Contains(c))
				).
				ToList();
			model.Products= Search(filter.SearchQuery, semiFiltered);

			switch (filter.PriceSort)
			{
				case SortByPrice.None:
					break;
				case SortByPrice.Ascending:
					model.Products = [.. model.Products.OrderBy(p => p.Price - (p.Discount ?? 0))];
					break;
				case SortByPrice.Descending:
					model.Products = [.. model.Products.OrderByDescending(p => p.Price - (p.Discount ?? 0))];
					break;
				default:
					break;
			}

			return View(model);
		}
		
		
	}
}