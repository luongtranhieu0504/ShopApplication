using Supabase.Postgrest.Attributes;

namespace ShopApplication.Models
{
	[Table("order")]
	public class OrderToProduct
	{
		public int id { get; set; }
		public int orderId { get; set; }
		public Order order { get; set; }
		List<CartItem> cartItems { get; set; }
		
		
	}
}
