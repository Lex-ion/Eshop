namespace Eshop.Models
{
	public class ProductFilterModel
	{
		public string? SearchQuery { get; set; }
		public List<int> SelectedCategories { get; set; } = new();
		public List<int> SelectedManufacturers { get; set; } = new();
		public SortByPrice PriceSort { get; set; } = SortByPrice.None;
	}
	public enum SortByPrice
	{
		None,
		Ascending,
		Descending
	}

}
