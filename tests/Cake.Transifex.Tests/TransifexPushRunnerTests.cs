namespace Cake.Transifex.Tests
{
    using Shouldly;
    using Xunit;

    public class TransifexPushRunnerTests
    {
        private readonly TransifexPushFixture fixture;

        public TransifexPushRunnerTests()
        {
            fixture = new TransifexPushFixture();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetLanguages(string language)
        {
            this.fixture.Settings = new TransifexPushSettings { Languages = language };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetResources(string resources)
        {
            this.fixture.Settings = new TransifexPushSettings { Resources = resources };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push");
        }

        [Fact]
        public void Evaluate_SetsForceArgumentWhenTrue()
        {
            this.fixture.Settings = new TransifexPushSettings { Force = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push --force");
        }

        [Fact]
        public void Evaluate_SetsLanguagesArgument()
        {
            this.fixture.Settings = new TransifexPushSettings { Languages = "nb_NO*" };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push \"--language=nb_NO*\"");
        }

        [Fact]
        public void Evaluate_SetsNoInteractiveWhenTrue()
        {
            this.fixture.Settings = new TransifexPushSettings { NoInteractive = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push --no-interactive");
        }

        [Fact]
        public void Evaluate_SetsResourcesArgument()
        {
            this.fixture.Settings = new TransifexPushSettings { Resources = "helloworld*" };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push \"--resources=helloworld*\"");
        }

        [Fact]
        public void Evaluate_SetsSkipArgumentWhenTrue()
        {
            this.fixture.Settings = new TransifexPushSettings { SkipErrors = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push --skip");
        }

        [Fact]
        public void Evaluate_SetsSourceWhenUploadSourceFilesIsTrue()
        {
            this.fixture.Settings = new TransifexPushSettings { UploadSourceFiles = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push --source");
        }

        [Fact]
        public void Evaluate_SetsStatusAsCommandToArgumentBuilder()
        {
            this.fixture.Settings = null;

            var result = this.fixture.Run();

            result.Args.ShouldBe("push");
        }

        [Fact]
        public void Evaluate_SetsTranslationsWhenUploadTranslationsIsTrue()
        {
            this.fixture.Settings = new TransifexPushSettings { UploadTranslations = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push --translations");
        }

        [Fact]
        public void Evaluate_SetsXLiffArgumentWhenTrue()
        {
            this.fixture.Settings = new TransifexPushSettings { UseXliff = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("push --xliff");
        }
    }
}
