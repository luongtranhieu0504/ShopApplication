using Microsoft.AspNetCore.Mvc;
using ShopApplication.Interface;
using ShopApplication.Models;

namespace ShopApplication.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly Supabase.Client _supabase;

		
		public UserController(IUserRepository userRepository, Supabase.Client supabase)
		{
			_userRepository = userRepository;
			_supabase = supabase;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginModel model)
		{
			var session = await _supabase.Auth.SignIn(model.Email, model.Password);

			if (session != null && session.User != null)
			{
				// Đăng nhập thành công, bạn có thể xử lý logic sau đăng nhập ở đây
				return Ok(new { message = "Login successful" });
			}
			else
			{
				// Đăng nhập thất bại
				return BadRequest(new { message = "Invalid email or password" });
			}
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterModel model)
		{
			// Register user with Supabase Auth
			var session = await _supabase.Auth.SignUp(model.Email, model.Password);

			// Create local user record with default info
			if (session != null && session.User != null)
			{
				/*var newUser = new User
				{
					email = model.Email,
					name = "Default Name", 
					phoneNumber = "Default Phone Number", 
					profileImage = "Default Profile Image",
					passwordHash = "Secret Value"
				};

				await _userRepository.CreateUserAsync(newUser);*/

				return Ok(new { message = "User registered successfully" });
			}
			else
			{
				return BadRequest(new { message = "Failed to register user" });
			}
		}
	}
}
