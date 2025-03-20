using Eshop.Database;
using Eshop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Eshop.Controllers
{
	public class SecuredController(DatabaseContext context, bool adminOnly) : BaseController(context)
	{
		protected bool AdminOnly { get; private set; } = adminOnly;

		public override void OnActionExecuting(ActionExecutingContext context)
		{

			var ui = UserInfoExtractorHelper.GetUserInfo(_context, HttpContext);
			if (!ui.IsAuthenticated)
			{
				context.Result = RedirectToAction("Login", "Auth");
				return;
			}

			if(AdminOnly&&ui.Role!=1) 
				{
					context.Result = new StatusCodeResult(403);
					return;
				}

			base.OnActionExecuting(context);
		}
	}
}
