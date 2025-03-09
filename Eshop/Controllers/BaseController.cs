using Eshop.Database;
using Eshop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Controllers
{
	public class BaseController : Controller
	{
		protected DatabaseContext _context;

		public BaseController(DatabaseContext context)
		{
			_context = context;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			ViewBag.UserInfo = UserInfoExtractorHelper.GetUserInfo(_context, HttpContext);

			base.OnActionExecuting(context);
		}
	}
}
