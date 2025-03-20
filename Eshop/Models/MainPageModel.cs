using Eshop.Entities;

namespace Eshop.Models
{
	public class MainPageModel
	{
		public List<Product> Products { get; set; }
		public string? SearchString { get; set; }

		public MainPageModel(List<Product> products, string? searchString)
		{
			Products = products;
			SearchString = searchString;
		}

		public MainPageModel()
		{
			Products = new List<Product>();
			SearchString = "";
		}
	}
}
