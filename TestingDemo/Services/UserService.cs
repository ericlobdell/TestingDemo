using System;
using TestingDemo.Interfaces;
using TestingDemo.Models;

namespace TestingDemo.Services
{
    public class UserService : IUserService
    {
        IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User ChangeName(int userId, string firstName, string lastName = "")
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name required");

            var user = _userRepository.Get(userId);

            if (user == null)
                throw new InvalidOperationException($"User not found with id {userId}");

            return new User(firstName, lastName);
        }

        public User Get(int userId) =>
            _userRepository.Get(userId);
    }
}
