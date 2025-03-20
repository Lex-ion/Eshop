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


	// This attribute is used to import entities from the database into ViewBag before executing a controller action
	public class ImportEntitiesAttribute(DatabaseContext dbContext) : ActionFilterAttribute
	{
		private readonly DatabaseContext _db = dbContext;

		// This method is executed before the controller action is executed
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			// Check if the ActionDescriptor is of type ControllerActionDescriptor
			if (context.ActionDescriptor is not ControllerActionDescriptor desc)
			{
				throw new InvalidOperationException("ActionDescriptor is not a ControllerActionDescriptor");
			}

			// Get all public properties of type DbSet<> from DatabaseContext
			var dbSetProperties = typeof(DatabaseContext)
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => p.PropertyType.IsGenericType &&
							p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
				.ToList();

			// Check if there is a property with a name matching the action name
			if (dbSetProperties.All(p => p.Name != desc.ActionName))
				throw new Exception();

			// Get the property info matching the action name
			var propertyInfo = dbSetProperties.Single(p => p.Name == desc.ActionName);

			// Get the instance of DbSet from DatabaseContext
			Object? dbSetInstance = propertyInfo.GetValue(_db) ?? throw new InvalidOperationException("DbSet instance is null");

			// Get the entity type from DbSet
			Type entityType = propertyInfo.PropertyType.GetGenericArguments()[0];

			// Get the ToList method for the entity type
			var toListMethod = typeof(Enumerable).GetMethod("ToList")!
												.MakeGenericMethod(entityType);

			// Execute the ToList method to get the list of entities
			var entityList = toListMethod.Invoke(null, [dbSetInstance]);

			// Store the list of entities and the type name in ViewBag
			((Controller)(context.Controller)).ViewBag.Entities = entityList;
			((Controller)(context.Controller)).ViewBag.Type = propertyInfo.Name;
			((Controller)(context.Controller)).ViewBag.Types = AliasHelper.GetMethodAliases<AdminController>();
		}
	}
}
