using AutoFixture.Xunit2;
using FakeItEasy;
using SemanticComparison;
using System;
using TestingDemo.Interfaces;
using TestingDemo.Models;
using TestingDemo.Services;
using TestingDemo.Tests.Fixtures;
using Xunit;

namespace TestingDemo.Tests
{
    public class UserServiceTests
    {
         [Theory, CustomAutoData]
        public void ChangeName_requires_first_name([Frozen]IRepository<User> userRepository, int userId, string validLastName)
        {
            var invalidFirstName = string.Empty;

            var sut = new UserService(userRepository);
            var ex = Assert.Throws<ArgumentException>(() => sut.ChangeName(userId, invalidFirstName, validLastName));

            Assert.Contains("First name required", ex.Message);
        }

         [Theory, CustomAutoData]
        public void ChangeName_does_not_call_repo_if_when_first_name_omitted([Frozen]IRepository<User> userRepository, int userId, string validLastName)
        {
            var invalidFirstName = string.Empty;

            var sut = new UserService(userRepository);
            var ex = Assert.Throws<ArgumentException>(() => sut.ChangeName(userId, invalidFirstName, validLastName));

            A.CallTo(() => userRepository.Get(userId))
                .MustNotHaveHappened();
        }

         [Theory, CustomAutoData]
        public void ChangeName_returns_null_when_save_fails([Frozen]IRepository<User> userRepository, User user)
        {
            A.CallTo(() => userRepository.Save(A<User>.That.Matches( u => u.Id == user.Id)))
                .Throws(() => new Exception("egads!"));

            var sut = new UserService(userRepository);
            var result = sut.ChangeName(user.Id, user.FirstName, user.LastName);

            Assert.Null(result);
        }

         [Theory, CustomAutoData]
        public void ChangeName_returns_user_with_updated_name_when_valid([Frozen]IRepository<User> userRepository, User user, string newFirstName, string newLastName)
        {
            var sut = new UserService(userRepository);
            var result = sut.ChangeName(user.Id, newFirstName, newLastName);

            var expected = new User(newFirstName, newLastName, user.Id);
            var likeness = new Likeness<User, User>(expected);

            likeness.ShouldEqual(result);
        }
    }
}
