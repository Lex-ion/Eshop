using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbManufacturers")]
	public class Manufacturer
	{
		[Column("ID")]
		public int Id { get; set; }

		[Column("NAME")]
		public string Name { get; set; }

		[Column("Description")]
		public string? Description { get; set; }

		public virtual List<Product> Products { get; set; }

		public Manufacturer(int id, string name, string? description, List<Product> products)
		{
			Id = id;
			Name = name;
			Description = description;
			Products = products;
		}

		public Manufacturer()
		{
			Id = 0;
			Name = string.Empty;
			Description =null;
			Products = [];
		}
		public override string? ToString()
		{
			return Name;
		}

	}
}
