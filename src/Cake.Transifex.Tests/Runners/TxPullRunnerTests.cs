namespace Cake.Transifex.Tests.Runners;

using System;
using Cake.Transifex.Enums;
using Cake.Transifex.Settings;
using FluentAssertions;
using Xunit;

public class TxPullRunnerTests : TxGlobalRunnerTests<TxPullSettings>
{
    public TxPullRunnerTests()
        : base("pull")
    {
    }

    public static TheoryData<ContentEncodings> Encodings => new(Enum.GetValues<ContentEncodings>());

    public static TheoryData<PullMode> Modes => new(Enum.GetValues<PullMode>());

    [Fact]
    public void Run_ShouldNotIncludeBranchWhenNull()
    {
        Settings.Branch = null;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetAll()
    {
        Settings.DownloadAllFiles = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetDisableOverwrite()
    {
        Settings.DisableOverwrite = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetForce()
    {
        Settings.ForceDownloads = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetJson()
    {
        Settings.DownloadJsonFiles = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetKeepNewFiles()
    {
        Settings.KeepNewFiles = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetPseudo()
    {
        Settings.Pseudo = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetSilent()
    {
        Settings.Silent = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetSkip()
    {
        Settings.SkipErrors = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetSource()
    {
        Settings.DownloadSourceFile = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetTranslations()
    {
        Settings.DownloadTranslationFiles = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetUseGitTimestamps()
    {
        Settings.UseGitTimestamps = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldNotSetXliff()
    {
        Settings.DownloadXliffFiles = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull");
    }

    [Fact]
    public void Run_ShouldSetAll()
    {
        Settings.DownloadAllFiles = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --all");
    }

    [Theory]
    [InlineData("master")]
    [InlineData("develop")]
    [InlineData("feature/branch-argument")]
    public void Run_ShouldSetBranch(string name)
    {
        Settings.Branch = name;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"pull --branch {name}");
    }

    [Fact]
    public void Run_ShouldSetBranchOnEmptyValue()
    {
        Settings.Branch = string.Empty;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --branch \"\"");
    }

    [Theory]
    [MemberData(nameof(Encodings))]
    public void Run_ShouldSetContentEncoding(ContentEncodings encoding)
    {
        Settings.ContentEncoding = encoding;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"pull --content_encoding {encoding.ToString().ToLowerInvariant()}");
    }

    [Fact]
    public void Run_ShouldSetDisableOverwrite()
    {
        Settings.DisableOverwrite = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --disable-overwrite");
    }

    [Fact]
    public void Run_ShouldSetForce()
    {
        Settings.ForceDownloads = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --force");
    }

    [Fact]
    public void Run_ShouldSetJson()
    {
        Settings.DownloadJsonFiles = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --json");
    }

    [Fact]
    public void Run_ShouldSetKeepNewFiles()
    {
        Settings.KeepNewFiles = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --keep-new-files");
    }

    [Fact]
    public void Run_ShouldSetLanguageMultiple()
    {
        Settings.Languages.Add("en");
        Settings.Languages.Add("nb");
        Settings.Languages.Add("fr");

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --languages \"en,nb,fr\"");
    }

    [Fact]
    public void Run_ShouldSetLanguageSingle()
    {
        Settings.Languages.Add("en");

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --languages en");
    }

    [Fact]
    public void Run_ShouldSetLanguageSingleWithAsterisk()
    {
        Settings.Languages.Add("en*");

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --languages \"en*\"");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(50)]
    [InlineData(100)]
    public void Run_ShouldSetMinimumPercentage(short percentage)
    {
        Settings.MinimumPercentage = percentage;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"pull --minimum-perc {percentage}");
    }

    [Theory]
    [MemberData(nameof(Modes))]
    public void Run_ShouldSetMode(PullMode mode)
    {
        Settings.Mode = mode;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"pull --mode {mode.ToString().ToLowerInvariant()}");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(19)]
    public void Run_ShouldSetParallelWorkers(byte workers)
    {
        Settings.ParallelWorkers = workers;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"pull --workers {workers}");
    }

    [Fact]
    public void Run_ShouldSetPseudo()
    {
        Settings.Pseudo = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --pseudo");
    }

    [Fact]
    public void Run_ShouldSetResourcesMultiple()
    {
        Settings.Resources = new[]
        {
            "caketransifex.commonresx",
            "caketransifex.exceptionresx"
        };

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --resources \"caketransifex.commonresx,caketransifex.exceptionresx\"");
    }

    [Theory]
    [InlineData("caketransifex.commonresx")]
    [InlineData("caketransifex.exceptionsresx")]
    public void Run_ShouldSetResourcesSingle(string resourceName)
    {
        Settings.Resources.Add(resourceName);

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"pull --resources {resourceName}");
    }

    [Fact]
    public void Run_ShouldSetSilent()
    {
        Settings.Silent = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --silent");
    }

    [Fact]
    public void Run_ShouldSetSkip()
    {
        Settings.SkipErrors = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --skip");
    }

    [Fact]
    public void Run_ShouldSetSource()
    {
        Settings.DownloadSourceFile = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --source");
    }

    [Fact]
    public void Run_ShouldSetTranslations()
    {
        Settings.DownloadTranslationFiles = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --translations");
    }

    [Fact]
    public void Run_ShouldSetUseGitTimestamps()
    {
        Settings.UseGitTimestamps = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --use-git-timestamps");
    }

    [Fact]
    public void Run_ShouldSetXliff()
    {
        Settings.DownloadXliffFiles = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("pull --xliff");
    }
}
