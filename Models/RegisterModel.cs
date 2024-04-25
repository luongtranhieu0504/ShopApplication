using System.Text.Json.Serialization;

namespace ShopApplication.Models
{
	public class RegisterModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
