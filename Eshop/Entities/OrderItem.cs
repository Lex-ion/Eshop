using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbOrderItem")]
	[PrimaryKey("OrderId", ["ProductId"])]
	public class OrderItem
	{
		[Column("OrderID")]
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		
		
		[Column ("ProductID")] 
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }

		[Column("ProductCount")]
		public int ProductCount {  get; set; }

		public OrderItem(int orderId, Order order, int productId, Product product, int productCount)
		{
			OrderId = orderId;
			Order = order;
			ProductId = productId;
			Product = product;
			ProductCount = productCount;
		}

		public OrderItem()
		{
			OrderId = 0;
			Order = null!;
			ProductId = 0;
			Product = null!;

			ProductCount = 0;
		}

	}
}
