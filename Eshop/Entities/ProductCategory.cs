using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbProductCategory")]
	[PrimaryKey("ProductId", ["CategoryId"])]
	public class ProductCategory
	{
		[Column("ProductID")]
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }


		[Column("CategoryID")]
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		public ProductCategory(int productId, Product product, int categorytId, Category category)
		{
			ProductId = productId;
			Product = product;
			CategoryId = categorytId;
			Category = category;
		}

		public ProductCategory()
		{
			ProductId = 0;
			CategoryId = 0;
			Product = null!;
			Category = null!;
		}
	}
}
