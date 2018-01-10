using TestingDemo.Factories;
using TestingDemo.Models;
using TestingDemo.Tests.mocks;
using Xunit;

namespace TestingDemo.Tests
{
    public class OrderViewFactoryTests
    {
        MockUserService _userService;
        MockOrderService _orderService;

        public OrderViewFactoryTests()
        {
            _userService = new MockUserService();
            _orderService = new MockOrderService();
        }

        [Fact]
        public void Create_calls_order_service_with_id()
        {
            var orderId = 1;
            var sut = new OrderViewFactory(_orderService, _userService);

            var result = sut.Create(orderId);

            Assert.True(_orderService.GetWasCalledWith(orderId));
        }

        [Fact]
        public void Create_calls_user_service_with_id()
        {
            var orderId = 1;
            var userId = 3;
            var order = new Order(userId);

            _orderService.GetReturns(order);

            var sut = new OrderViewFactory(_orderService, _userService);
            var result = sut.Create(orderId);

            Assert.True(_userService.GetWasCalledWith(userId));
        }

        [Fact]
        public void Create_gets_correct_user()
        {
            var orderId = 1;
            var firstName = "Jim";
            var lastName = "Smith";
            var user = new User(firstName, lastName);

            _userService.GetReturns(user);

            var sut = new OrderViewFactory(_orderService, _userService);
            var result = sut.Create(orderId);

            Assert.Equal(firstName, result.User.FirstName);
        }
    }
}
