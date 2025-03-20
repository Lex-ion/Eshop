using Eshop.Entities;

namespace Eshop.Models
{
	public class OrderItemModel
	{
		public Product Product { get; set; }

		public int ProductId { get; set; }
		public int Count { get; set; }

		public int MaxCount { get; set; }
		

		public OrderItemModel(Product product, int count,int maxCount)
		{
			Product = product;
			Count = count;

			ProductId = Product.Id;

			MaxCount = maxCount;	
		}

		public OrderItemModel()
		{
			Product = null!;
		}
	}
}
