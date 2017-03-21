namespace Cake.Transifex
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Defines common properties that can be used for all commands touching a remote location.
    /// </summary>
    /// <seealso cref="Cake.Transifex.TransifexRunnerSettings{TSettingsType}"/>
    public abstract class TransifexRunnerRemoteSettings<TSettingsType> : TransifexRunnerSettings<TSettingsType>
        where TSettingsType : TransifexRunnerRemoteSettings<TSettingsType>
    {
        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="TransifexRunnerRemoteSettings{TSettingsType}"/> class.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public TransifexRunnerRemoteSettings(string command)
            : base(command)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether to force the command event if the resource exists.
        /// </summary>
        public bool Force { get; set; }

        /// <summary>
        /// The languages you want to push/pull. (defaults to all)
        /// </summary>
        /// <remarks>Supports unix style wildcards.</remarks>
        public string Languages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to continue with the command even if an error ocurs.
        /// </summary>
        public bool SkipErrors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether use the xliff format.
        /// </summary>
        public bool UseXliff { get; set; }

        internal override void Evaluate(ProcessArgumentBuilder args)
        {
            base.Evaluate(args);
            if (!string.IsNullOrWhiteSpace(Languages))
            {
                args.AppendQuoted("--language={0}", Languages);
            }

            if (Force)
            {
                args.Append("--force");
            }

            if (SkipErrors)
            {
                args.Append("--skip");
            }

            if (UseXliff)
            {
                args.Append("--xliff");
            }
        }
    }
}
