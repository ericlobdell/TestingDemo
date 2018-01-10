using TestingDemo.Interfaces;
using TestingDemo.Models;

namespace TestingDemo.Services
{
    public class OrderService : IOrderService
    {
        public Order Get(int orderId)
        {
            // calls real repository
            return new Order(orderId);
        }
    }
}
