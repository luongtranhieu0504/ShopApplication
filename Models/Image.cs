using Supabase.Postgrest.Attributes;
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
		[Column("product_id")]
		public int producId { get; set; }
		public virtual Product product { get; set; }
	}
}
