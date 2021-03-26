namespace Cake.Transifex.Tests
{
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Testing;
    using Cake.Testing.Fixtures;
    using Moq;

    public class TransifexAliasesInitFixture : TransifexInitFixture
    {
        private static ICakeContext _context;

        public TransifexAliasesInitFixture()
        {
            var argumentsMoq = new Mock<ICakeArguments>();
            var registryMoq = new Mock<IRegistry>();
            var dataService = new Mock<ICakeDataService>();
            _context = new CakeContext(FileSystem, Environment, Globber, new FakeLog(), argumentsMoq.Object, ProcessRunner, registryMoq.Object, Tools, dataService.Object, Configuration);
        }

        protected override void RunTool()
        {
            if (Settings != null)
            {
                _context.TransifexInit(Settings);
            }
            else
            {
                _context.TransifexInit();
            }
        }
    }

    public class TransifexAliasesPullFixture : TransifexPullFixture
    {
        private static ICakeContext _context;

        public TransifexAliasesPullFixture()
        {
            var argumentsMoq = new Mock<ICakeArguments>();
            var registryMoq = new Mock<IRegistry>();
            var dataService = new Mock<ICakeDataService>();
            _context = new CakeContext(FileSystem, Environment, Globber, new FakeLog(), argumentsMoq.Object, ProcessRunner, registryMoq.Object, Tools, dataService.Object, Configuration);
        }

        protected override void RunTool()
        {
            if (Settings != null)
            {
                _context.TransifexPull(Settings);
            }
            else
            {
                _context.TransifexPull();
            }
        }
    }

    public class TransifexAliasesPushFixture : TransifexPushFixture
    {
        private static ICakeContext _context;

        public TransifexAliasesPushFixture()
        {
            var argumentsMoq = new Mock<ICakeArguments>();
            var registryMoq = new Mock<IRegistry>();
            var dataService = new Mock<ICakeDataService>();
            _context = new CakeContext(FileSystem, Environment, Globber, new FakeLog(), argumentsMoq.Object, ProcessRunner, registryMoq.Object, Tools, dataService.Object, Configuration);
        }

        protected override void RunTool()
        {
            if (Settings != null)
            {
                _context.TransifexPush(Settings);
            }
            else
            {
                _context.TransifexPush();
            }
        }
    }

    public class TransifexAliasesStatusFixture : TransifexStatusFixture
    {
        private static ICakeContext _context;

        public TransifexAliasesStatusFixture()
        {
            var argumentsMoq = new Mock<ICakeArguments>();
            var registryMoq = new Mock<IRegistry>();
            var dataService = new Mock<ICakeDataService>();
            _context = new CakeContext(FileSystem, Environment, Globber, new FakeLog(), argumentsMoq.Object, ProcessRunner, registryMoq.Object, Tools, dataService.Object, Configuration);
        }

        protected override void RunTool()
        {
            if (!string.IsNullOrEmpty(Resources))
            {
                _context.TransifexStatus(Resources);
            }
            else
            {
                _context.TransifexStatus();
            }
        }
    }

    public class TransifexInitFixture : ToolFixture<TransifexInitSettings>
    {
        public TransifexInitFixture()
            : base("tx")
        {
        }

        protected override void RunTool()
        {
            var tool = new TransifexRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Init(Settings);
        }
    }

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
