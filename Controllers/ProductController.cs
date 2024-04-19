using Microsoft.AspNetCore.Mvc;
using ShopApplication.Models;
using ShopApplication.Interface;
using ShopApplication.Data;
using AutoMapper;

namespace ShopApplication.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
	
		public ProductController(IProductRepository productRepository) { 
			_productRepository = productRepository;
		}



		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
		public IActionResult GetProduct(int page = 1, int pageSize = 10)
		{
			var product = _productRepository.GetProduct(page, pageSize);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(product);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200, Type = typeof(Product))]
		public IActionResult GetProductDetail(int id)
		{
			var product = _productRepository.GetProductDetail(id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpGet("search")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
		public IActionResult SearchProduct(string keyword)
		{
			if (string.IsNullOrEmpty(keyword))
			{
				return BadRequest("Keyword cannot be empty.");
			}

			var products = _productRepository.SearchProduct(keyword);
			return Ok(products);
		}

		[HttpGet("filter_category")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
		public IActionResult FilterProductByCategoryAndTag(string category, string tag)
		{
			if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(tag))
			{
				return BadRequest("Category and tag cannot be empty.");
			}

			var products = _productRepository.FilterProductByCategoryAndTag(category, tag);
			return Ok(products);
		}

		[HttpGet("filter_price")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
		public IActionResult FilterProductByPriceRangeAndTag(float minPrice, float maxPrice, string tag)
		{
			if (string.IsNullOrEmpty(tag))
			{
				return BadRequest("Tag cannot be empty.");
			}

			var products = _productRepository.FilterProductByPriceRangeAndTag(minPrice, maxPrice, tag);
			return Ok(products);
		}

		/*[HttpGet("filter_size")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
		public IActionResult FilterProductBySizeAndTag(string size, string tag)
		{
			if (string.IsNullOrEmpty(tag) || string.IsNullOrEmpty(size))
			{
				return BadRequest("Tag and size cannot be empty.");
			}

			var products = _productRepository.FilterProductBySizeAndTag(size, tag);
			return Ok(products);
		}*/








	}
}
