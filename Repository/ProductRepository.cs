using ShopApplication.Models;
using ShopApplication.Interface;

using System.Data;
using ShopApplication.Data;
using Microsoft.EntityFrameworkCore;
using ShopApplication.DTO;

namespace ShopApplication.Repository
{
    public class ProductRepository : IProductRepository
	{
		private readonly DataContext _context;
		public ProductRepository(DataContext context) {

			_context = context;
		}


		public ICollection<Product> GetProduct()
		{
			return _context.Products.OrderBy(p => p.id).ToList();
		}

		public ICollection<Product> GetProduct(int page = 1, int pageSize = 10)
		{
			return _context.Products.OrderBy(p => p.id)
									.Skip((page - 1) * pageSize)
									.Take(pageSize)
									.ToList();
		}

		public List<Image> GetImagesByProductId(int productId)
		{
			return _context.Images.Where(i => i.producId == productId).ToList();
		}
		public ProductDTO GetProductDetail(int productId)
		{
			var product = _context.Products.FirstOrDefault(p => p.id == productId);
			if (product != null)
			{
				var imageUrls = _context.Images.Where(i => i.producId == productId).Select(i => i.url).ToList();
				var productDto = new ProductDTO
				{
					id = product.id,
					name = product.name,
					price= product.price,
					salePercentage= product.salePercentage,
					imageUrl = product.imageUrl,
					status= product.status,
					category= product.category,
					availableSize= product.availableSize,
					availableColor= product.availableColor,
					images = imageUrls
				};
				return productDto;
			}
			return null;
		}

		public ICollection<Product> SearchProduct(string keyword)
		{
			return _context.Products.Where(p => p.name.ToLower().StartsWith(keyword.ToLower())).ToList();
		}

		public ICollection<Product> FilterProductByCategory(string category)
		{
			return _context.Products.Include(p => p.productTags)
									.Where(p => p.category == category)
									.ToList();
		}

		public ICollection<ProductDTO> FilterProductByCategoryAndTag(string category, string tag)
		{
			
			return _context.Products
	.Include(p => p.productTags)
		.ThenInclude(pt => pt.Tag)
	.Where(p => p.category == category &&
				p.productTags.Any(pt => pt.Tag.nameTag == tag))
	.Select(p => new ProductDTO
	{
		id = p.id,
		name = p.name,
		price = p.price,
		imageUrl = p.imageUrl
	})
	.ToList();
		}

		public ICollection<Product> FilterProductByPriceRangeAndTag(float minPrice, float maxPrice, string tag)
		{
			return _context.Products.Include(p => p.productTags)
									.Where(p => p.price >= minPrice && p.price <= maxPrice &&
												p.productTags.Any(pt => pt.Tag.nameTag == tag))
									.ToList();
		}
		/*public ICollection<Product> FilterProductBySizeAndTag(string size, string tag)
		{
			return _context.Products.Include(p => p.productTags)
									.Where(p => p.size == size&& 
									p.productTags.Any(pt => pt.Tag.nameTag == tag))
									.ToList();
		}*/


	}
}
