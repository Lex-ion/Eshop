using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbDeliveryMethods")]
	public class DeliveryMethod
	{
		[Column("Id")]
		public int Id { get; set; }

		[Column("MethodName")]
		public string Name { get; set; }

		public DeliveryMethod()
		{
		}
	}
}
