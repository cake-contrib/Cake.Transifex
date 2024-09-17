namespace Cake.Transifex.Tests.Settings;

using System;
using System.Collections.Generic;
using Cake.Transifex.Settings;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

public class TxPushSettingsTests : TxGlobalSettingsTests<TxPushSettings>
{
    [Fact]
    public void BranchCurrent_ShouldRemoveVariableWhenNull()
    {
        BranchCurrent_ShouldSetExpectedVariable("something");

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
    public void BranchCurrent_ShouldSetExpectedVariable(string value)
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
    [InlineData(true)]
    [InlineData(false)]
    public void CreateMissingLanguages_ShouldSetExpectedVariable(bool value)
    {
        Settings.CreateMissingLanguages = value;

        using (new AssertionScope())
        {
            _ = Settings.CreateMissingLanguages.Should().Be(value);

            AssertAppendedValue("--all", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ForceUploads_ShouldSetExpectedVariable(bool value)
    {
        Settings.ForceUploads = value;

        using (new AssertionScope())
        {
            _ = Settings.ForceUploads.Should().Be(value);

            AssertAppendedValue("--force", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void KeepTranslations_ShouldSetExpectedVariable(bool value)
    {
        Settings.KeepTranslations = value;

        using (new AssertionScope())
        {
            _ = Settings.KeepTranslations.Should().Be(value);

            AssertAppendedValue("--keep-translations", value);
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
    public void ReplaceEditedStrings_ShouldSetExpectedVariable(bool value)
    {
        Settings.ReplaceEditedStrings = value;

        using (new AssertionScope())
        {
            _ = Settings.ReplaceEditedStrings.Should().Be(value);

            AssertAppendedValue("--replace-edited-strings", value);
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
    public void UploadSourceFile_ShouldSetExpectedVariable(bool value)
    {
        Settings.UploadSourceFile = value;

        using (new AssertionScope())
        {
            _ = Settings.UploadSourceFile.Should().Be(value);

            AssertAppendedValue("--source", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void UploadTranslationFiles_ShouldSetExpectedVariable(bool value)
    {
        Settings.UploadTranslationFiles = value;

        using (new AssertionScope())
        {
            _ = Settings.UploadTranslationFiles.Should().Be(value);

            AssertAppendedValue("--translation", value);
        }
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void UploadXliffFiles_ShouldSetExpectedVariable(bool value)
    {
        Settings.UploadXliffFiles = value;

        using (new AssertionScope())
        {
            _ = Settings.UploadXliffFiles.Should().Be(value);

            AssertAppendedValue("--xliff", value);
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
