using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbAccounts")]
	public class Account
	{
		[Column("ID")]
		public int Id { get; set; }

		[Column("AccountType")]
		public int AccountTypeId { get; set; }
		public virtual AccountType AccountType { get; set; }

		[Column("Name")]
		public string Name { get; set; }

		[Column("Surname")]
		public string Lastname { get; set; }

		[Column("Adress")]
		public string Adress { get; set; }

		[Column("Mail")]
		public string Mail { get; set; }

		[Column("Password")]
		public string Password { get; set; }

		[Column("RegistrationDate")]
		public DateTime RegistrationDate { get; set; }

		[Column("LastLogin")]
		public DateTime LastLogin { get; set; }

		public virtual List<Review> Reviews { get; set; }

		public Account(int id, int accountTypeId, AccountType accountType, string name, string lastname, string adress, string mail, string password, DateTime registrationDate, DateTime lastLogin, List<Review> reviews)
		{
			Id = id;
			AccountTypeId = accountTypeId;
			AccountType = accountType;
			Name = name;
			Lastname = lastname;
			Adress = adress;
			Mail = mail;
			Password = password;
			RegistrationDate = registrationDate;
			LastLogin = lastLogin;
			Reviews = reviews;
		}

		public Account()
		{
			Id = 0;
			AccountTypeId = 0;
			AccountType = null!;
			Name = string.Empty;
			Lastname = string.Empty;
			Adress = string.Empty;
			Mail = string.Empty;
			Password = string.Empty;
			RegistrationDate = DateTime.Now;
			LastLogin = DateTime.Now;
			Reviews = new List<Review>();
		}
	}
}
