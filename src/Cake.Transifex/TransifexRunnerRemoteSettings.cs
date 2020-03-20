namespace Cake.Transifex
{
    /// <summary>
    /// Defines common properties that can be used for all commands touching a remote location.
    /// </summary>
    /// <seealso cref="TransifexRunnerSettings{TSettingsType}"/>
    public class TransifexRunnerRemoteSettings<TSettingsType> : TransifexRunnerSettings<TSettingsType>
        where TSettingsType : TransifexRunnerRemoteSettings<TSettingsType>
    {
        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="TransifexRunnerRemoteSettings{TSettingsType}"/> class.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        protected TransifexRunnerRemoteSettings(string command)
            : base(command)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether to force the command event if the resource exists.
        /// </summary>
        public bool Force
        {
            get => GetValue<bool>("--force");
            set => SetValue("--force", value);
        }

        /// <summary>
        /// The languages you want to push/pull. (defaults to all)
        /// </summary>
        /// <remarks>Supports unix style wildcards.</remarks>
        public string Languages
        {
            get => GetValue<string>("--language");
            set => SetValue("--language", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to continue with the command even if an error ocurs.
        /// </summary>
        public bool SkipErrors
        {
            get => GetValue<bool>("--skip");
            set => SetValue("--skip", value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether use the xliff format.
        /// </summary>
        public bool UseXliff
        {
            get => GetValue<bool>("--xliff");
            set => SetValue("--xliff", value);
        }
    }
}
