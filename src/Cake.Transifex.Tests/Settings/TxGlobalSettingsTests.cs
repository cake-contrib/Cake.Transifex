namespace Cake.Transifex.Tests.Settings;

using System.Collections.Generic;
using Cake.Core.IO;
using Cake.Transifex.Settings;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

public abstract class TxGlobalSettingsTests<TSettings>
    where TSettings : TxGlobalSettings, new()
{
    public static TheoryData<string> EmptyValues => new(null, "", "       ");

    protected TSettings Settings { get; } = new();

    [Fact]
    public void CertificatePath_ShouldRemoveVariableWhenNull()
    {
        CertificatePath_ShouldSetExpectedVariable();

        Settings.CertificatePath = null;

        using (new AssertionScope())
        {
            _ = Settings.CertificatePath.Should().BeNull();

            AssertNoAvailableKey("--cacert");
        }
    }

    [Fact]
    public void CertificatePath_ShouldSetExpectedVariable()
    {
        var expectedPath = new FilePath("./config/test-certificate.cer");
        Settings.CertificatePath = expectedPath;

        using (new AssertionScope())
        {
            _ = Settings.CertificatePath.Should().Be(expectedPath);

            AssertPrependedValue("--cacert", expectedPath);
        }
    }

    [Fact]
    public void Configuration_ShouldRemoveVariableWhenNull()
    {
        Configuration_ShouldSetExpectedVariable();

        Settings.Configuration = null;

        using (new AssertionScope())
        {
            _ = Settings.Configuration.Should().BeNull();

            AssertNoAvailableKey("--config");
        }
    }

    [Fact]
    public void Configuration_ShouldSetExpectedVariable()
    {
        var expectedPath = new FilePath("./.transifex/config");
        Settings.Configuration = expectedPath;

        using (new AssertionScope())
        {
            _ = Settings.Configuration.Should().Be(expectedPath);

            AssertPrependedValue("--config", expectedPath);
        }
    }

    [Theory]
    [MemberData(nameof(EmptyValues))]
    public void HostName_ShouldRemoveVariableWhenEmptyOrNull(string hostName)
    {
        HostName_ShouldSetExpectedVariable();
        Settings.HostName = hostName;

        using (new AssertionScope())
        {
            _ = Settings.HostName.Should().BeNull();

            AssertNoAvailableKey("--hostname");
        }
    }

    [Fact]
    public void HostName_ShouldSetExpectedVariable()
    {
        const string expectedHostName = "www.transifex.com";
        Settings.HostName = expectedHostName;

        using (new AssertionScope())
        {
            _ = Settings.HostName.Should().Be(expectedHostName);

            AssertPrependedValue("--hostname", expectedHostName);
        }
    }

    [Fact]
    public void RootConfiguration_ShouldRemoveVariableWhenNull()
    {
        RootConfiguration_ShouldSetExpectedVariable();
        Settings.RootConfiguration = null;

        using (new AssertionScope())
        {
            _ = Settings.RootConfiguration.Should().BeNull();

            AssertNoAvailableKey("--root-config");
        }
    }

    [Fact]
    public void RootConfiguration_ShouldSetExpectedVariable()
    {
        var expectedPath = new FilePath("./.transifex/root-config");
        Settings.RootConfiguration = expectedPath;

        using (new AssertionScope())
        {
            _ = Settings.RootConfiguration.Should().Be(expectedPath);

            AssertPrependedValue("--root-config", expectedPath);
        }
    }

    [Theory]
    [MemberData(nameof(EmptyValues))]
    public void Token_ShouldRemoveVariableWhenEmptyOrNull(string token)
    {
        Token_ShouldSetExpectedVariable();
        Settings.Token = token;

        using (new AssertionScope())
        {
            _ = Settings.Token.Should().BeNull();

            AssertNoAvailableKey("--token");
        }
    }

    [Fact]
    public void Token_ShouldSetExpectedVariable()
    {
        const string expectedToken = "MY-AWESOME-TOKEN";
        Settings.Token = expectedToken;

        using (new AssertionScope())
        {
            _ = Settings.Token.Should().Be(expectedToken);

            AssertPrependedSecretValue("--token", expectedToken);
        }
    }

    protected void AssertAppendedCollectionValue<TValue>(string key, ICollection<TValue> expectedValues)
    {
        var arguments = Settings.GetAllAppendedArguments();
        _ = arguments.Should().ContainKey(key).WhoseValue.Should().BeAssignableTo<ICollection<TValue>>();
        var values = (ICollection<TValue>)arguments[key];

        if (expectedValues.Count == 0)
        {
            _ = values.Should().BeEmpty();
        }
        else
        {
            _ = values.Should().BeEquivalentTo(expectedValues);
        }

        _ = arguments.Should().NotContainKey("!" + key);
        _ = Settings.GetAllPrependendArguments().Should().NotContainKeys("!" + key, key);
    }

    protected void AssertAppendedSecretValue<TValue>(string key, TValue expectedValue)
    {
        var arguments = Settings.GetAllAppendedArguments();
        _ = arguments.Should().ContainKey("!" + key).WhoseValue.Should().BeOfType(typeof(TValue)).And.Be(expectedValue);
        _ = arguments.Should().NotContainKey(key);

        _ = Settings.GetAllPrependendArguments().Should().NotContainKeys("!" + key, key);
    }

    protected void AssertAppendedValue<TValue>(string key, TValue expectedValue)
    {
        var arguments = Settings.GetAllAppendedArguments();
        _ = arguments.Should().ContainKey(key).WhoseValue.Should().BeOfType<TValue>().And.Be(expectedValue);
        _ = arguments.Should().NotContainKey("!" + key);

        _ = Settings.GetAllPrependendArguments().Should().NotContainKeys("!" + key, key);
    }

    protected void AssertNoAvailableKey(string key)
    {
        _ = Settings.GetAllPrependendArguments().Should().NotContainKeys("!" + key, key);
        _ = Settings.GetAllAppendedArguments().Should().NotContainKeys("!" + key, key);
    }

    protected void AssertPrependedSecretValue<TValue>(string key, TValue expectedValue)
    {
        var arguments = Settings.GetAllPrependendArguments();
        _ = arguments.Should().ContainKey("!" + key).WhoseValue.Should().BeOfType(typeof(TValue)).And.Be(expectedValue);
        _ = arguments.Should().NotContainKey(key);

        _ = Settings.GetAllAppendedArguments().Should().NotContainKeys("!" + key, key);
    }

    protected void AssertPrependedValue<TValue>(string key, TValue expectedValue)
    {
        var arguments = Settings.GetAllPrependendArguments();
        _ = arguments.Should().NotContainKey("!" + key);
        _ = arguments.Should().ContainKey(key).WhoseValue.Should().BeOfType(typeof(TValue)).And.Be(expectedValue);

        _ = Settings.GetAllAppendedArguments().Should().NotContainKeys("!" + key, key);
    }
}
