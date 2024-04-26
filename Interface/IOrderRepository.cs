using ShopApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApplication.Interface
{
    public interface IOrderRepository
    {
        Task<Order> Checkout(Order Check);

		Task<List<Order>> GetAllOrders();
    }
}

