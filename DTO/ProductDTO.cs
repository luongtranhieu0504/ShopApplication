using ShopApplication.Models;

namespace ShopApplication.DTO
{
	public class ProductDTO
	{
		public int id { get; set; }
		public string name { get; set; }
		public float price { get; set; }
		public float salePercentage { get; set; }
		public string imageUrl { get; set; }
		public string status { get; set; }
		public string category { get; set; }
		public string availableSize { get; set; }
		public string availableColor { get; set; }
		public List<string> images { get; set; }
	}
}
