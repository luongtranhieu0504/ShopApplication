using Postgrest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShopApplication.Models
{
	[Table("images")]
	public class Image
	{
		[PrimaryKey("id", false)]
		public int id { get; set; }
		[Column("url")]
		public string? url { get; set; }
		[Column("width")]
		public int width { get; set; }
		[Column("height")]
		public int height { get; set; }
		[Column("create_at")]
		public DateTime createAT { get; set; }
		[Column("product_id")]
		public int producId { get; set; }
		public Product? product { get; set; }
	}
}
