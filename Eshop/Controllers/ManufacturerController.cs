using Eshop.Database;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class ManufacturerController(DatabaseContext context) : BaseController(context)
	{
		public IActionResult Index(int id)
        {
            return View(_context.Manufacturers.Single(m=>m.Id==id));
        }
    }
}
