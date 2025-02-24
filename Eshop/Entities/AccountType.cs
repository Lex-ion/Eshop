using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbAccountTypes")]
	public class AccountType
	{
		[Column("ID")]
		public int Id { get; set; }
		[Column("Type")]
		public string Type { get; set; }

		public AccountType(int id, string type)
		{
			Id = id;
			Type = type;
		}

		public AccountType()
		{
			Id = 0;
			Type = string.Empty;
		}
	}
}
