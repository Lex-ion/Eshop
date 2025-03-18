using Eshop.Entities;

namespace Eshop.Models
{
	public class ProductSearchModel
	{

		public List<Product> Products { get; set; } = new List<Product>();
		public List<Category> Categories { get; set; } = new List<Category>();
		public List<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
		public ProductFilterModel Filter { get; set; } = new ProductFilterModel();
		
	}

}
