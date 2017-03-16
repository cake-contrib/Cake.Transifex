namespace Cake.Transifex
{
    using Cake.Core.IO;

    /// <summary>
    /// Defines the properties that can be used when calling the status command on the transifex
    /// client. This class cannot be inherited
    /// </summary>
    /// <seealso cref="Cake.Transifex.TransifexRunnerSettings{TSettingsType}"/>
    public sealed class TransifexStatusSettings : TransifexRunnerSettings<TransifexStatusSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexStatusSettings"/> class.
        /// </summary>
        public TransifexStatusSettings()
            : base("status")
        {
        }

        /// <summary>
        /// Evaluates the arguments and appends the necessary arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            // There is no additional arguments for the status command
        }
    }
}
