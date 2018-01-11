using TestingDemo.Interfaces;
using TestingDemo.Models;

namespace TestingDemo.Tests.mocks
{
    public class MockUserRepository : MockServiceBase<User>, IRepository<User>
    {

    }
}
