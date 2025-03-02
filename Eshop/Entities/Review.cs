using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbReviews")]
	public class Review
	{

		[Column("ID")]
		public int Id { get; set; }

		[Column("ProductID")]
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }

		[Column("Rating")]
		public short Rating { get; set; }

		[Column("Description")]
		public string? Description { get; set; }

		[Column("AccountID")]
		public int? AccountID { get; set; }
		public virtual Account? Account { get; set; }
		[Column("Redacted")]
		public bool IsDeleted { get; set; }

		public Review(int id, int productId, Product product, short rating, string? description, int? accountID, Account? account, bool isDeleted)
		{
			Id = id;
			ProductId = productId;
			Product = product;
			Rating = rating;
			Description = description;
			AccountID = accountID;
			Account = account;
			IsDeleted = isDeleted;
		}

		public Review()
		{
			Id = 0;
			ProductId = 0;
			Product = null!;
			Rating = 0;
			Description = string.Empty;
			AccountID = 0;
			Account = null!;
			IsDeleted = false;

		}
	}
}
