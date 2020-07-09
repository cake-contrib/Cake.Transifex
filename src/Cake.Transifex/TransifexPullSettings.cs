namespace Cake.Transifex
{
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
        public bool All
        {
            get => GetValue<bool>("--all");
            set => SetValue("--all", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to disable overwrite of existing files.
        /// </summary>
        /// <value><see langword="true"/> if to disable overwrite; otherwise, <see langword="false"/>.</value>
        public bool DisableOverwrite
        {
            get => GetValue<bool>("--disable-overwrite");
            set => SetValue("--disable-overwrite", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to force downloading of the source file.
        /// </summary>
        /// <value><see langword="true"/> to download the source file; otherwise, <see langword="false"/>.</value>
        public bool DownloadSourceFiles
        {
            get => GetValue<bool>("--source");
            set => SetValue("--source", value);
        }

        /// <summary>
        /// Gets or sets the minimum acceptable percentage of a translation in order to download it.
        /// </summary>
        public int? MinimumPercentage
        {
            get => GetValue<int?>("--minimum-perc");
            set => SetValue("--minimum-perc", value);
        }

        /// <summary>
        /// Gets or sets the mode of the translation file to pull.
        /// </summary>
        /// <value>The mode.</value>
        public TransifexMode? Mode
        {
            get => GetValue<TransifexMode?>("--mode");
            set => SetValue("--mode", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to download the pseudo file.
        /// </summary>
        /// <value><see langword="true"/> to download the pseudo file; otherwise, <see langword="false"/>.</value>
        public bool Pseudo
        {
            get => GetValue<bool>("--pseudo");
            set => SetValue("--pseudo", value);
        }
    }
}
