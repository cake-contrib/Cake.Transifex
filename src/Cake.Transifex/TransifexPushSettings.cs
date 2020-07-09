namespace Cake.Transifex
{
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
        /// Gets or sets a value indicating whether to push the source file to the remote server.
        /// </summary>
        /// <value><see langword="true"/> to push the source file; otherwise, <see langword="false"/>.</value>
        public bool UploadSourceFiles
        {
            get => GetValue<bool>("--source");
            set => SetValue("--source", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to push all local translations to the remote server.
        /// </summary>
        /// <value><see langword="true"/> to push all local translations; otherwise, <see langword="false"/>.</value>
        public bool UploadTranslations
        {
            get => GetValue<bool>("--translations");
            set => SetValue("--translations", value);
        }
    }
}
