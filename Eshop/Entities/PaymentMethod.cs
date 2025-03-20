using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbPaymentMethod")]
	public class PaymentMethod
	{
		[Column("Id")]
		public int Id { get; set; }

		[Column("MethodName")]
		public string Name { get; set; }

		public PaymentMethod()
		{
			Name = "";
		}
	}
}
