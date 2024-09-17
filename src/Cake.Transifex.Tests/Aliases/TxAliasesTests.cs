namespace Cake.Transifex.Tests.Aliases;

using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
using Cake.Testing.Fixtures;
using Cake.Transifex.Aliases;
using Cake.Transifex.Settings;
using FluentAssertions;
using NSubstitute;
using Xunit;

public class TxAliasesTests
{
    [Fact]
    public void Init_ShouldRunFixtureNoSettings()
    {
        var fixture = new TxAliasesFixture<TxInitSettings>();

        var result = fixture.TxInit(null);

        _ = result.Args.Should().Be("init");
    }

    [Fact]
    public void Init_ShouldRunFixtureWithAllSettings()
    {
        var fixture = new TxAliasesFixture<TxInitSettings>();
        var settings = new TxInitSettings
        {
            CertificatePath = "/certs/main.cer",
            HostName = "www.transifex.com",
            RootConfiguration = "/certs/root.cer",
            Token = "some-kind-of-token",
        };

        var result = fixture.TxInit(settings);

        _ = result.Args.Should().Be("--cacert /certs/main.cer --hostname www.transifex.com --root-config /certs/root.cer --token some-kind-of-token init");
    }

    [Fact]
    public void Pull_ShouldRunFixtureWithAllSettings()
    {
        var fixture = new TxAliasesFixture<TxPullSettings>();

        var result = fixture.TxPull(new TxPullSettings
        {
            Branch = "develop",
            CertificatePath = "./certs/main.cer",
            ContentEncoding = Enums.ContentEncodings.Base64,
            DisableOverwrite = true,
            DownloadAllFiles = true,
            DownloadJsonFiles = true,
            DownloadSourceFile = true,
            DownloadTranslationFiles = true,
            DownloadXliffFiles = true,
            ForceDownloads = true,
            HostName = "www.transifex.com",
            KeepNewFiles = true,
            Languages = new[] { "nb*", "en*" },
            MinimumPercentage = 60,
            Mode = Enums.PullMode.OnlyReviewed,
            ParallelWorkers = 10,
            Pseudo = true,
            Resources = new[] { "some-resource", "some-other-resource" },
            RootConfiguration = "./certs/root.cer",
            Silent = true,
            SkipErrors = true,
            Token = "some-token",
            UseGitTimestamps = true,
        });

        _ = result.Args.Should().Be("--cacert certs/main.cer --hostname www.transifex.com --root-config certs/root.cer --token some-token pull --branch develop --content_encoding base64 --disable-overwrite --all --json --source --translations --xliff --force --keep-new-files --languages \"nb*,en*\" --minimum-perc 60 --mode onlyreviewed --workers 10 --pseudo --resources \"some-resource,some-other-resource\" --silent --skip --use-git-timestamps");
    }

    [Fact]
    public void Pull_ShouldRunFixtureWithToken()
    {
        var fixture = new TxAliasesFixture<TxPullSettings>();

        var result = fixture.TxPull("test-token");

        _ = result.Args.Should().Be("--token test-token pull");
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    public void Pull_ThrowsExceptionOnEmptyTokens(string token)
    {
        Action action = () =>
        {
            var context = Substitute.For<ICakeContext>();
            TxAliases.TxPull(context, token);
        };

        _ = action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void Pull_ThrowsExceptionOnNullTokens()
    {
        Action action = () =>
        {
            var context = Substitute.For<ICakeContext>();
            TxAliases.TxPull(context, (string)null);
        };

        _ = action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Pull_ThrowsNullExceptionOnNullSettings()
    {
        Action action = () =>
        {
            var context = Substitute.For<ICakeContext>();
            TxAliases.TxPull(context, (TxPullSettings)null);
        };

        _ = action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Push_ShouldRunFixtureWithAllSettings()
    {
        var fixture = new TxAliasesFixture<TxPullSettings>();

        var result = fixture.TxPush(new TxPushSettings
        {
            Base = "develop",
            Branch = "feature/new-aliases",
            CertificatePath = "./certs/main.cer",
            CreateMissingLanguages = true,
            ForceUploads = true,
            HostName = "www.transifex.com",
            KeepTranslations = true,
            Languages = new[] { "nb*", "en*" },
            ParallelWorkers = 15,
            ReplaceEditedStrings = true,
            Resources = new[] { "resource-6", "another-resource" },
            RootConfiguration = "/certs/root.cer",
            Silent = true,
            SkipErrors = true,
            Token = "some-token",
            UploadSourceFile = true,
            UploadTranslationFiles = true,
            UploadXliffFiles = true,
            UseGitTimestamps = true,
        });

        _ = result.Args.Should().Be("--cacert certs/main.cer --hostname www.transifex.com --root-config /certs/root.cer --token some-token push --base develop --branch feature/new-aliases --all --force --keep-translations --languages \"nb*,en*\" --workers 15 --replace-edited-strings --resources \"resource-6,another-resource\" --silent --skip --source --translation --xliff --use-git-timestamps");
    }

    [Fact]
    public void Push_ShouldRunFixtureWithToken()
    {
        {
            var fixture = new TxAliasesFixture<TxPushSettings>();

            var result = fixture.TxPush("testie");

            _ = result.Args.Should().Be("--token testie push");
        }
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    public void Push_ThrowsExceptionOnEmptyToken(string token)
    {
        Action action = () =>
        {
            var context = Substitute.For<ICakeContext>();
            TxAliases.TxPush(context, token);
        };

        _ = action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void Push_ThrowsExceptionOnNullSettings()
    {
        Action action = () =>
        {
            var context = Substitute.For<ICakeContext>();
            TxAliases.TxPush(context, (TxPushSettings)null);
        };

        _ = action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Push_ThrowsExceptionOnNullToken()
    {
        Action action = () =>
        {
            var context = Substitute.For<ICakeContext>();
            TxAliases.TxPush(context, (string)null);
        };

        _ = action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    public void Status_ThrowsExceptionOnEmptyToken(string token)
    {
        Action action = () =>
        {
            var context = Substitute.For<ICakeContext>();
            TxAliases.TxStatus(context, token);
        };

        _ = action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void Status_ThrowsExceptionOnNullSettings()
    {
        Action action = () =>
        {
            var context = Substitute.For<ICakeContext>();
            TxAliases.TxStatus(context, (TxStatusSettings)null);
        };

        _ = action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Status_ThrowsExceptionOnNullToken()
    {
        Action action = () =>
        {
            var context = Substitute.For<ICakeContext>();
            TxAliases.TxPush(context, (string)null);
        };

        _ = action.Should().ThrowExactly<ArgumentNullException>();
    }

    private class TxAliasesFixture<TSettings> : ToolFixture<TSettings>
        where TSettings : TxGlobalSettings, new()
    {
        public TxAliasesFixture()
            : base("tx")
        {
            var arguments = Substitute.For<ICakeArguments>();
            var registry = Substitute.For<IRegistry>();
            var dataService = Substitute.For<ICakeDataService>();
            Context = new CakeContext(FileSystem, Environment, Globber, new FakeLog(), arguments, ProcessRunner, registry, Tools, dataService, Configuration);
        }

        public ICakeContext Context { get; }

        public ToolFixtureResult TxInit(TxInitSettings settings)
        {
            TxAliases.TxInit(Context, settings);

            return ProcessRunner.Results.Count > 0 ? ProcessRunner.Results[0] : null;
        }

        public ToolFixtureResult TxPull(string token)
        {
            TxAliases.TxPull(Context, token);

            return ProcessRunner.Results.Count > 0 ? ProcessRunner.Results[0] : null;
        }

        public ToolFixtureResult TxPull(TxPullSettings settings)
        {
            TxAliases.TxPull(Context, settings);

            return ProcessRunner.Results.Count > 0 ? ProcessRunner.Results[0] : null;
        }

        public ToolFixtureResult TxPush(string token)
        {
            TxAliases.TxPush(Context, token);

            return ProcessRunner.Results.Count > 0 ? ProcessRunner.Results[0] : null;
        }

        public ToolFixtureResult TxPush(TxPushSettings settings)
        {
            TxAliases.TxPush(Context, settings);

            return ProcessRunner.Results.Count > 0 ? ProcessRunner.Results[0] : null;
        }

        protected override void RunTool() => throw new NotImplementedException();
    }
}
