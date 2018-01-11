using TestingDemo.Models;

namespace TestingDemo.Interfaces
{
    public interface IUserService
    {
        User Get(int userId);
        User ChangeName(int userId, string firstName, string lastName);
    }
}
