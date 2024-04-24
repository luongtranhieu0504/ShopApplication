using Supabase.Postgrest.Attributes;

namespace ShopApplication.Models
{
	[Table("tags")]
	public class Tag
	{
		[PrimaryKey("id", false)]
		public int id { get; set; }
		[Column("name_tag")]
		public string nameTag { get; set; }
		public List<ProductTag> ProductTags { get; set; }
	}
}
