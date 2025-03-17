namespace Eshop.Models
{
	public class ReviewModel
	{
		public short Rating {  get; set; }
		public string? ReviewText {  get; set; }
		public int ProductId { get; set; }
		public bool Anonymous { get; set; }

		public ReviewModel(short rating, string? text, int productId, bool anonymous)
		{
			Rating = rating;
			ReviewText = text;
			ProductId = productId;
			Anonymous = anonymous;
		}

		public ReviewModel()
		{
		}
	}
}
