using AutoFixture.Xunit2;
using FakeItEasy;
using TestingDemo.Factories;
using TestingDemo.Interfaces;
using TestingDemo.Models;
using TestingDemo.Tests.Fixtures;
using Xunit;

namespace TestingDemo.Tests
{
    public class OrderViewFactoryTests
    {
        [Theory, CustomAutoData]
        public void Create_calls_order_service_with_id([Frozen]IUserService userService, [Frozen]IOrderService orderService, int orderId)
        {
            var sut = new OrderViewFactory(orderService, userService);

            var result = sut.Create(orderId);

            A.CallTo(() => orderService.Get(orderId))
                .MustHaveHappened();
        }

        [Theory, CustomAutoData]
        public void Create_calls_user_service_with_id([Frozen]IUserService userService, [Frozen]IOrderService orderService, Order order)
        {
            A.CallTo(() => orderService.Get(order.Id))
                .Returns(order);

            var sut = new OrderViewFactory(orderService, userService);
            var result = sut.Create(order.Id);

            A.CallTo(() => orderService.Get(order.Id))
                .MustHaveHappened();
        }

        [Theory, CustomAutoData]
        public void Create_maps_user_to_view([Frozen]IUserService userService, [Frozen]IOrderService orderService, Order order, User user)
        {
            A.CallTo(() => orderService.Get(order.Id))
                .Returns(order);

            A.CallTo(() => userService.Get(order.UserId))
                .Returns(user);

            var sut = new OrderViewFactory(orderService, userService);
            var result = sut.Create(order.Id);

            Assert.Equal(user.FirstName, result.User.FirstName);
        }
    }
}
