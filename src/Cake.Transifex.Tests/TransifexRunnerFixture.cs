namespace Cake.Transifex.Tests
{
    using Cake.Testing.Fixtures;

    public class TransifexPullFixture : ToolFixture<TransifexPullSettings>
    {
        public TransifexPullFixture()
            : base("tx")
        {
        }

        protected override void RunTool()
        {
            var tool = new TransifexRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Pull(Settings);
        }
    }

    public class TransifexPushFixture : ToolFixture<TransifexPushSettings>
    {
        public TransifexPushFixture()
            : base("tx")
        {
        }

        protected override void RunTool()
        {
            var tool = new TransifexRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Push(Settings);
        }
    }

    public class TransifexStatusFixture : ToolFixture<TransifexStatusSettings>
    {
        public TransifexStatusFixture()
            : base("tx")
        {
        }

        public string Resources { get; set; }

        protected override void RunTool()
        {
            var tool = new TransifexRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Status(Resources);
        }
    }
}
