using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopApplication.DTO;
using ShopApplication.Interface;
using ShopApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ;
			_mapper = mapper ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return Ok(orders);
        }

		[HttpPost("checkout")]
		public async Task<IActionResult> Checkout([FromBody] OrderDTO orderDTO)
		{
			try
			{
				// Sử dụng AutoMapper để ánh xạ dữ liệu từ OrderDTO sang Order
				var order = _mapper.Map<Order>(orderDTO);

				// Gọi phương thức trong repository để thêm Order vào cơ sở dữ liệu
				var newOrder = await _orderRepository.Checkout(order);

				return Ok(newOrder);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while processing checkout", error = ex.Message });
			}
		}

	}
}