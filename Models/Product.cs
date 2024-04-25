using Supabase.Postgrest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShopApplication.Models
{
	[Table("products")]
	public class Product
	{
		[PrimaryKey("id", false)]
		public int id { get; set; }
		[Column("create_at")]
		public DateTime createAt { get; set; }
		[Column("name")]
		public string name { get; set; }
		[Column("price")]
		public float price { get; set; }
		[Column("sale_percentage")]
		public float salePercentage { get; set; }
		[Column("image_url")]
		public string imageUrl { get; set; }
		[Column("status")]
		public string status { get; set; }
		[Column("category")]
		public string category { get; set; }
		[Column("available_size")]
		public string availableSize { get; set; }
		[Column("available_color")]
		public string availableColor { get; set; }
		public List<OrderToProduct> orderToProducts { get; set; }
		public List<Image> images { get; set; }
		public List<Comment> comments { get; set; }
		public List<ProductTag> productTags { get; set; }
	}
}
