namespace Eshop.Models
{
	public class LoginModel
	{
		public LoginModel()
		{
			Mail = "";
			Password = "";
		}

		public string Mail { get; set; }
		public string Password { get; set; }

		public LoginModel(string mail, string password)
		{
			Mail = mail;
			Password = password;
		}
	}
}
