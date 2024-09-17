namespace Cake.Transifex.Tests
{
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Testing;
    using Cake.Testing.Fixtures;
    using Cake.Transifex.Runners;
    using Cake.Transifex.Settings;
    using NSubstitute;
    using System;

    [Obsolete("Will be removed in v4")]
    public class TransifexAliasesInitFixture : TransifexInitFixture
    {
        private static ICakeContext _context;

        public TransifexAliasesInitFixture()
        {
            var argumentsMoq = Substitute.For<ICakeArguments>();
            var registryMoq = Substitute.For<IRegistry>();
            var dataService = Substitute.For<ICakeDataService>();
            _context = new CakeContext(FileSystem, Environment, Globber, new FakeLog(), argumentsMoq, ProcessRunner, registryMoq, Tools, dataService, Configuration);
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

    [Obsolete("Will be removed in v4")]
    public class TransifexAliasesPullFixture : TransifexPullFixture
    {
        private static ICakeContext _context;

        public TransifexAliasesPullFixture()
        {
            var argumentsMoq = Substitute.For<ICakeArguments>();
            var registryMoq = Substitute.For<IRegistry>();
            var dataService = Substitute.For<ICakeDataService>();
            _context = new CakeContext(FileSystem, Environment, Globber, new FakeLog(), argumentsMoq, ProcessRunner, registryMoq, Tools, dataService, Configuration);
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

    [Obsolete("Will be removed in v4")]
    public class TransifexAliasesPushFixture : TransifexPushFixture
    {
        private static ICakeContext _context;

        public TransifexAliasesPushFixture()
        {
            var argumentsMoq = Substitute.For<ICakeArguments>();
            var registryMoq = Substitute.For<IRegistry>();
            var dataService = Substitute.For<ICakeDataService>();
            _context = new CakeContext(FileSystem, Environment, Globber, new FakeLog(), argumentsMoq, ProcessRunner, registryMoq, Tools, dataService, Configuration);
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

    [Obsolete("Will be removed in v4")]
    public class TransifexAliasesStatusFixture : TransifexStatusFixture
    {
        private static ICakeContext _context;

        public TransifexAliasesStatusFixture()
        {
            var argumentsMoq = Substitute.For<ICakeArguments>();
            var registryMoq = Substitute.For<IRegistry>();
            var dataService = Substitute.For<ICakeDataService>();
            _context = new CakeContext(FileSystem, Environment, Globber, new FakeLog(), argumentsMoq, ProcessRunner, registryMoq, Tools, dataService, Configuration);
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

    [Obsolete("Will be removed in v4")]
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

    [Obsolete("Will be removed in v4")]
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

    [Obsolete("Will be removed in v4")]
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

    [Obsolete("Will be removed in v4")]
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
