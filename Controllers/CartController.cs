using Microsoft.AspNetCore.Mvc;
using ShopApplication.Interface;
using ShopApplication.Models;
using ShopApplication.Repository;

namespace ShopApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : Controller
	{
		private ICartRepository _cartRepository;
		public CartController(ICartRepository cartRepository)
		{
			_cartRepository = cartRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetCartItems()
		{
			try
			{
				var cartItems = await _cartRepository.GetCartItems();

				// Trả về danh sách các CartItem dưới dạng phản hồi HTTP 200 OK
				return Ok(cartItems);
			}
			catch (Exception ex)
			{
				// Trả về lỗi 500 Internal Server Error nếu có lỗi xảy ra
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}


		[HttpPost("add-to-cart")]
		public async Task<IActionResult> AddToCart([FromBody] CartItem cartItem)
		{
			if (cartItem == null)
			{
				return BadRequest("Invalid request data.");
			}

			try
			{
				var newCartItem = new CartItem
				{
					productId = cartItem.productId,
					name = cartItem.name,
					imageUrl = cartItem.imageUrl,
					price = cartItem.productId,
					salePercentage = cartItem.productId,
					size = cartItem.size,
					color= cartItem.color,
					quantity = cartItem.quantity,
				};

				// Gọi phương thức của repository để thêm CartItem vào giỏ hàng
				await _cartRepository.AddToCart(newCartItem);

				return Ok("Product added to cart successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("update-cart-item")]
		public async Task<IActionResult> UpdateCartItemQuantity(int cartItemId, int newQuantity)
		{
			try
			{
				await _cartRepository.UpdateCartItemQuantity(cartItemId, newQuantity);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("delete-cart-item")]
		public async Task<IActionResult> DeleteCartItem(int cartItemId)
		{
			try
			{
				await _cartRepository.DeleteCartItem(cartItemId);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("delete-all-cart-items")]
		public async Task<IActionResult> DeleteAllCartItems()
		{
			try
			{
				await _cartRepository.DeleteAllCartItems();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

	}
}
