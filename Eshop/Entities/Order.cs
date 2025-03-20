using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Xml.Linq;

namespace Eshop.Entities
{
	[Table("tbOrders")]
	public class Order
	{
		[Column("ID")]
		public int Id { get; set; }

		[Column("AccountID")]
		public int? AccountId { get; set; }
		public virtual Account? Account { get; set; }

		[Column("TotalPrice")]
		public decimal TotalPrice { get; set; }

		[Column("OrderDate")]
		public DateTime OrderDate { get; set; }

		[Column("Name")]
		public string Name { get; set; }

		[Column("Surname")]
		public string Lastname { get; set; }

		[Column("Adress")]
		public string Adress { get; set; }

		[Column("Mail")]
		public string Mail { get; set; }

		[Column("IsDelivered")]
		public bool IsDelivered { get; set; }

		[Column("DeliveryDate")]
		public DateTime? DeliveryDate { get; set; }

		[Column("OrderState")]
		public int OrderStateId { get; set; }
		public virtual OrderState OrderState { get; set; }

		[Column("PaymentMethod")]
		public int PaymentMethodId { get; set; }
		public virtual PaymentMethod PaymentMethod { get; set; }

		[Column("DeliveryMethod")]
		public int DeliveryMethodId { get; set; }
		public virtual DeliveryMethod DeliveryMethod { get; set; }



		public virtual List<OrderItem> OrderItems { get; set; }

		public Order(int id, int? accountId, Account? account, decimal totalPrice, DateTime orderDate, string name, string lastname, string adress, string mail, bool isDelivered, DateTime? deliveryDate, int orderStateId, OrderState orderState, int paymentMethodId, PaymentMethod paymentMethod, int deliveryMethodId, DeliveryMethod deliveryMethod, List<OrderItem> orderItems)
		{
			Id = id;
			AccountId = accountId;
			Account = account;
			TotalPrice = totalPrice;
			OrderDate = orderDate;
			Name = name;
			Lastname = lastname;
			Adress = adress;
			Mail = mail;
			IsDelivered = isDelivered;
			DeliveryDate = deliveryDate;
			OrderStateId = orderStateId;
			OrderState = orderState;
			PaymentMethodId = paymentMethodId;
			PaymentMethod = paymentMethod;
			DeliveryMethodId = deliveryMethodId;
			DeliveryMethod = deliveryMethod;
			OrderItems = orderItems;
		}

		public Order()
		{
			Id = 0;
			AccountId = 0;
			Account = null!;
			TotalPrice = 0;
			OrderDate = DateTime.Now;
			Name = string.Empty;
			Lastname = string.Empty;
			Adress = string.Empty;
			Mail = string.Empty;
			IsDelivered = false;
			DeliveryDate = null;
			OrderStateId = 0;
			OrderState = null! ;
			OrderItems = new();
			DeliveryMethod = null!;
			PaymentMethod = null!;
		}

		public override string? ToString()
		{
			return $"[{OrderState.StateType}] {OrderDate.ToShortDateString()}: {Mail}";
		}
	}
}
