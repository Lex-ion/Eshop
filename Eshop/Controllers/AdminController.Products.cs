using Eshop.Entities;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public partial class AdminController
	{
		public IActionResult AddProduct()
		{
			ProductFormModel model = new();
			model.Manufacturers = _context.Manufacturers.ToList();
			return View(model);
		}
		[HttpPost]
		public IActionResult AddProduct(ProductFormModel model)
		{

			model.Manufacturers = _context.Manufacturers.ToList();
			ModelState.MarkFieldValid("Manufacturers");
			bool a = ModelState.IsValid;

			return View(model);
		}

		public IActionResult EditProduct(int id) 
		{
			Product p = _context.Products.Find(id);
			ProductFormModel model = new ProductFormModel(id,p.Name,p.Description,p.Price,p.Discount,p.AvailableCount,p.Manufacturer.Id,_context.Manufacturers.ToList());

			return View(model);
		}
		public IActionResult DeleteProduct(int id) { return View(); }
	}
}
