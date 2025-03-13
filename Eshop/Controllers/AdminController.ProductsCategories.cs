using Eshop.Entities;
using Eshop.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public partial class AdminController
    {

        [Route("admin/productCategories/{id}")]
        public IActionResult ViewProductCategories(int id)
        {

            var p = _context.Products.Find(id);

            ViewBag.Id = id;
            ViewBag.Product = p;
            ViewBag.Categories = _context.Categories.ToList();
           
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(int id,int category) {

            if(!_context.ProductCategories.Any(c=>c.ProductId==id&&c.CategoryId==category)&&category>0)
            {
                var product = _context.Products.Find(id);
                var categoryEntity = _context.Categories.Find(category);

                ProductCategory pc = new ProductCategory(id,null!,category,null!);
              
                
                _context.ProductCategories.Add(pc);
                
                _context.SaveChanges();
            }

            return RedirectToAction("ViewProductCategories", new { id });
        }
        [HttpPost]
        public IActionResult RemoveCategory(int id, int category)
        {
            var pc = _context.ProductCategories.SingleOrDefault(c=>c.ProductId == id&&c.CategoryId==category);
            if(pc==null)
                return RedirectToAction("ViewProductCategories", new { id });

            _context.ProductCategories.Remove(pc);
            _context.SaveChanges();

            return RedirectToAction("ViewProductCategories", new { id });
        }
    }
}
