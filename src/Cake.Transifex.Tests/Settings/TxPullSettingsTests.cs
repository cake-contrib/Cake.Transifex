namespace Cake.Transifex.Tests.Settings;

using System;
using System.Collections.Generic;
using Cake.Transifex.Settings;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;
using Cake.Transifex.Enums;

public class TxPullSettingsTests : TxGlobalSettingsTests<TxPullSettings>
{
    public static TheoryData<PullMode> TransifexModes => new(Enum.GetValues<PullMode>());

    [Fact]
    public void Branch_ShouldRemoveVariableWhenNull()
    {
        Branch_ShouldSetExpectedVariable("something");

        Settings.Branch = null;

        using (new AssertionScope())
        {
            _ = Settings.Branch.Should().BeNull();

            AssertNoAvailableKey("--branch");
        }
    }

    [Theory]
    [InlineData("develop")]
    [InlineData("support/1.x")]
    [InlineData("")]
    public void Branch_ShouldSetExpectedVariable(string value)
    {
        Settings.Branch = value;

        using (new AssertionScope())
        {
            _ = Settings.Branch.Should().Be(value);

            AssertAppendedValue("--branch", value);
        }
    }

    [Fact]
    public void Constructor_ShouldNotSetAnyVariables()
    {
        using (new AssertionScope())
        {
            _ = Settings.GetAllAppendedArguments().Should().BeEmpty();
            _ = Settings.GetAllPrependendArguments().Should().BeEmpty();
        }
    }

    [Theory]
    [InlineData(ContentEncodings.Text)]
    [InlineData(ContentEncodings.Base64)]
    public void ContentEncoding_ShouldSetExpectedVariable(ContentEncodings encoding)
    {
        Settings.ContentEncoding = encoding;

        using (new AssertionScope())
        {
            _ = Settings.ContentEncoding.Should().Be(encoding);

            AssertAppendedValue("--content_encoding", encoding);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DisableOverwrite_ShouldSetExpectedVariable(bool value)
    {
        Settings.DisableOverwrite = value;

        using (new AssertionScope())
        {
            _ = Settings.DisableOverwrite.Should().Be(value);

            AssertAppendedValue("--disable-overwrite", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DownloadAllFiles_ShouldSetExpectedVariable(bool value)
    {
        Settings.DownloadAllFiles = value;

        using (new AssertionScope())
        {
            _ = Settings.DownloadAllFiles.Should().Be(value);

            AssertAppendedValue("--all", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DownloadJsonFiles_ShouldSetExpectedVariable(bool value)
    {
        Settings.DownloadJsonFiles = value;

        using (new AssertionScope())
        {
            _ = Settings.DownloadJsonFiles.Should().Be(value);

            AssertAppendedValue("--json", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DownloadSourceFile_ShouldSetExpectedVariable(bool value)
    {
        Settings.DownloadSourceFile = value;

        using (new AssertionScope())
        {
            _ = Settings.DownloadSourceFile.Should().Be(value);

            AssertAppendedValue("--source", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DownloadTranslationFiles_ShouldSetExpectedVariable(bool value)
    {
        Settings.DownloadTranslationFiles = value;

        using (new AssertionScope())
        {
            _ = Settings.DownloadTranslationFiles.Should().Be(value);

            AssertAppendedValue("--translations", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DownloadXliffFiles_ShouldSetExpectedVariable(bool value)
    {
        Settings.DownloadXliffFiles = value;

        using (new AssertionScope())
        {
            _ = Settings.DownloadXliffFiles.Should().Be(value);

            AssertAppendedValue("--xliff", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ForceDownloads_ShouldSetExpectedVariable(bool value)
    {
        Settings.ForceDownloads = value;

        using (new AssertionScope())
        {
            _ = Settings.ForceDownloads.Should().Be(value);

            AssertAppendedValue("--force", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void KeepNewFiles_ShouldSetExpectedVariable(bool value)
    {
        Settings.KeepNewFiles = value;

        using (new AssertionScope())
        {
            _ = Settings.KeepNewFiles.Should().Be(value);

            AssertAppendedValue("--keep-new-files", value);
        }
    }

    [Fact]
    public void Languages_ShouldAppendExpectedValueToVariable()
    {
        Settings.Languages.Add("en*");

        using (new AssertionScope())
        {
            _ = Settings.Languages.Should().ContainSingle().And.Contain("en*");

            AssertAppendedCollectionValue("--languages", new[] { "en*" });
        }
    }

    [Fact]
    public void Languages_ShouldDefaultToEmptyArray()
    {
        using (new AssertionScope())
        {
            _ = Settings.Languages.Should().BeEmpty();

            AssertAppendedCollectionValue("--languages", Array.Empty<string>());
        }
    }

    [Fact]
    public void Languages_ShouldRemoveExpectedVariableWhenNull()
    {
        Languages_ShouldSetExpectedVariable();

        Settings.Languages = null;

        using (new AssertionScope())
        {
            AssertNoAvailableKey("--languages");
        }
    }

    [Fact]
    public void Languages_ShouldSetExpectedVariable()
    {
        var testValue = new List<string> { "nb-NO*", "en*", "fr" };

        Settings.Languages = testValue;

        using (new AssertionScope())
        {
            _ = Settings.Languages.Should().BeSameAs(testValue);

            AssertAppendedCollectionValue("--languages", testValue);
        }
    }

    [Fact]
    public void MinimumPercent_ShouldHaveMinusOneAsDefault()
    {
        using (new AssertionScope())
        {
            {
                _ = Settings.MinimumPercentage.Should().Be(-1);

                AssertNoAvailableKey("--minimum-perc");
            }
        }
    }

    [Fact]
    public void MinimumPercent_ShouldSetExpectedVariable()
    {
        Settings.MinimumPercentage = 60;

        using (new AssertionScope())
        {
            _ = Settings.MinimumPercentage.Should().Be(60);

            AssertAppendedValue<short>("--minimum-perc", 60);
        }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(101)]
    public void MinimumPercentage_ShouldThrowExceptionWhenOutOfRange(short value)
    {
        Action action = () => Settings.MinimumPercentage = value;

        _ = action.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage($"Value must be between 1 and 100. (Parameter '{nameof(Settings.MinimumPercentage)}')")
            .And.ParamName.Should().Be(nameof(Settings.MinimumPercentage));
    }

    [Theory]
    [MemberData(nameof(TransifexModes))]
    public void Mode_ShouldSetExpectedVariable(PullMode mode)
    {
        Settings.Mode = mode;

        using (new AssertionScope())
        {
            _ = Settings.Mode.Should().Be(mode);

            AssertAppendedValue("--mode", mode);
        }
    }

    [Fact]
    public void Mode_ShouldSpecifDefaultByDefault()
        => Settings.Mode.Should().Be(PullMode.Default);

    [Fact]
    public void ParallelWorkers_ShouldDefaultToFive()
        => Settings.ParallelWorkers.Should().Be(5);

    [Fact]
    public void ParallelWorkers_ShouldNotSetFiveAsArgumentValueByDefault()
    {
        _ = Settings.ParallelWorkers;

        using (new AssertionScope())
        {
            AssertNoAvailableKey("--workers");
        }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(21)]
    public void ParallelWorkers_ShouldThrowExceptionWhenOutOfRange(byte workers)
    {
        Action action = () => Settings.ParallelWorkers = workers;

        _ = action.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage($"Value must be between 1 and 20. (Parameter '{nameof(Settings.ParallelWorkers)}')")
            .And.ParamName.Should().Be(nameof(Settings.ParallelWorkers));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(20)]
    public void ParallelWorkes_ShouldSetExpectedVariable(byte workers)
    {
        Settings.ParallelWorkers = workers;

        using (new AssertionScope())
        {
            _ = Settings.ParallelWorkers.Should().Be(workers);

            AssertAppendedValue("--workers", workers);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Pseudo_ShouldSetExpectedVariable(bool value)
    {
        Settings.Pseudo = value;

        using (new AssertionScope())
        {
            _ = Settings.Pseudo.Should().Be(value);

            AssertAppendedValue("--pseudo", value);
        }
    }

    [Fact]
    public void Resources_ShouldAppendExpectedValueToVariable()
    {
        Settings.Resources.Add("o:cake-contrib:p:caketransifex:r:exceptionsresx");

        using (new AssertionScope())
        {
            _ = Settings.Resources.Should().ContainSingle().And.Contain("o:cake-contrib:p:caketransifex:r:exceptionsresx");

            AssertAppendedCollectionValue("--resources", new[] { "o:cake-contrib:p:caketransifex:r:exceptionsresx" });
        }
    }

    [Fact]
    public void Resources_ShouldDefaultToEmptyArray()
    {
        using (new AssertionScope())
        {
            _ = Settings.Resources.Should().BeEmpty();

            AssertAppendedCollectionValue("--resources", Array.Empty<string>());
        }
    }

    [Fact]
    public void Resources_ShouldRemoveExpectedVariableWhenNull()
    {
        Resources_ShouldSetExpectedVariable();

        Settings.Resources = null;

        using (new AssertionScope())
        {
            AssertNoAvailableKey("--resources");
        }
    }

    [Fact]
    public void Resources_ShouldSetExpectedVariable()
    {
        var testValue = new List<string> { "o:cake-contrib:p:caketransifex:r:exceptionsresx", "o:cake-contrib:p:caketransifex:r:commonresx" };

        Settings.Resources = testValue;

        using (new AssertionScope())
        {
            _ = Settings.Resources.Should().BeSameAs(testValue);

            AssertAppendedCollectionValue("--resources", testValue);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Silent_ShouldSetExpectedVariable(bool value)
    {
        Settings.Silent = value;

        using (new AssertionScope())
        {
            _ = Settings.Silent.Should().Be(value);

            AssertAppendedValue("--silent", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SkipErrors_ShouldSetExpectedVariable(bool value)
    {
        Settings.SkipErrors = value;

        using (new AssertionScope())
        {
            _ = Settings.SkipErrors.Should().Be(value);

            AssertAppendedValue("--skip", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void UseGitTimestamps_ShouldSetExpectedVariable(bool value)
    {
        Settings.UseGitTimestamps = value;

        using (new AssertionScope())
        {
            _ = Settings.UseGitTimestamps.Should().Be(value);

            AssertAppendedValue("--use-git-timestamps", value);
        }
    }
}
