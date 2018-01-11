using System;
using TestingDemo.Services;
using TestingDemo.Tests.mocks;
using Xunit;

namespace TestingDemo.Tests
{
    public class UserServiceTests
    {
        MockUserRepository _userRepository;

        public UserServiceTests()
        {
            _userRepository = new MockUserRepository();
        }

        [Fact]
        public void ChangeName_requires_first_name()
        {
            var firstName = string.Empty;
            var lastName = "nont empty";

            var sut = new UserService(_userRepository);
            var ex = Assert.Throws<ArgumentException>(() => sut.ChangeName(MockEntities.User.Id, firstName, lastName));

            Assert.Contains("First name required", ex.Message);
        }

        [Fact]
        public void ChangeName_does_not_call_repo_if_when_first_name_omitted()
        {
            var firstName = string.Empty;
            var lastName = "nont empty";

            var sut = new UserService(_userRepository);
            var ex = Assert.Throws<ArgumentException>(() => sut.ChangeName(MockEntities.User.Id, firstName, lastName));

            Assert.False(_userRepository.GetWasCalled);
        }


    }
}
