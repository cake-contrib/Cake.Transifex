namespace Cake.Transifex.Tests.Runners;

using Cake.Transifex.Settings;

public class TxInitRunnerTests : TxGlobalRunnerTests<TxInitSettings>
{
    public TxInitRunnerTests()
        : base("init")
    {
    }
}
