using Microsoft.AspNetCore.Mvc;
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

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<Order>> Checkout(Order order)
        {
            try
            {
                return CreatedAtAction(nameof(GetOrders), new { id = (await _orderRepository.Checkout(order)).Id }, await _orderRepository.Checkout(order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}