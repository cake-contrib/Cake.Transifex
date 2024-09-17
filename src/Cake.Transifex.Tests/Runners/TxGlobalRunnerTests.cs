namespace Cake.Transifex.Tests.Runners;

using Cake.Core.IO;
using Cake.Transifex.Settings;
using FluentAssertions;
using Xunit;

public abstract class TxGlobalRunnerTests<TSettings>
    where TSettings : TxGlobalSettings, new()
{
    private readonly string _commandName;

    protected TxGlobalRunnerTests(string commandName)
    {
        _commandName = commandName;
    }

    protected TxRunnerFixture<TSettings> Fixture { get; } = new()
    {
        Settings = new()
    };

    protected TSettings Settings => Fixture.Settings;

    [Fact]
    public void Run_ShouldOnlySetCommandNameWithoutArguments()
    {
        var result = Fixture.Run();

        _ = result.Args.Should().Be(_commandName);
    }

    [Fact]
    public void Run_ShouldSetCertificatePath()
    {
        var certificatePath = new FilePath("./certs/certificate.cer");

        Settings.CertificatePath = certificatePath;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"--cacert {certificatePath.FullPath} {_commandName}");
    }

    [Fact]
    public void Run_ShouldSetCertificatePathInQuotes()
    {
        var certificatePath = new FilePath("./certs with space/certif icate.cer");

        Settings.CertificatePath = certificatePath;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"--cacert \"{certificatePath.FullPath}\" {_commandName}");
    }

    [Fact]
    public void Run_ShouldSetConfigurationPath()
    {
        var configPath = new FilePath("./tx/config");

        Settings.Configuration = configPath.FullPath;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"--config {configPath.FullPath} {_commandName}");
    }

    [Fact]
    public void Run_ShouldSetConfigurationPathInQuotes()
    {
        var configPath = new FilePath("./tx/config with space");

        Settings.Configuration = configPath.FullPath;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"--config \"{configPath.FullPath}\" {_commandName}");
    }

    [Fact]
    public void Run_ShouldSetHostName()
    {
        const string expectedValue = "www.transifex.com";

        Settings.HostName = expectedValue;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"--hostname {expectedValue} {_commandName}");
    }

    [Fact]
    public void Run_ShouldSetRootConfigurationPath()
    {
        var configPath = new FilePath("./configuration/root");

        Settings.RootConfiguration = configPath.FullPath;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"--root-config {configPath.FullPath} {_commandName}");
    }

    [Fact]
    public void Run_ShouldSetRootConfigurationPathInQuotes()
    {
        var configPath = new FilePath("./root configuration");

        Settings.RootConfiguration = configPath.FullPath;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"--root-config \"{configPath.FullPath}\" {_commandName}");
    }

    [Fact]
    public void Run_ShouldSetToken()
    {
        const string token = "MY-AWESOME-TOKEN";

        Settings.Token = token;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"--token {token} {_commandName}");
    }

    [Fact]
    public void Run_ShouldSetTokenInQuotes()
    {
        const string token = "MY AWESOME TOKEN";

        Settings.Token = token;

        var result = Fixture.Run();

        _ = result.Args.Should().Be($"--token \"{token}\" {_commandName}");
    }
}
