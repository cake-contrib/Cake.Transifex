namespace Cake.Transifex
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Defines the properties that can be used when calling the pull command on the transifex
    /// client. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Cake.Transifex.TransifexRunnerRemoteSettings{TSettingsType}"/>
    public sealed class TransifexPullSettings : TransifexRunnerRemoteSettings<TransifexPullSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransifexPullSettings"/> class.
        /// </summary>
        public TransifexPullSettings()
            : base("pull")
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether to pull down all languages (even new ones).
        /// </summary>
        /// <value><see langword="true"/> if to pull down all languages all; otherwise, <see langword="false"/>.</value>
        public bool All { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to disable overwrite of existing files.
        /// </summary>
        /// <value><see langword="true"/> if to disable overwrite; otherwise, <see langword="false"/>.</value>
        public bool DisableOverwrite { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force downloading of the source file.
        /// </summary>
        /// <value><see langword="true"/> to download the source file; otherwise, <see langword="false"/>.</value>
        public bool DownloadSourceFiles { get; set; }

        /// <summary>
        /// Gets or sets the minimum acceptable percentage of a translation in order to download it.
        /// </summary>
        public int? MinimumPercentage { get; set; }

        /// <summary>
        /// Gets or sets the mode of the translation file to pull.
        /// </summary>
        /// <value>The mode.</value>
        public TransifexMode? Mode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to download the pseudo file.
        /// </summary>
        /// <value><see langword="true"/> to download the pseudo file; otherwise, <see langword="false"/>.</value>
        public bool Pseudo { get; set; }

        /// <summary>
        /// Evaluates the arguments and appends the necessary arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (All)
            {
                args.Append("--all");
            }

            if (DisableOverwrite)
            {
                args.Append("--disable-overwrite");
            }

            if (MinimumPercentage.HasValue)
            {
                args.Append("--minimum-perc={0}", MinimumPercentage.Value);
            }

            if (Mode.HasValue)
            {
                args.Append("--mode={0}", Mode.ToString().ToLowerInvariant());
            }

            if (Pseudo)
            {
                args.Append("--pseudo");
            }

            if (DownloadSourceFiles)
            {
                args.Append("--source");
            }
        }
    }
}
