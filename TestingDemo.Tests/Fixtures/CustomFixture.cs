using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.Xunit2;
using TestingDemo.Models;

namespace TestingDemo.Tests.Fixtures
{
    public class CustomFixture : Fixture
    {
        public CustomFixture()
        {
            this.Customize(new AutoFakeItEasyCustomization());

            Customize<User>(_ =>
                _.FromFactory(() => new User("Eric", "Lobdell")));
        }
    }

    public class CustomAutoData : AutoDataAttribute
    {
        public CustomAutoData()
            : base(() => new CustomFixture()) { }
    }
}
