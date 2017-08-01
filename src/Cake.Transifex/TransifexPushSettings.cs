namespace Cake.Transifex
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Defines the properties that can be used when calling the push command on the transifex
    /// client. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Cake.Transifex.TransifexRunnerRemoteSettings{TSettingsType}"/>
    public sealed class TransifexPushSettings : TransifexRunnerRemoteSettings<TransifexPushSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexPushSettings"/> class.
        /// </summary>
        public TransifexPushSettings()
            : base("push")
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether to require user input when forcing a push.
        /// </summary>
        /// <value><see langword="true"/> to don't require user input; otherwise, <see langword="false"/>.</value>
        public bool NoInteractive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to push the source file to the remote server.
        /// </summary>
        /// <value><see langword="true"/> to push the source file; otherwise, <see langword="false"/>.</value>
        public bool UploadSourceFiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to push all local translations to the remote server.
        /// </summary>
        /// <value><see langword="true"/> to push all local translations; otherwise, <see langword="false"/>.</value>
        public bool UploadTranslations { get; set; }

        /// <summary>
        /// Evaluates the arguments and appends the necessary arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (NoInteractive)
            {
                args.Append("--no-interactive");
            }

            if (UploadSourceFiles)
            {
                args.Append("--source");
            }

            if (UploadTranslations)
            {
                args.Append("--translations");
            }
        }
    }
}
