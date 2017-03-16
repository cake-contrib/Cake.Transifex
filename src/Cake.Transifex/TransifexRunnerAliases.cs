namespace Cake.Transifex
{
    using System;
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
            => TransifexPull(context, (opts) => { });

        /// <summary>
        /// This command pulls all outstanding changes from the remote Transifex server to the local
        /// repository. By default, only the files that are watched by Transifex will be updated but
        /// if you want to fetch the translations for new languages as well, set the <see
        /// cref="TransifexPullSettings.All"/> property to <c>true</c> in the <paramref name="settingsAction"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settingsAction">The settings action to configure different options.</param>
        /// <example>
        /// <para>Run 'tx pull' with additional options</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Transifex-Pull")
        ///     .Does(() =>
        /// {
        ///     TransifexPull(options =>
        ///     {
        ///         options.All = true;
        ///         options.MinimumPercentage = 75;
        ///         options.Mode = TransifexMode.Reviewed;
        ///     });
        /// };
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void TransifexPull(this ICakeContext context, Action<TransifexPullSettings> settingsAction)
        {
            var settings = InitializeSettings(settingsAction);
            TransifexPull(context, settings);
        }

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
            => TransifexPush(context, (opts) => { });

        /// <summary>
        /// This command pushes all local files that have been added to Transifex to the remote
        /// server. All new translations are merged with existing ones and if a language doesn't
        /// exist then it gets created. If you want to push the source file as well (either because
        /// this is your first time running the client or because you have updated with new entries),
        /// set the <see cref="TransifexPushSettings.Source"/> to <c>true</c>. By default, this
        /// command will push all files which are watched by Transifex but you can filter this per
        /// resource or/and language.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settingsAction">The settings action to configure different options.</param>
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
        public static void TransifexPush(this ICakeContext context, Action<TransifexPushSettings> settingsAction)
        {
            var settings = InitializeSettings(settingsAction);
            TransifexPush(context, settings);
        }

        /// <summary>
        /// This command pushes all local files that have been added to Transifex to the remote
        /// server. All new translations are merged with existing ones and if a language doesn't
        /// exist then it gets created. If you want to push the source file as well (either because
        /// this is your first time running the client or because you have updated with new entries),
        /// set the <see cref="TransifexPushSettings.Source"/> to <c>true</c>. By default, this
        /// command will push all files which are watched by Transifex but you can filter this per
        /// resource or/and language.
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

        private static TSettings InitializeSettings<TSettings>(Action<TSettings> settingsAction)
                    where TSettings : TransifexRunnerSettings, new()
        {
            if (settingsAction == null)
            {
                throw new ArgumentNullException(nameof(settingsAction));
            }

            var settings = new TSettings();
            settingsAction(settings);

            return settings;
        }
    }
}
