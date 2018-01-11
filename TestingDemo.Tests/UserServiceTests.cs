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
            var invalidFirstName = string.Empty;
            var validLastName = "nont empty";

            var sut = new UserService(_userRepository);
            var ex = Assert.Throws<ArgumentException>(() => sut.ChangeName(MockEntities.User.Id, invalidFirstName, validLastName));

            Assert.Contains("First name required", ex.Message);
        }

        [Fact]
        public void ChangeName_does_not_call_repo_if_when_first_name_omitted()
        {
            var invalidFirstName = string.Empty;
            var validLastName = "not empty";

            var sut = new UserService(_userRepository);
            var ex = Assert.Throws<ArgumentException>(() => sut.ChangeName(MockEntities.User.Id, invalidFirstName, validLastName));

            Assert.False(_userRepository.GetWasCalled);
        }

        [Fact]
        public void ChangeName_returns_null_when_save_fails()
        {
            var validFirstName = "Rosco P.";
            var validLastName = "Coltrane";

            _userRepository.ThrowOnSave = true;

            var sut = new UserService(_userRepository);
            var result = sut.ChangeName(MockEntities.User.Id, validFirstName, validLastName);

            Assert.Null(result);
        }

        [Fact]
        public void ChangeName_returns_user_with_updated_name_when_valid()
        {
            var validFirstName = "Boss";
            var validLastName = "Hogg";

            var sut = new UserService(_userRepository);
            var result = sut.ChangeName(MockEntities.User.Id, validFirstName, validLastName);

            Assert.Equal(MockEntities.User.Id, result.Id);
            Assert.Equal(validFirstName, result.FirstName);
            Assert.Equal(validLastName, result.LastName);
        }
    }
}
