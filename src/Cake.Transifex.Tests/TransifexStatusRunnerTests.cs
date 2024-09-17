namespace Cake.Transifex.Tests
{
    using FluentAssertions;
    using System;
    using Xunit;

    [Obsolete("Will be removed in v4")]
    public class TransifexStatusRunnerTests
    {
        private readonly TransifexStatusFixture _fixture;

        public TransifexStatusRunnerTests()
        {
            _fixture = new TransifexStatusFixture();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetResources(string resources)
        {
            _fixture.Resources = resources;

            var result = _fixture.Run();

            result.Args.Should().Be("status");
        }

        [Fact]
        public void Evaluate_SetsResourcesArgument()
        {
            _fixture.Resources = "helloworld*";

            var result = _fixture.Run();

            result.Args.Should().Be("status --resources \"helloworld*\"");
        }

        [Fact]
        public void Evaluate_SetsStatusAsCommandToArgumentBuilder()
        {
            _fixture.Resources = null;

            var result = _fixture.Run();

            result.Args.Should().Be("status");
        }
    }
}
