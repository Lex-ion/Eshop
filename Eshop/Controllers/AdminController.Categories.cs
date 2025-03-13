using Eshop.Entities;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public partial class AdminController
	{
		[Route("Admin/AddCategory")]
		[Route("Admin/AddCategories")]
		public IActionResult AddCategory()
		{
			return View();
		}
		[Route("Admin/EditCategories/{id}")]
		[Route("Admin/EditCategory/{id}")]
		public IActionResult EditCategory(int id)
		{
			Category p = _context.Categories.Find(id);
			CategoryFormModel model = new CategoryFormModel(id, p.Name, p.Description);

			return View(model);
		}


		[Route("Admin/AddCategory")]
		[Route("Admin/AddCategories")]
		[HttpPost]
		public IActionResult AddCategory(CategoryFormModel model)
		{
			ModelState.ClearValidationState("Id");
			ModelState.MarkFieldValid("Id");

			if (!ModelState.IsValid)
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Nebylo možné vytvořit kategorii...";
				return View();
			}

			if(_context.Categories.Any(c=>c.Name.ToLower()==model.Name.ToLower()))
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Kategorie s tímto názvem již existuje!";
				return View();
			}

			Category c = new(0, model.Name, model.Description,null!);
			_context.Categories.Add(c);
			_context.SaveChanges();
			return RedirectToAction("Categories");
		}

		[Route("Admin/EditCategory/{id}")]
		[Route("Admin/EditCategories/{id}")]
		[HttpPost]
		public IActionResult EditCategory(CategoryFormModel model)
		{
			if (!ModelState.IsValid)
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Nebylo možné vytvořit kategorii...";
				return View(model);
			}

			if (_context.Categories.Any(c => c.Name.ToLower() == model.Name.ToLower()))
			{
				TempData["MessageType"] = "danger";
				TempData["Status"] = "Kategorie s tímto názvem již existuje!";
				return View(model);
			}

			Category c = new(model.Id, model.Name, model.Description, null!);
			_context.Categories.Update(c);
			_context.SaveChanges();

			return RedirectToAction("Categories");
		}




		[Route("Admin/DeleteCategories/{id}")]
		[Route("Admin/DeleteCategory/{id}")]
		public IActionResult DeleteCategory(int id)
		{

			var c = _context.Categories.Find(id);


			_context.Categories.Remove(c);
			_context.SaveChanges();

			return RedirectToAction("Categories");
		}
	}
}
