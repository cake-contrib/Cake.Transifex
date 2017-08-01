namespace Cake.Transifex
{
    using System.Collections.Generic;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// The wrapper around the transifex client. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Cake.Core.Tooling.Tool{TSettings}"/>
    /// <seealso cref="Cake.Transifex.ITransifexRunnerCommands"/>
    internal sealed class TransifexRunner : Tool<TransifexRunnerSettings>, ITransifexRunnerCommands
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        internal TransifexRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public ITransifexRunnerCommands Init(TransifexInitSettings settings)
        {
            settings = settings ?? new TransifexInitSettings();
            var args = GetTransifexRunnerArguments(settings);
            Run(settings, args);
            return this;
        }

        public ITransifexRunnerCommands Pull(TransifexPullSettings settings)
        {
            settings = settings ?? new TransifexPullSettings();
            var args = GetTransifexRunnerArguments(settings);
            Run(settings, args);
            return this;
        }

        public ITransifexRunnerCommands Push(TransifexPushSettings settings)
        {
            settings = settings ?? new TransifexPushSettings();
            var args = GetTransifexRunnerArguments(settings);
            Run(settings, args);
            return this;
        }

        public ITransifexRunnerCommands Status(string resources)
        {
            var settings = new TransifexStatusSettings()
            {
                Resources = resources
            };

            var args = GetTransifexRunnerArguments(settings);
            Run(settings, args);
            return this;
        }

        protected override IEnumerable<string> GetToolExecutableNames()
            => new[]
            {
                "tx.cmd",
                "tx.exe",
                "tx"
            };

        protected override string GetToolName()
            => "Transifex Runner";

        private static ProcessArgumentBuilder GetTransifexRunnerArguments(TransifexRunnerSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings.Evaluate(args);
            return args;
        }
    }
}
