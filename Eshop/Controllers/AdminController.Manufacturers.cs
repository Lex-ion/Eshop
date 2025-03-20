using Eshop.Entities;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public partial class AdminController
	{
		[Route("Admin/AddManufacturer")]
		[Route("Admin/AddManufacturers")]
		public IActionResult AddManufacturer()
		{
			return View();
		}


		[Route("Admin/EditManufacturers/{id}")]
		[Route("Admin/EditManufacturer/{id}")]
		public IActionResult EditManufacturer(int id)
		{
			Manufacturer? m = _context.Manufacturers.Find(id);
			if (m is null)
				return RedirectToAction("Manufacturers");
			ManufacturerModelForm model = new(id, m.Name, m.Description);

			return View(model);
		}


		[Route("Admin/AddManufacturer")]
		[Route("Admin/AddManufacturers")]
		[HttpPost]
		public IActionResult AddManufacturer(ManufacturerModelForm model)
		{
			ModelState.ClearValidationState("Id");
			ModelState.MarkFieldValid("Id");

			if (!ModelState.IsValid)
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Nebylo možné vytvořit výrobce...";
				return View();
			}

			if (_context.Manufacturers.Any(c => c.Name.ToLower() == model.Name.ToLower()))
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Výrobce s tímto názvem již existuje!";
				return View();
			}

			Manufacturer m = new(0, model.Name, model.Description, null!);
			_context.Manufacturers.Add(m);
			_context.SaveChanges();


			TempData["MessageType"] = "warning";
			TempData["Status"] = "Úspěšně vytvořeno, prosím přidejte logo a produkty.";

			return RedirectToAction("EditManufacturer",new {m.Id});
		}


		[Route("Admin/EditManufacturers/{id}")]
		[Route("Admin/EditManufacturer/{id}")]
		[HttpPost]
		public IActionResult EditManufacturer(ManufacturerModelForm model)
		{
			if (!ModelState.IsValid)
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Nebylo možné vytvořit kategorii...";
				return View(model);
			}

			if (_context.Manufacturers.Any(c => c.Name.ToLower() == model.Name.ToLower()))
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Kategorie s tímto názvem již existuje!";
				return View(model);
			}

			Manufacturer m = new(model.Id, model.Name, model.Description, null!);
			_context.Manufacturers.Update(m);
			_context.SaveChanges();

			return RedirectToAction("Categories");
		}




		[Route("Admin/DeleteManufacturers/{id}")]
		[Route("Admin/DeleteManufacturer/{id}")]
		public IActionResult Deletemanufacturer(int id)
		{
			Manufacturer? m = _context.Manufacturers.Find(id);
			if (m is null)
				return RedirectToAction("Manufacturers");

			_context.Manufacturers.Remove(m);
			_context.SaveChanges();

			return RedirectToAction("Manufacturers");
		}
	}
}