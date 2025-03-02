using Eshop.Database;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class ManufacturerController : Controller
    {
        DatabaseContext _context;

        public ManufacturerController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            return View(_context.Manufacturers.Single(m=>m.Id==id));
        }
    }
}
