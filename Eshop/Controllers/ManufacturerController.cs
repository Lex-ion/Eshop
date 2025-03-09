using Eshop.Database;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class ManufacturerController : BaseController
	{
		public ManufacturerController(DatabaseContext context) : base(context)
		{
		}

		public IActionResult Index(int id)
        {
            return View(_context.Manufacturers.Single(m=>m.Id==id));
        }
    }
}
