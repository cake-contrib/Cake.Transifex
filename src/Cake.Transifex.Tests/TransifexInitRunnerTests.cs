namespace Cake.Transifex.Tests
{
    using System;
    using Shouldly;
    using Xunit;

    public class TransifexInitRunnerTests
    {
        private readonly TransifexInitFixture fixture;

        public TransifexInitRunnerTests()
            => this.fixture = new TransifexInitFixture();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Evaluate_DoesNotSetHostWhenNullOrEmpty(string host)
        {
            this.fixture.Settings = new TransifexInitSettings { Host = host };

            var result = this.fixture.Run();

            result.Args.ShouldBe("init");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("YUP", null)]
        [InlineData(null, "SECRET-PASSWORD")]
        [InlineData("", "")]
        [InlineData("MY-USERNAME", "")]
        [InlineData("", "SECRET-PASSWORD")]
        public void Evaluate_DoesNotSetUserNameAndPasswordWhenEitherIsEmpty(string userName, string password)
        {
            this.fixture.Settings = new TransifexInitSettings { Username = userName, Password = password };

            var result = this.fixture.Run();

            result.Args.ShouldBe("init --host www.transifex.com");
        }

        [Fact]
        public void Evaluate_SetHostByDefault()
        {
            this.fixture.Settings = null;

            var result = this.fixture.Run();

            result.Args.ShouldBe("init --host www.transifex.com");
        }

        [Fact]
        public void Evaluate_SetsTokenWhenOneIsSpecified()
        {
            const string token = "MY-AWESOME-TOKEN";
            this.fixture.Settings = new TransifexInitSettings { Token = token };

            var result = this.fixture.Run();

            result.Args.ShouldBe("init --host www.transifex.com --token " + token);
        }

        [Fact]
        public void Evaluate_SetsUserNameAndPassword()
        {
            const string userName = "My-Awesome-Username";
            const string password = "My-Super-Awesome-Secret-Password";
            this.fixture.Settings = new TransifexInitSettings { Username = userName, Password = password };

            var result = this.fixture.Run();

            result.Args.ShouldBe($"init --host www.transifex.com --user {userName} --pass \"{password}\"");
        }

        [Theory]
        [InlineData("token", "userName", null)]
        [InlineData("token", null, "password")]
        [InlineData("token", "userName", "")]
        [InlineData("token", "", "password")]
        [InlineData("token", "userName", "password")]
        public void Evaluate_ThrowsArgumentExceptionWhenTokenAndUsernameOrPasswordIsSpecified(string token, string userName, string password)
        {
            this.fixture.Settings = new TransifexInitSettings { Token = token, Username = userName, Password = password };

            var ex = Assert.Throws<ArgumentException>(() => this.fixture.Run());

            Assert.Equal(ex.Message, "A token can not be set at the same time as either the username or password.");
        }
    }
}
