using System.ComponentModel.DataAnnotations;

namespace Eshop.Models
{
	public class ManufacturerModelForm
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(5000)]
		public string? Description { get; set; }

		public ManufacturerModelForm(int id, string name, string? description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		public ManufacturerModelForm()
		{
		}
	}
}
