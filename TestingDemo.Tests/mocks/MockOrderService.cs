using TestingDemo.Interfaces;
using TestingDemo.Models;

namespace TestingDemo.Tests.mocks
{
    public class MockOrderService : MockServiceBase<Order>, IOrderService
    {
        public Order Get(int orderId)
        {
            return MockEntities.Order;
        }
    }
}
