namespace Eshop.Models
{
	public class ProductFilterModel
	{
		public List<int> SelectedCategories { get; set; } = new List<int>();
		public List<int> SelectedManufacturers { get; set; } = new List<int>();
		public string? SearchQuery { get; set; }
	}

}
