using Postgrest.Attributes;

namespace ShopApplication.Models
{
	[Table("order")]
	public class OrderToProduct
	{

		public int OrderId { get; set; }
		public Order Order { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public string ProductName { get; set; }
		public int amountItem { get; set; }
		public float ProductPrice { get; set; }
		public string color { get; set; }
		public string? size { get; set; }
		
	}
}
