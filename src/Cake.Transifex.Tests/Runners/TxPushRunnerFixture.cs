namespace Cake.Transifex.Tests.Runners;

using Cake.Transifex.Settings;
using FluentAssertions;
using Xunit;

public class TxPushRunnerFixture : TxGlobalRunnerTests<TxPushSettings>
{
    public TxPushRunnerFixture()
        : base("push")
    {
    }

    public static TheoryData<string> NullOrEmptyString => new(
        null,
        string.Empty,
        "         ");

    public static TheoryData<string> TestBranches => new(
        "master",
        "develop",
        "support/2.x",
        "feature/test-feature");

    [Fact]
    public void Run_ShouldNotIncludeBranchWhenNull()
    {
        Settings.Branch = null;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetAll()
    {
        Settings.CreateMissingLanguages = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Theory]
    [MemberData(nameof(NullOrEmptyString))]
    public void Run_ShouldNotSetBase(string name)
    {
        Settings.Base = name;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetForce()
    {
        Settings.ForceUploads = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetKeepTranslations()
    {
        Settings.KeepTranslations = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetReplaceEditedStrings()
    {
        Settings.ReplaceEditedStrings = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetSilent()
    {
        Settings.Silent = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetSkip()
    {
        Settings.SkipErrors = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetSource()
    {
        Settings.UploadSourceFile = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetTranslation()
    {
        Settings.UploadTranslationFiles = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetUseGitTimestamps()
    {
        Settings.UseGitTimestamps = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldNotSetXliff()
    {
        Settings.UploadXliffFiles = false;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push");
    }

    [Fact]
    public void Run_ShouldSetAll()
    {
        Settings.CreateMissingLanguages = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --all");
    }

    [Theory]
    [MemberData(nameof(TestBranches))]
    public void Run_ShouldSetBase(string name)
    {
        Settings.Base = name;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"push --base {name}");
    }

    [Theory]
    [MemberData(nameof(TestBranches))]
    public void Run_ShouldSetBranch(string name)
    {
        Settings.Branch = name;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"push --branch {name}");
    }

    [Fact]
    public void Run_ShouldSetBranchOnEmptyValue()
    {
        Settings.Branch = string.Empty;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --branch \"\"");
    }

    [Fact]
    public void Run_ShouldSetForce()
    {
        Settings.ForceUploads = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --force");
    }

    [Fact]
    public void Run_ShouldSetKeepTranslations()
    {
        Settings.KeepTranslations = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --keep-translations");
    }

    [Fact]
    public void Run_ShouldSetLanguageMultiple()
    {
        Settings.Languages.Add("en");
        Settings.Languages.Add("nb");
        Settings.Languages.Add("fr");

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --languages \"en,nb,fr\"");
    }

    [Fact]
    public void Run_ShouldSetLanguageSingle()
    {
        Settings.Languages.Add("en");

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --languages en");
    }

    [Fact]
    public void Run_ShouldSetLanguageSingleWithAsterisk()
    {
        Settings.Languages.Add("en*");

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --languages \"en*\"");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(19)]
    public void Run_ShouldSetParallelWorkers(byte workers)
    {
        Settings.ParallelWorkers = workers;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"push --workers {workers}");
    }

    [Fact]
    public void Run_ShouldSetReplaceEditedStrings()
    {
        Settings.ReplaceEditedStrings = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --replace-edited-strings");
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

        _ = result.Args.Should().Be("push --resources \"caketransifex.commonresx,caketransifex.exceptionresx\"");
    }

    [Theory]
    [InlineData("caketransifex.commonresx")]
    [InlineData("caketransifex.exceptionsresx")]
    public void Run_ShouldSetResourcesSingle(string resourceName)
    {
        Settings.Resources.Add(resourceName);

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"push --resources {resourceName}");
    }

    [Fact]
    public void Run_ShouldSetSilent()
    {
        Settings.Silent = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --silent");
    }

    [Fact]
    public void Run_ShouldSetSkip()
    {
        Settings.SkipErrors = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --skip");
    }

    [Fact]
    public void Run_ShouldSetSource()
    {
        Settings.UploadSourceFile = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --source");
    }

    [Fact]
    public void Run_ShouldSetTranslation()
    {
        Settings.UploadTranslationFiles = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --translation");
    }

    [Fact]
    public void Run_ShouldSetUseGitTimestamps()
    {
        Settings.UseGitTimestamps = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --use-git-timestamps");
    }

    [Fact]
    public void Run_ShouldSetXliff()
    {
        Settings.UploadXliffFiles = true;

        var result = Fixture.Run();

        _ = result.Args.Should().Be("push --xliff");
    }
}
