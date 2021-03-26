namespace Cake.Transifex.Tests
{
    using Shouldly;
    using Xunit;

    public class TransifexPullRunnerTests
    {
        private readonly TransifexPullFixture _fixture;

        public TransifexPullRunnerTests()
        {
            _fixture = new TransifexPullFixture();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetLanguages(string language)
        {
            _fixture.Settings = new TransifexPullSettings { Languages = language };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetResources(string resources)
        {
            _fixture.Settings = new TransifexPullSettings { Resources = resources };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull");
        }

        [Fact]
        public void Evaluate_SetsAllArgumentWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { All = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --all");
        }

        [Fact]
        public void Evaluate_SetsDisableOverwriteWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { DisableOverwrite = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --disable-overwrite");
        }

        [Fact]
        public void Evaluate_SetsForceArgumentWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { Force = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --force");
        }

        [Fact]
        public void Evaluate_SetsLanguagesArgument()
        {
            _fixture.Settings = new TransifexPullSettings { Languages = "nb_NO*" };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --language \"nb_NO*\"");
        }

        [Fact]
        public void Evaluate_SetsMinimumPercWhenNotNull()
        {
            _fixture.Settings = new TransifexPullSettings { MinimumPercentage = 50 };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --minimum-perc 50");
        }

        [Theory]
        [InlineData(TransifexMode.Developer)]
        [InlineData(TransifexMode.Reviewed)]
        [InlineData(TransifexMode.Translator)]
        [InlineData(TransifexMode.OnlyTranslated)]
        [InlineData(TransifexMode.OnlyReviewed)]
        [InlineData(TransifexMode.SourceAsTranslation)]
        public void Evaluate_SetsModeWhenNotNull(TransifexMode mode)
        {
            var expected = mode.ToString().ToLowerInvariant();
            _fixture.Settings = new TransifexPullSettings { Mode = mode };

            var result = _fixture.Run();

            result.Args.ShouldBe($"pull --mode {expected}");
        }

        [Fact]
        public void Evaluate_SetsPseuodArgumentWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { Pseudo = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --pseudo");
        }

        [Fact]
        public void Evaluate_SetsResourcesArgument()
        {
            _fixture.Settings = new TransifexPullSettings { Resources = "helloworld*" };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --resources \"helloworld*\"");
        }

        [Fact]
        public void Evaluate_SetsSkipArgumentWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { SkipErrors = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --skip");
        }

        [Fact]
        public void Evaluate_SetsSourceArgumentWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { DownloadSourceFiles = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --source");
        }

        [Fact]
        public void Evaluate_SetsStatusAsCommandToArgumentBuilder()
        {
            _fixture.Settings = null;

            var result = _fixture.Run();

            result.Args.ShouldBe("pull");
        }

        [Fact]
        public void Evaluate_SetsXLiffArgumentWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { UseXliff = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --xliff");
        }

        [Fact]
        public void Evaluate_SetsNoInteractiveWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { NoInteractive = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --no-interactive");
        }

        [Fact]
        public void Evaluate_SetsParallelWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { Parallel = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --parallel");
        }

        [Fact]
        public void Evaluate_DoesNotSetParallelWhenFalse()
        {
            _fixture.Settings = new TransifexPullSettings { Parallel = false };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull");
        }

        [Theory]
        [InlineData("master")]
        [InlineData("develop")]
        [InlineData("feature/branch-argument")]
        public void Evaluate_SetsBranchArgument(string branch)
        {
            _fixture.Settings = new TransifexPullSettings { Branch = branch };

            var result = _fixture.Run();

            result.Args.ShouldBe($"pull --branch {branch}");
        }

        [Fact]
        public void Evaluate_SetsGitTimestampsWhenTrue()
        {
            _fixture.Settings = new TransifexPullSettings { UseGitTimestamps = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull --use-git-timestamps");
        }

        [Fact]
        public void Evaluate_DoesNotSetGitTimestampsWhenFalse()
        {
            _fixture.Settings = new TransifexPullSettings { UseGitTimestamps = false };

            var result = _fixture.Run();

            result.Args.ShouldBe("pull");
        }
    }
}
