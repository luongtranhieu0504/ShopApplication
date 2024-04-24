
using Supabase.Postgrest.Attributes;
namespace ShopApplication.Models
{
	[Table("cart")]
	public class CartItem
	{
		[PrimaryKey("id", false)]
		public int id { get; set; }
		[Column("create_at")]
		public DateTime createAt { get; set; }
		// Thông tin sản phẩm
		[Column("product_id")]
		public int productId { get; set; }
		[Column("name")]
		public string name { get; set; }
		[Column("image_url")]
		public string imageUrl { get; set; }
		[Column("price")]
		public float price { get; set; }
		[Column("sale_percentage")]
		public float salePercentage { get; set; }

		// Thông tin mua hàng
		[Column("size")]
		public string size { get; set; }
		[Column("color")]
		public string color { get; set; }
		[Column("quantity")]
		public int quantity { get; set; }
		// Các thuộc tính khác nếu cần thiết

	}
}
