using Supabase.Postgrest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShopApplication.Models
{
	[Table("orders")]
	public class Order
	{
		[PrimaryKey("id", false)]
		public int id { get; set; }
		[Column("create_at")]
		public DateTime createAt { get; set; }
		[Column("items_count")]
		public int itemsCount { get; set; }
		[Column("status")]
		public string status { get; set; }
		[Column("total_amount")]
		public float totalAmount { get; set; }
		[Column("sub_total")]
		public float subTotal { get; set; }
		[Column("discount")]
		public float discount { get; set; }
		[Column("shipment_price")]
		public float shipmentPrice { get; set;}
		[Column("payment_method")]
		public string paymentMethod { get; set;}
		[Column("shipping_method")]
		public string shippingMethod { get; set;}
		[Column("full_name")]
		public string fullName { get; set;}
		[Column("email")]
		public string email { get; set;}
		[Column("phone_number")]
		public string phone { get; set;}
		[Column("address")]
		public string address { get; set;}
		[Column("city")]
		public string city { get; set;}
		[Column("region")]
		public string region { get; set;}
		[Column("postal_code")]
		public string postalCode { get; set;}
		public string cardNumber { get; set;}
		public string nameCard { get; set;}
		public string expirationDate { get; set;}
		public string CVC { get; set;}
		public List<OrderToProduct> orderToCarts { get; set; }
	}
}
