namespace ShopApplication.DTO
{
	public class OrderDTO
	{
		public int id { get; set; }
		public DateTime createAt { get; set; }
		public int itemsCount { get; set; }
		public string status { get; set; }
		public float totalAmount { get; set; }
		public float subTotal { get; set; }
		public float discount { get; set; }
		public float shipmentPrice { get; set; }
		public string paymentMethod { get; set; }
		public string shippingMethod { get; set; }
		public string fullName { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public string address { get; set; }
		public string city { get; set; }
		public string region { get; set; }
		public string postalCode { get; set; }
	}
}
