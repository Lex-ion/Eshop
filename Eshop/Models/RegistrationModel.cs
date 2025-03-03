using Microsoft.Extensions.Primitives;

namespace Eshop.Models
{
	public class RegistrationModel
	{
		public string Name { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string Adress { get; set; }
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
		}
	}
}
