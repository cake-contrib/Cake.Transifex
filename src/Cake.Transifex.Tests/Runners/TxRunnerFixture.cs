namespace Cake.Transifex.Tests.Runners;

using Cake.Testing.Fixtures;
using Cake.Transifex.Runners;
using Cake.Transifex.Settings;

public class TxRunnerFixture<TSettings> : ToolFixture<TSettings>
    where TSettings : TxGlobalSettings, new()
{
    public TxRunnerFixture()
        : base("tx")
    {
    }

    protected override void RunTool()
    {
        var tool = new TxRunner(FileSystem, Environment, ProcessRunner, Tools);
        tool.Run(Settings);
    }
}
