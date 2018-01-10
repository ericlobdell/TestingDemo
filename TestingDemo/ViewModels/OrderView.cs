using TestingDemo.Models;

namespace TestingDemo.ViewModels
{
    public class OrderView
    {
        public Order Order { get; }
        public User User { get; }

        public OrderView(Order order, User user)
        {
            Order = order;
            User = user;
        }
    }
}
