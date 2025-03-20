using Eshop.Database;
using Eshop.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Eshop.Controllers
{
	public class SecuredController : BaseController
	{
		protected bool AdminOnly { get; private set; }
		public SecuredController(DatabaseContext context, bool adminOnly) : base(context)
		{
			AdminOnly = adminOnly;
		}

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
					context.Result = BadRequest();
					return;
				}

			base.OnActionExecuting(context);
		}
	}
}
