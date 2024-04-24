using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Interface;
using ShopApplication.Models;

namespace ShopApplication.Repository
{
	public class CartRepository : ICartRepository
	{
		private readonly DataContext _context;
		public CartRepository(DataContext context)
		{
			_context = context;
		}


		public async Task<List<CartItem>> GetCartItems()
		{
			return await _context.Carts.ToListAsync();
		}

		public async Task<bool> AddToCart(CartItem cartItem)
		{
			try
			{
				var existingCartItem = await _context.Carts
					.FirstOrDefaultAsync(ci => ci.productId == cartItem.productId);

				if (existingCartItem != null)
				{
					existingCartItem.quantity += cartItem.quantity;
					_context.Carts.Update(existingCartItem);
				}
				else
				{
					_context.Carts.Add(cartItem);
				}

				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public async Task UpdateCartItemQuantity(int cartItemId, int newQuantity)
		{
			var cartItem = await _context.Carts.FindAsync(cartItemId);

			if (cartItem != null)
			{
				cartItem.quantity = newQuantity;
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Cart item not found.");
			}
		}

		public async Task DeleteCartItem(int cartItemId)
		{
			var cartItem = await _context.Carts.FindAsync(cartItemId);

			if (cartItem != null)
			{
				_context.Carts.Remove(cartItem);
				await _context.SaveChangesAsync();
			}
		}

		public async Task DeleteAllCartItems()
		{
			var allCartItems = await _context.Carts.ToListAsync();
			foreach (var cartItem in allCartItems)
			{
				_context.Carts.Remove(cartItem);
			}
			await _context.SaveChangesAsync();
		}
	}
}
