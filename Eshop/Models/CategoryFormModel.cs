using System.ComponentModel.DataAnnotations;

namespace Eshop.Models
{
	public class CategoryFormModel
	{
		public CategoryFormModel()
		{
			Name = "";
			Description = "";
		}

		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(1000)]
		public string? Description { get; set; }

		public CategoryFormModel(int id, string name, string? description)
		{
			Id = id;
			Name = name;
			Description = description;
		}
	}
}
