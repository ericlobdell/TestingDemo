using TestingDemo.Interfaces;
using TestingDemo.Models;

namespace TestingDemo.Tests.mocks
{
    public class MockUserService : MockServiceBase<User>, IUserService
    {
        
    }
}
