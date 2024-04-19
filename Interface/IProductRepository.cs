using ShopApplication.Models;

namespace ShopApplication.Interface
{
	public interface IProductRepository
	{
		ICollection<Product> GetProduct();
		ICollection<Product> GetProduct(int page, int pageSize);
		Product GetProductDetail(int productId);
		ICollection<Product> SearchProduct(string keyword);
		ICollection<Product> FilterProductByCategory(string category);
		ICollection<Product> FilterProductByCategoryAndTag(string category, string tag);
		ICollection<Product> FilterProductByPriceRangeAndTag(float minPrice, float maxPrice, string tag);
		/*ICollection<Product> FilterProductBySizeAndTag(string size, string tag);*/


	}
}
