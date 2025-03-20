using Eshop.Attributes;
using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Models
{
	public class RegistrationModel
	{
		[MaxLength(50)]
		public string Name { get; set; }
        [MaxLength(50)]
        public string Lastname { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; }
		[Matchfields("PasswordRepeat")]
		[MinLength(3)]
		public string Password { get; set; }
		public string PasswordRepeat { get; set; }

		public RegistrationModel(string name, string lastname, string email, string adress, string password, string passwordRepeat)
		{
			Name = name;
			Lastname = lastname;
			Email = email;
			Adress = adress;
			Password = password;
			PasswordRepeat = passwordRepeat;
		}

		public RegistrationModel()
		{
			Name = "";
			Lastname = "";
			Email = "";
			Adress = "";
			Password = "";
			PasswordRepeat = "";
		}
	}
}
