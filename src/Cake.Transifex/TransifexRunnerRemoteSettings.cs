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
        /// Gets or sets the branch to use when pulling/pushing translations.
        /// Source files and translations pushed/updated on other branches will
        /// not be pulled.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        ///   <item>
        ///      <term>Required transifex client</term>
        ///      <description>v0.13.0</description>
        ///   </item>
        ///   <item>
        ///      <term>Required Cake.Transifex version</term>
        ///      <description>v0.9.0</description>
        ///   </item>
        /// </list>
        /// </remarks>
        public string Branch
        {
            get => GetValue<string>("--branch");
            set => SetValue("--branch", value);
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
        /// Gets or sets a value indicating whether to require user input when forcing a push/pull.
        /// </summary>
        /// <value><see langword="true"/> to don't require user input; otherwise, <see langword="false"/>.</value>
        /// <remarks>
        /// <list type="bullet">
        ///   <item>
        ///      <term>Required transifex client</term>
        ///      <description>v0.13.3</description>
        ///   </item>
        ///   <item>
        ///      <term>Required Cake.Transifex version</term>
        ///      <description>v0.9.0</description>
        ///   </item>
        /// </list>
        /// </remarks>
        public bool NoInteractive
        {
            get => GetValue<bool>("--no-interactive");
            set => SetValue("--no-interactive", value);
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
        /// Gets or sets a value indicating wether translations/sources should be pushed/pulled in parallel.
        /// </summary>
        /// <value><see langword="true"/> to pull/push files in parallel; otherwise <see langword="false"/>.</value>
        /// <remarks>
        /// <list type="bullet">
        ///   <item>
        ///     <term>WARNING</term>
        ///     <description>Be carefult with enabling parallel downloads/uploads. You may be Rate Limited</description>
        ///   </item>
        ///   <item>
        ///      <term>Required transifex client</term>
        ///      <description>v0.13.2</description>
        ///   </item>
        ///   <item>
        ///      <term>Required Cake.Transifex version</term>
        ///      <description>v0.9.0</description>
        ///   </item>
        /// </list>
        /// </remarks>
        public bool Parallel
        {
            get => GetValue<bool>("--parallel");
            set => SetValue("--parallel", value);
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
        /// Gets or set wether to use git timestamps when comparing commited files timestamp with corresponding
        /// file on transifex.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        ///   <item>
        ///      <term>Required transifex client</term>
        ///      <description>v0.13.10</description>
        ///   </item>
        ///   <item>
        ///      <term>Required Cake.Transifex version</term>
        ///      <description>v0.9.0</description>
        ///   </item>
        /// </list>
        /// </remarks>
        public bool UseGitTimestamps
        {
            get => GetValue<bool>("--use-git-timestamps");
            set => SetValue("--use-git-timestamps", value);
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
