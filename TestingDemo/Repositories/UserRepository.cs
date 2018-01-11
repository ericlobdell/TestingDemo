using TestingDemo.Interfaces;
using TestingDemo.Models;

namespace TestingDemo.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public User Get(int id) => User.Demo;

        public void Save(User entity)
        {
            // noop
        }
    }
}
