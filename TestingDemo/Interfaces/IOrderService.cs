using TestingDemo.Models;

namespace TestingDemo.Interfaces
{
    public interface IOrderService
    {
        Order Get(int orderId);
    }
}
