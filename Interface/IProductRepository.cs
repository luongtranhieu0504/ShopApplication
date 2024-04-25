using ShopApplication.DTO;
using ShopApplication.Models;

namespace ShopApplication.Interface
{
	public interface IProductRepository
	{
		ICollection<Product> GetProduct();
		ICollection<Product> GetProduct(int page, int pageSize);
		ProductDTO GetProductDetail(int productId);
		ICollection<Product> SearchProduct(string keyword);
		ICollection<Product> FilterProductByCategory(string category);
		ICollection<ProductDTO> FilterProductByCategoryAndTag(string category, string tag);
		ICollection<Product> FilterProductByPriceRangeAndTag(float minPrice, float maxPrice, string tag);
		/*ICollection<Product> FilterProductBySizeAndTag(string size, string tag);*/


	}
}
