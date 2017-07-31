namespace Cake.Transifex
{
    using Cake.Core;
    using Cake.Core.Annotations;

    /// <summary>
    /// Provides a wrapper around transifex client functionality within a Cake build script.
    /// </summary>
    [CakeAliasCategory("Transifex")]
    [CakeNamespaceImport("Cake.Transifex")]
    public static class TransifexRunnerAliases
    {
        /// <summary>
        /// This command initializes the current repository with a default configuration file, and
        /// sets the host to <c>www.transifex.com</c>.
        /// </summary>
        /// <param name="context">The cake context</param>
        /// <para>Runs <c>tx init --host www.transifex.com</c> with the specified <paramref name="settings" /></para>
        /// <para>Cake task:</para>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// Task("Transifex-Init")
        ///     .Does(() =>
        /// {
        ///     TransifexInit();
        /// };
        /// ]]>
        /// </code>
        /// </example>
        public static void TransifexInit(this ICakeContext context)
            => TransifexInit(context, null);

        /// <summary>
        /// This command initializes the current repository with a default configuration file, and
        /// optionally the user configuration file with either a Username + Password combination or
        /// an API token.
        /// </summary>
        /// <param name="context">The cake context</param>
        /// <param name="settings">The settings to use when calling <c>tx init</c></param>
        /// <para>Runs <c>tx init</c> with the specified <paramref name="settings" /></para>
        /// <para>Cake task:</para>
        /// <example>
        /// <code title="Initialize with a username and password">
        /// <![CDATA[
        /// Task("Transifex-Init")
        ///     .Does(() =>
        /// {
        ///     var settings = new TransifexInitSettings
        ///     {
        ///         Username = "MY-AWESOME-USERNAME",
        ///         Password = "MY-SUPER-SECRET-PASSWORD"
        ///     };
        ///     TransifexInit(settings);
        /// };
        /// ]]>
        /// </code>
        /// <code title="Initialize with an API token">
        /// <![CDATA[
        /// Task("Transifex-Init")
        ///     .Does(() =>
        /// {
        ///     var settings = new TransifexInitSettings
        ///     {
        ///         Token = "API-TOKEN-HERE"
        ///     };
        ///     TransifexInit(settings);
        /// };
        /// ]]>
        /// </code>
        /// </example>
        /// <exception cref="System.ArgumentException">
        /// Thrown when both the <see cref="TransifexInitSettings.Token" /> property and either
        /// the <see cref="TransifexInitSettings.Username" /> or <see cref="TransifexInitSettings.Password" /> properties have been
        /// specified in the <paramref name="settings" /> parameter.
        /// </exception>
        public static void TransifexInit(this ICakeContext context, TransifexInitSettings settings)
        {
            var runner = CreateRunner(context);

            runner.Init(settings);
        }

        /// <summary>
        /// This command pulls all outstanding changes from the remote Transifex server to the local
        /// repository. By default only the files that are watched by transifex will be updated.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <para>Run 'tx pull'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Transifex-Pull")
        ///     .Does(() =>
        /// {
        ///     TransifexPull();
        /// };
        /// ]]>
        /// </code>
        [CakeMethodAlias]
        public static void TransifexPull(this ICakeContext context)
            => TransifexPull(context, null);

        /// <summary>
        /// This command pulls all outstanding changes from the remote Transifex server to the local
        /// repository. By default, only the files that are watched by Transifex will be updated but
        /// if you want to fetch the translations for new languages as well, set the <see
        /// cref="TransifexPullSettings.All"/> property to <c>true</c> in the <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Run 'tx pull' with additional options</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Transifex-Pull")
        ///     .Does(() =>
        /// {
        ///     var settings = new TransifexPullSettings
        ///     {
        ///         All = true,
        ///         MinimumPercentage = 75,
        ///         Mode = TransifexMode.Reviewed
        ///     };
        ///     TransifexPull(settings);
        /// };
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TransifexPull(this ICakeContext context, TransifexPullSettings settings)
        {
            var runner = CreateRunner(context);

            runner.Pull(settings);
        }

        /// <summary>
        /// This command pushes all local files that have been added to Transifex to the remote
        /// server. All new translations are merged with existing ones and if a language doesn't
        /// exist then it is created.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <para>Run 'tx push'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Transifex-Push")
        ///     .Does(() =>
        /// {
        ///     TransifexPush();
        /// };
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TransifexPush(this ICakeContext context)
            => TransifexPush(context, null);

        /// <summary>
        /// This command pushes all local files that have been added to Transifex to the remote
        /// server. All new translations are merged with existing ones and if a language doesn't
        /// exist then it gets created. If you want to push the source file as well (either because
        /// this is your first time running the client or because you have updated with new entries),
        /// set the <see cref="TransifexPushSettings.UploadSourceFiles"/> to <c>true</c>. By default,
        /// this command will push all files which are watched by Transifex but you can filter this
        /// per resource or/and language.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Run 'tx push' with additional arguments</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Transifex-Push")
        ///     .Does(() =>
        /// {
        ///     TransifexPush(options =>
        ///     {
        ///         options.UploadSourceFiles = true;
        ///         options.UploadTranslations = true;
        ///     });
        /// };
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TransifexPush(this ICakeContext context, TransifexPushSettings settings)
        {
            var runner = CreateRunner(context);
            runner.Push(settings);
        }

        /// <summary>
        /// Prints the status of the current project by reading the data in the configuration file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <para>Run 'tx status'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Transifex-Status")
        ///     .Does(() =>
        /// {
        ///     TransifexStatus();
        /// };
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TransifexStatus(this ICakeContext context)
            => TransifexStatus(context, null);

        /// <summary>
        /// Prints the status of the current project by reading the data in the configuration file,
        /// but only for the specified <paramref name="resources"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="resources">The resources.</param>
        /// <example>
        /// <para>Run 'tx status "--resources=resource.name"'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Transifex-Status")
        ///     .Does(() =>
        /// {
        ///     TransifexStatus("cake.transifexresx");
        /// };
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TransifexStatus(this ICakeContext context, string resources)
        {
            var runner = CreateRunner(context);

            runner.Status(resources);
        }

        private static TransifexRunner CreateRunner(ICakeContext context)
            => new TransifexRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
    }
}
