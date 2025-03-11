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
			
			if(!ModelState.IsValid||model.ManufacturerID <=0 )
			return View(model);

			Product p = new(0, model.Name, model.Description, model.Price, model.Discount, model.AvailableCount, model.ManufacturerID, null, null, null);
			_context.Products.Add(p);
			_context.SaveChanges();
		
			return RedirectToAction("EditProduct", new {p.Id});
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
