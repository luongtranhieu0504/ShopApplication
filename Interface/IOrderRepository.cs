using ShopApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApplication.Interface
{
    public interface IOrderRepository
    {
        Task Checkout(Order order);
        Task<List<Order>> GetAllOrders();
    }
}

