using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Interface;
using ShopApplication.Models;

namespace ShopApplication.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> Checkout(Order Check)
        {
            if (string.IsNullOrEmpty(Check.fullName) || string.IsNullOrEmpty(Check.email) || string.IsNullOrEmpty(Check.phone) || string.IsNullOrEmpty(Check.city) || string.IsNullOrEmpty(Check.region))
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin.");
            }
            _context.Orders.Add(Check);
            await _context.SaveChangesAsync();

            return Check;
        }
    }



}



