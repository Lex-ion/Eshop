using Eshop.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
	public partial class AdminController
	{


		[Route("admin/images/{type}/{id}")]
		public IActionResult ViewImages(string type, int id)
		{
			if (!IntegrityHelper.DirectoryExists(type, id))
				return RedirectToAction("Index");

			ViewBag.Type = type;
			ViewBag.Id = id;

			ViewBag.Images = IntegrityHelper.GetImages(type, id).Select(i => i.Name);

			return View();
		}
		[HttpPost]
		[Route("admin/images/delete")]
		public IActionResult DeleteImage(string type, int id, string fileName)
		{
			if (!IntegrityHelper.DirectoryExists(type, id))
				return RedirectToAction("ViewImages", new { type, id });
			string image = IntegrityHelper.CombineImageFolderPath(type, id) + $"/{fileName}";
			if (System.IO.File.Exists(image))
				System.IO.File.Delete(image);

			return RedirectToAction("ViewImages", new { type, id });

		}
		[HttpPost]
		[Route("admin/images/upload")]
		public async Task<IActionResult> UploadImage(string type, int id, IFormFile image)
		{
			if (image == null || image.Length == 0)
			{
				return BadRequest("Invalid file.");
			}
			if (image.ContentType != "image/png")
				return BadRequest("Povoleny jsou pouze PNG soubory.");

			string uploadFolder = IntegrityHelper.CombineImageFolderPath(type, id);
			Directory.CreateDirectory(uploadFolder);

			string fileName = $"{id}_{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
			string filePath = Path.Combine(uploadFolder, fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await image.CopyToAsync(stream);
			}

			return RedirectToAction("ViewImages", new { type, id });
		}
	}
}
