using Eshop.Controllers;
using Eshop.Database;
using Eshop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Eshop.Attributes
{
	public class ImportEntitiesAttribute : ActionFilterAttribute
	{
		DatabaseContext _db;

		public ImportEntitiesAttribute(DatabaseContext dbContext)
		{
			_db = dbContext;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var desc = context.ActionDescriptor as ControllerActionDescriptor;
			var dbSetProperties = typeof(DatabaseContext)
		  .GetProperties(BindingFlags.Public | BindingFlags.Instance)
		  .Where(p => p.PropertyType.IsGenericType &&
					  p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
		  .ToList();

			if (dbSetProperties.All(p => p.Name != desc.ActionName))
				throw new Exception();

			var propertyInfo = dbSetProperties.Single(p => p.Name == desc.ActionName);

			var dbSetInstance = propertyInfo.GetValue(_db);

			Type entityType = propertyInfo.PropertyType.GetGenericArguments()[0];

			var toListMethod = typeof(Enumerable).GetMethod("ToList")!
												.MakeGenericMethod(entityType);

			var entityList = toListMethod.Invoke(null, new object[] { dbSetInstance });

			(context.Controller as Controller).ViewBag.Entities = entityList;
			(context.Controller as Controller).ViewBag.Type = propertyInfo.Name;
			(context.Controller as Controller).ViewBag.Types = AliasHelper.GetMethodAliases<AdminController>();




		}
	}
}
