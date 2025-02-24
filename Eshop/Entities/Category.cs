using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbCategories")]
	public class Category
	{
		[Column("ID")]
		public int Id { get; set; }

		[Column("NAME")]
		public string Name { get; set; }

		[Column("Description")]
		public string? Description { get; set; }

		public virtual List<ProductCategory> ProductCategories { get; set; }

		public Category(int id, string name, string? description, List<ProductCategory> productCategories)
		{
			Id = id;
			Name = name;
			Description = description;
			ProductCategories = productCategories;
		}

		public Category()
		{
			Id = 0;
			Name = string.Empty;
			Description = null;
			ProductCategories = new List<ProductCategory>();
		}
	}
}
