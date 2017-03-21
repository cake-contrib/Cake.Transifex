namespace Cake.Transifex.Tests
{
    using Shouldly;
    using Xunit;

    public class TransifexStatusRunnerTests
    {
        private readonly TransifexStatusFixture fixture;

        public TransifexStatusRunnerTests()
            => fixture = new TransifexStatusFixture();

        [Fact]
        public void Evaluate_SetsStatusAsCommandToArgumentBuilder()
        {
            this.fixture.Resources = null;

            var result = this.fixture.Run();

            result.Args.ShouldBe("status");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetResources(string resources)
        {
            this.fixture.Resources = resources;

            var result = this.fixture.Run();

            result.Args.ShouldBe("status");
        }

        [Fact]
        public void Evaluate_SetsResourcesArgument()
        {
            this.fixture.Resources = "helloworld*";

            var result = this.fixture.Run();

            result.Args.ShouldBe("status \"--resources=helloworld*\"");
        }
    }
}
