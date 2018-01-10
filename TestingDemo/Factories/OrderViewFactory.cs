using TestingDemo.Interfaces;
using TestingDemo.ViewModels;

namespace TestingDemo.Factories
{
    public class OrderViewFactory
    {
        private IOrderService _orderService;
        private IUserService _userService;

        public OrderViewFactory(IOrderService orderSrevice, IUserService userService)
        {
            _orderService = orderSrevice;
            _userService = userService;
        }

        public OrderView Create(int orderId)
        {
            var order = _orderService.Get(orderId);
            var user = _userService.Get(order.UserId);

            return new OrderView(order, user);
        }
    }
}
