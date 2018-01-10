using TestingDemo.Models;

namespace TestingDemo.Tests.mocks
{
    public class MockEntities
    {
        public static User User => new User("Test", "User");
        public static Order Order => new Order(1);
    }
}
