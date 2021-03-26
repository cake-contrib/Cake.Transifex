namespace Cake.Transifex.Tests
{
    using Shouldly;
    using Xunit;

    public class TransifexRunnerAlisesTests
    {
        private readonly TransifexAliasesInitFixture _initFixture;
        private readonly TransifexAliasesPullFixture _pullFixture;
        private readonly TransifexAliasesPushFixture _pushFixture;
        private readonly TransifexAliasesStatusFixture _statusFixture;

        public TransifexRunnerAlisesTests()
        {
            _statusFixture = new TransifexAliasesStatusFixture();
            _pullFixture = new TransifexAliasesPullFixture();
            _pushFixture = new TransifexAliasesPushFixture();
            _initFixture = new TransifexAliasesInitFixture();
        }

        [Fact]
        public void TransifexInit_ShouldJustCallTxInitWithDefaultHost()
        {
            _initFixture.Settings = null;

            var result = _initFixture.Run();

            result.Args.ShouldBe("init --host www.transifex.com");
        }

        [Fact]
        public void TransifexInitWithArguments_ShouldUsePassedSettings()
        {
            _initFixture.Settings = new TransifexInitSettings { Token = "MEGA-TOKEN", Host = "cakebuild.net" };

            var result = _initFixture.Run();

            result.Args.ShouldContain("init");
            result.Args.ShouldContain("--host cakebuild.net");
            result.Args.ShouldContain("--token MEGA-TOKEN");
        }

        [Fact]
        public void TransifexPull_ShouldJustCallTxPull()
        {
            _pullFixture.Settings = null;

            var result = _pullFixture.Run();

            result.Args.ShouldBe("pull");
        }

        [Fact]
        public void TransifexPullWithArguments_ShouldUsePassedSettings()
        {
            _pullFixture.Settings = new TransifexPullSettings { All = true, Mode = TransifexMode.Reviewed };

            var result = _pullFixture.Run();

            result.Args.ShouldContain("pull");
            result.Args.ShouldContain("--all");
            result.Args.ShouldContain("--mode reviewed");
        }

        [Fact]
        public void TransifexPush_ShouldJustCallTxPush()
        {
            _pushFixture.Settings = null;

            var result = _pushFixture.Run();

            result.Args.ShouldBe("push");
        }

        [Fact]
        public void TransifexPushWithSettings_ShouldUsePassedSettings()
        {
            _pushFixture.Settings = new TransifexPushSettings { UploadSourceFiles = true, UploadTranslations = true };

            var result = _pushFixture.Run();

            result.Args.ShouldContain("push");
            result.Args.ShouldContain("--source");
            result.Args.ShouldContain("--translations");
        }

        [Fact]
        public void TransifexStatus_ShouldJustCallTxStatus()
        {
            _statusFixture.Resources = null;

            var result = _statusFixture.Run();

            result.Args.ShouldBe("status");
        }

        [Fact]
        public void TransifexStatusWithSettings_ShouldPassUsedResources()
        {
            _statusFixture.Resources = "test.resource";

            var result = _statusFixture.Run();

            result.Args.ShouldBe("status --resources test.resource");
        }
    }
}
