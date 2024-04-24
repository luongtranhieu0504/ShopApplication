using ShopApplication.Models;

namespace ShopApplication.Interface
{
	public interface ICartRepository
	{
		Task<List<CartItem>> GetCartItems();
		Task<bool> AddToCart(CartItem cartItem);
		Task UpdateCartItemQuantity(int cartItemId, int newQuantity);
		Task DeleteCartItem(int cartItemId);
		Task DeleteAllCartItems();

	}
}
