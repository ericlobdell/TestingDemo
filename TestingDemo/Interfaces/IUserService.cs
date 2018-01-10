using TestingDemo.Models;

namespace TestingDemo.Interfaces
{
    public interface IUserService
    {
        User Get(int userId);
    }
}
