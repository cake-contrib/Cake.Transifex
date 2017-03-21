namespace Cake.Transifex.Tests
{
    using Shouldly;
    using Xunit;

    public class TransifexPullRunnerTests
    {
        private readonly TransifexPullFixture fixture;

        public TransifexPullRunnerTests()
            => fixture = new TransifexPullFixture();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetLanguages(string language)
        {
            this.fixture.Settings = new TransifexPullSettings { Languages = language };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetResources(string resources)
        {
            this.fixture.Settings = new TransifexPullSettings { Resources = resources };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull");
        }

        [Fact]
        public void Evaluate_SetsAllArgumentWhenTrue()
        {
            this.fixture.Settings = new TransifexPullSettings { All = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull --all");
        }

        [Fact]
        public void Evaluate_SetsDisableOverwriteWhenTrue()
        {
            this.fixture.Settings = new TransifexPullSettings { DisableOverwrite = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull --disable-overwrite");
        }

        [Fact]
        public void Evaluate_SetsForceArgumentWhenTrue()
        {
            this.fixture.Settings = new TransifexPullSettings { Force = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull --force");
        }

        [Fact]
        public void Evaluate_SetsLanguagesArgument()
        {
            this.fixture.Settings = new TransifexPullSettings { Languages = "nb_NO*" };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull \"--language=nb_NO*\"");
        }

        [Fact]
        public void Evaluate_SetsMinimumPercWhenNotNull()
        {
            this.fixture.Settings = new TransifexPullSettings { MinimumPercentage = 50 };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull --minimum-perc=50");
        }

        [Theory]
        [InlineData(TransifexMode.Developer)]
        [InlineData(TransifexMode.Reviewed)]
        [InlineData(TransifexMode.Translator)]
        public void Evaluate_SetsModeWhenNotNull(TransifexMode mode)
        {
            var expected = mode.ToString().ToLowerInvariant();
            this.fixture.Settings = new TransifexPullSettings { Mode = mode };

            var result = this.fixture.Run();

            result.Args.ShouldBe($"pull --mode={expected}");
        }

        [Fact]
        public void Evaluate_SetsPseuodArgumentWhenTrue()
        {
            this.fixture.Settings = new TransifexPullSettings { Pseudo = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull --pseudo");
        }

        [Fact]
        public void Evaluate_SetsResourcesArgument()
        {
            this.fixture.Settings = new TransifexPullSettings { Resources = "helloworld*" };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull \"--resources=helloworld*\"");
        }

        [Fact]
        public void Evaluate_SetsSkipArgumentWhenTrue()
        {
            this.fixture.Settings = new TransifexPullSettings { SkipErrors = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull --skip");
        }

        [Fact]
        public void Evaluate_SetsSourceArgumentWhenTrue()
        {
            this.fixture.Settings = new TransifexPullSettings { DownloadSourceFiles = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull --source");
        }

        [Fact]
        public void Evaluate_SetsStatusAsCommandToArgumentBuilder()
        {
            this.fixture.Settings = null;

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull");
        }

        [Fact]
        public void Evaluate_SetsXLiffArgumentWhenTrue()
        {
            this.fixture.Settings = new TransifexPullSettings { UseXliff = true };

            var result = this.fixture.Run();

            result.Args.ShouldBe("pull --xliff");
        }
    }
}
