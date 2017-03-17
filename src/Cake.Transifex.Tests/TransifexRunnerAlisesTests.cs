namespace Cake.Transifex.Tests
{
    using Shouldly;
    using Xunit;

    public class TransifexRunnerAlisesTests
    {
        private readonly TransifexAliasesPullFixture _pullFixture;
        private readonly TransifexAliasesPushFixture _pushFixture;
        private readonly TransifexAliasesStatusFixture _statusFixture;

        public TransifexRunnerAlisesTests()
        {
            _statusFixture = new TransifexAliasesStatusFixture();
            _pullFixture = new TransifexAliasesPullFixture();
            _pushFixture = new TransifexAliasesPushFixture();
        }

        [Fact]
        public void TransifexPull_ShouldJustCallTxPull()
        {
            this._pullFixture.Settings = null;

            var result = this._pullFixture.Run();

            result.Args.ShouldBe("pull");
        }

        [Fact]
        public void TransifexPullWithArguments_ShouldUsePassedSettings()
        {
            this._pullFixture.Settings = new TransifexPullSettings { All = true, Mode = TransifexMode.Reviewed };

            var result = this._pullFixture.Run();

            result.Args.ShouldContain("pull");
            result.Args.ShouldContain("--all");
            result.Args.ShouldContain("--mode=reviewed");
        }

        [Fact]
        public void TransifexPush_ShouldJustCallTxPush()
        {
            this._pushFixture.Settings = null;

            var result = this._pushFixture.Run();

            result.Args.ShouldBe("push");
        }

        [Fact]
        public void TransifexPushWithSettings_ShouldUsePassedSettings()
        {
            this._pushFixture.Settings = new TransifexPushSettings { UploadSourceFiles = true, UploadTranslations = true };

            var result = this._pushFixture.Run();

            result.Args.ShouldContain("push");
            result.Args.ShouldContain("--source");
            result.Args.ShouldContain("--translations");
        }

        [Fact]
        public void TransifexStatus_ShouldJustCallTxStatus()
        {
            this._statusFixture.Resources = null;

            var result = this._statusFixture.Run();

            result.Args.ShouldBe("status");
        }

        [Fact]
        public void TransifexStatusWithSettings_ShouldPassUsedResources()
        {
            this._statusFixture.Resources = "test.resource";

            var result = this._statusFixture.Run();

            result.Args.ShouldBe("status \"--resources=test.resource\"");
        }
    }
}
