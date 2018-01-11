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

        [Fact]
        public void ChangeName_returns_null_when_save_fails()
        {
            var firstName = "Rosco P.";
            var lastName = "Coltrane";

            _userRepository.ThrowOnSave = true;

            var sut = new UserService(_userRepository);
            var result = sut.ChangeName(MockEntities.User.Id, firstName, lastName);

            Assert.Null(result);
        }

        [Fact]
        public void ChangeName_returns_user_with_updated_name_when_valid()
        {
            var firstName = "Rosco P.";
            var lastName = "Coltrane";

            var sut = new UserService(_userRepository);
            var result = sut.ChangeName(MockEntities.User.Id, firstName, lastName);

            Assert.Equal(MockEntities.User.Id, result.Id);
            Assert.Equal(firstName, result.FirstName);
            Assert.Equal(lastName, result.LastName);
        }
    }
}
