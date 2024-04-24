namespace ShopApplication.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
	}

	public class RegisterRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}

	public class LoginRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}

	public class TokenResponse
	{
		public string Token { get; set; }
	}
}
