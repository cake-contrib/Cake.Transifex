namespace Cake.Transifex.Tests.Runners;

using System;
using Cake.Transifex.Settings;
using FluentAssertions;
using Xunit;

public class TxStatusRunnerTests : TxGlobalRunnerTests<TxStatusSettings>
{
    public TxStatusRunnerTests()
        : base("status")
    {
    }

    [Fact]
    public void Run_SetsResourcesWithSingleValue()
    {
        Settings.Resources = new[] { "test-resource" };

        var result = Fixture.Run();

        _ = result.Args.Should().Be("status --resources test-resource");
    }

    [Fact]
    public void Run_SetsResourcesWithMultipleValues()
    {
        Settings.Resources = new[] { "test-resource-1", "test-resource-2", "something-else" };

        var result = Fixture.Run();

        _ = result.Args.Should().Be("status --resources \"test-resource-1,test-resource-2,something-else\"");
    }

    [Fact]
    public void Run_IgnoresResourcesWhenEmpty()
    {
        Settings.Resources = Array.Empty<string>();

        var result = Fixture.Run();

        _ = result.Args.Should().Be("status");
    }
}
