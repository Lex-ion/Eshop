using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbOrderStates")]
	public class OrderState
	{
		[Column("ID")]
		public int Id { get; set; }

		[Column("StateType")]
		public string StateType { get; set; }

		public OrderState(int id, string stateType)
		{
			Id = id;
			StateType = stateType;
		}

		public OrderState()
		{
			Id = 0;
			StateType = string.Empty;
		}
	}
}
