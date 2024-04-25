using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Interface;
using ShopApplication.Models;

namespace ShopApplication.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _context;

		public UserRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<User> CreateUserAsync(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
			return user;
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.email == email);
		}
	}
}
