using TestingDemo.Interfaces;
using TestingDemo.Models;

namespace TestingDemo.Services
{
    public class UserService : IUserService
    {
        public User Get(int userId)
        {
            // calls real repository
            return new User("","");
        }
    }
}
