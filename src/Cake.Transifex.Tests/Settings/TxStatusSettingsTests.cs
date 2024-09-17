namespace Cake.Transifex.Tests.Settings;

using System;
using System.Collections.Generic;
using Cake.Transifex.Settings;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

public class TxStatusSettingsTests : TxGlobalSettingsTests<TxStatusSettings>
{
    [Fact]
    public void Resources_ShouldDefaultToAnEmptyArray()
    {
        using (new AssertionScope())
        {
            _ = Settings.Resources.Should().BeEmpty();

            var arguments = Settings.GetAllAppendedArguments();

            _ = arguments.Should().ContainKey("--resources").WhoseValue.Should().BeOfType<List<string>>();
            var resources = (ICollection<string>)arguments["--resources"];
            _ = resources.Should().BeEmpty();

            _ = arguments.Should().NotContainKey("!--resources");
            _ = Settings.GetAllPrependendArguments().Should().NotContainKeys("!--resources", "--resources");
        }
    }

    [Fact]
    public void Resources_ShouldKeepEmptyArrayWhenSet()
    {
        Settings.Resources = Array.Empty<string>();

        using (new AssertionScope())
        {
            _ = Settings.Resources.Should().BeEmpty();

            AssertAppendedValue("--resources", Array.Empty<string>());
        }
    }

    [Fact]
    public void Resources_ShouldSetExpectedVariable()
    {
        var expected = new[] { "nb" };
        Settings.Resources = expected;

        using (new AssertionScope())
        {
            _ = Settings.Resources.Should().BeEquivalentTo(expected);

            AssertAppendedValue("--resources", expected);
        }
    }

    [Fact]
    public void Resources_ShouldSetMultipleValuesToExpectedVariable()
    {
        var expected = new[] { "nb*", "en*", "fr" };
        Settings.Resources = expected;

        using (new AssertionScope())
        {
            _ = Settings.Resources.Should().BeEquivalentTo(expected);

            AssertAppendedValue("--resources", expected);
        }
    }
}
