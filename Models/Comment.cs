
using Supabase.Postgrest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShopApplication.Models
{
	[Table("comments")]
	public class Comment
	{
		[PrimaryKey("id", false)]
		public int id { get; set; }
		[Column("create_at")]
		public DateTime createAt { get; set; }
		[Column("is_edited")]
		public bool edited { get; set; }
		[Column("comment_text")]
		public string? commentText { get; set;}
		[Column("product_id")]
		public int productId { get; set;}
		public Product product { get; set; }

	}
}
