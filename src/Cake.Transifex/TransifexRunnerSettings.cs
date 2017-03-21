namespace Cake.Transifex
{
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// Defines common properties that can be used for all commands.
    /// </summary>
    /// <seealso cref="Cake.Transifex.TransifexRunnerSettings"/>
    public abstract class TransifexRunnerSettings<TSettingsType> : TransifexRunnerSettings
            where TSettingsType : TransifexRunnerSettings<TSettingsType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexRunnerSettings"/> class.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        protected TransifexRunnerSettings(string command)
            : base(command)
        {
        }

        /// <summary>
        /// The resources you want to use for this command (defaults to all)
        /// </summary>
        /// <remarks>Supports unix style wildcards</remarks>
        public string Resources { get; set; }

        internal override void Evaluate(ProcessArgumentBuilder args)
        {
            base.Evaluate(args);
            if (!string.IsNullOrWhiteSpace(Resources))
            {
                args.AppendQuoted("--resources={0}", Resources);
            }
        }
    }

    /// <summary>
    /// Defines common properties that can be used for all commands.
    /// </summary>
    /// <seealso cref="Cake.Core.Tooling.ToolSettings"/>
    public abstract class TransifexRunnerSettings : ToolSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexRunnerSettings"/> class.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        protected TransifexRunnerSettings(string command)
                    => Command = command;

        /// <summary>
        /// The transifex command to execute.
        /// </summary>
        protected string Command { get; }

        internal virtual void Evaluate(ProcessArgumentBuilder args)
        {
            args.Append(Command);
            EvaluateCore(args);
        }

        /// <summary>
        /// Evaluates the arguments and appends the necessary arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected abstract void EvaluateCore(ProcessArgumentBuilder args);
    }
}
