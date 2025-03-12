using Eshop.Entities;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Controllers
{
	public partial class AdminController
	{
		[Route("Admin/AddProducts")]
		public IActionResult AddProduct()
		{
			ProductFormModel model = new();
			model.Manufacturers = _context.Manufacturers.ToList();
			return View(model);
		}
		[HttpPost]
		[Route("Admin/AddProducts")]
		public IActionResult AddProduct(ProductFormModel model)
		{

			model.Manufacturers = _context.Manufacturers.ToList();
			ModelState.MarkFieldValid("Manufacturers");
			
			if(!ModelState.IsValid||model.ManufacturerID <=0)
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Nebylo možné vytvořit produkt...";
				return View(model);
			}

			Product p = new(0, model.Name, model.Description, model.Price, model.Discount, model.AvailableCount, model.ManufacturerID, null, null, null);
			_context.Products.Add(p);
			_context.SaveChanges();


			TempData["MessageType"] = "warning";
			TempData["Status"] = "Úspěšně vytvořeno, prosím přidejte obrázky a kategorie.";

			return RedirectToAction("EditProduct", new {p.Id});
		}

		[Route("Admin/EditProducts/{id}")]
		[Route("Admin/EditProduct/{id}")]
		public IActionResult EditProduct(int id) 
		{
			Product p = _context.Products.Find(id);
			ProductFormModel model = new ProductFormModel(id,p.Name,p.Description,p.Price,p.Discount,p.AvailableCount,p.Manufacturer.Id,_context.Manufacturers.ToList());
			
			return View(model);
		}
		[HttpPost]
		[Route("Admin/EditProducts")]
		public IActionResult EditProduct(ProductFormModel model)
		{
			model.Manufacturers = _context.Manufacturers.ToList();
			ModelState.MarkFieldValid("Manufacturers");

			if (!ModelState.IsValid || model.ManufacturerID <= 0)
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Nebylo možné aktualizovat produkt...";
				return View(model);
			}

			Product p = new(model.Id, model.Name, model.Description, model.Price, model.Discount, model.AvailableCount, model.ManufacturerID, null, null, null);
			_context.Products.Update(p);
			_context.SaveChanges();

			TempData["MessageType"] = "success";
			TempData["Status"] = "Úspěšně aktualizováno.";

			return View(model);
		}
		[Route("Admin/DeleteProducts/{id}")]
		public IActionResult DeleteProduct(int id) {

			var p = _context.Products.Find(id);
			_context.Products.Remove(p);
			_context.SaveChanges();
			return RedirectToAction("Products"); 
		}
	}
}
