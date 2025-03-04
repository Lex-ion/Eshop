using Eshop.Entities;

namespace Eshop.Models
{
	public class OrderItemModel
	{
		public Product Product { get; set; }

		public int ProductId { get; set; }
		public int Count { get; set; }
		

		public OrderItemModel(Product product, int count)
		{
			Product = product;
			Count = count;

			ProductId = Product.Id;
		}

		public OrderItemModel()
		{
		}
	}
}
