namespace Cake.Transifex.Tests
{
    using Shouldly;
    using Xunit;

    public class TransifexPushRunnerTests
    {
        private readonly TransifexPushFixture _fixture;

        public TransifexPushRunnerTests()
        {
            _fixture = new TransifexPushFixture();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetLanguages(string language)
        {
            _fixture.Settings = new TransifexPushSettings { Languages = language };

            var result = _fixture.Run();

            result.Args.ShouldBe("push");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Evaluate_DoesNotSetResources(string resources)
        {
            _fixture.Settings = new TransifexPushSettings { Resources = resources };

            var result = _fixture.Run();

            result.Args.ShouldBe("push");
        }

        [Fact]
        public void Evaluate_SetsForceArgumentWhenTrue()
        {
            _fixture.Settings = new TransifexPushSettings { Force = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --force");
        }

        [Fact]
        public void Evaluate_SetsLanguagesArgument()
        {
            _fixture.Settings = new TransifexPushSettings { Languages = "nb_NO*" };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --language \"nb_NO*\"");
        }

        [Fact]
        public void Evaluate_SetsNoInteractiveWhenTrue()
        {
            _fixture.Settings = new TransifexPushSettings { NoInteractive = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --no-interactive");
        }

        [Fact]
        public void Evaluate_SetsResourcesArgument()
        {
            _fixture.Settings = new TransifexPushSettings { Resources = "helloworld*" };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --resources \"helloworld*\"");
        }

        [Fact]
        public void Evaluate_SetsSkipArgumentWhenTrue()
        {
            _fixture.Settings = new TransifexPushSettings { SkipErrors = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --skip");
        }

        [Fact]
        public void Evaluate_SetsSourceWhenUploadSourceFilesIsTrue()
        {
            _fixture.Settings = new TransifexPushSettings { UploadSourceFiles = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --source");
        }

        [Fact]
        public void Evaluate_SetsStatusAsCommandToArgumentBuilder()
        {
            _fixture.Settings = null;

            var result = _fixture.Run();

            result.Args.ShouldBe("push");
        }

        [Fact]
        public void Evaluate_SetsTranslationsWhenUploadTranslationsIsTrue()
        {
            _fixture.Settings = new TransifexPushSettings { UploadTranslations = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --translations");
        }

        [Fact]
        public void Evaluate_SetsXLiffArgumentWhenTrue()
        {
            _fixture.Settings = new TransifexPushSettings { UseXliff = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --xliff");
        }

        [Fact]
        public void Evaluate_SetsParallelWhenTrue()
        {
            _fixture.Settings = new TransifexPushSettings { Parallel = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --parallel");
        }

        [Fact]
        public void Evaluate_DoesNotSetParallelWhenFalse()
        {
            _fixture.Settings = new TransifexPushSettings { Parallel = false };

            var result = _fixture.Run();

            result.Args.ShouldBe("push");
        }

        [Theory]
        [InlineData("master")]
        [InlineData("develop")]
        [InlineData("feature/branch-argument")]
        public void Evaluate_SetsBranchArgument(string branch)
        {
            _fixture.Settings = new TransifexPushSettings { Branch = branch };

            var result = _fixture.Run();

            result.Args.ShouldBe($"push --branch {branch}");
        }

        [Fact]
        public void Evaluate_SetsGitTimestampsWhenTrue()
        {
            _fixture.Settings = new TransifexPushSettings { UseGitTimestamps = true };

            var result = _fixture.Run();

            result.Args.ShouldBe("push --use-git-timestamps");
        }

        [Fact]
        public void Evaluate_DoesNotSetGitTimestampsWhenFalse()
        {
            _fixture.Settings = new TransifexPushSettings { UseGitTimestamps = false };

            var result = _fixture.Run();

            result.Args.ShouldBe("push");
        }
    }
}
