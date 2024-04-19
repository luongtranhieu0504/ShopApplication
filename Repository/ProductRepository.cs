using ShopApplication.Models;
using ShopApplication.Interface;

using System.Data;
using ShopApplication.Data;
using Microsoft.EntityFrameworkCore;

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

		public Product GetProductDetail(int productId)
		{
			return _context.Products.Include(p => p.images).Include(p => p.comments)
									.FirstOrDefault(p => p.id == productId);
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

		public ICollection<Product> FilterProductByCategoryAndTag(string category, string tag)
		{
			return _context.Products.Include(p => p.productTags)
									.Where(p => p.category == category &&
												p.productTags.Any(pt => pt.Tag.nameTag == tag))
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
