using ShopApplication.Models;

namespace ShopApplication.Interface
{
	public interface IUserRepository
	{
		Task<User> GetUserByEmailAsync(string email);
		Task<User> CreateUserAsync(User user);
	}
}
