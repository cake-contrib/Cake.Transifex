// <copyright file="TxAliases.cs" company="Cake Contrib">
// Copyright (c) 2017-2024 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex.Aliases;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.Transifex.Runners;
using Cake.Transifex.Settings;

/// <summary>
/// Contains aliases to communicate with the latest tx executable.
/// </summary>
[CakeAliasCategory("Localization")]
[CakeNamespaceImport("Cake.Transifex.Enums")]
[CakeNamespaceImport("Cake.Transifex.Aliases")]
[CakeNamespaceImport("Cake.Transifex.Settings")]
public static class TxAliases
{
    /// <summary>
    /// Initializes the current git repository with a default configuration file that can be used with Transifex.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings to use when initializing the repository.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("Transifex-Init")
    ///     .Does(() =>
    /// {
    ///     TxInit();
    /// });
    /// ]]>
    /// </code>
    /// <code>
    /// <![CDATA[
    /// Task("Transifex-Init")
    ///     .Does(() =>
    /// {
    ///     var settings = new TxInitSettings
    ///     {
    ///         Hostname = "www.transifex.com"
    ///     };
    ///     TxInit(settings);
    /// });
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    public static void TxInit(this ICakeContext context, TxInitSettings settings = null)
        => Run(context, settings ?? new TxInitSettings());

    /// <summary>
    /// Downloads the translated files from Transifex using a previously initialized configuration file.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="token">The token to use when authorizing with Transifex.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("Transifex-Pull")
    ///     .Does(() =>
    /// {
    ///     TxPull("transifex-authorization-token");
    /// });
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    public static void TxPull(this ICakeContext context, string token)
    {
        Expects.NotNullOrWhitespace(token);

        TxPull(context, new TxPullSettings
        {
            Token = token,
        });
    }

    /// <summary>
    /// Downloads the translated files from Transifex using a previously initialized configuration file.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings for the arguments to pass to the tx executable.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("Transifex-Pull")
    ///     .Does(() =>
    /// {
    ///     var settings = new TxPullSettings
    ///     {
    ///         DownloadAllFiles = true,
    ///         MinimumPercentage = 75,
    ///         Mode = PullMode.Reviewed,
    ///         Token = "transifex-authorization-token",
    ///         UseGitTimestamps = true,
    ///     };
    ///     TxPull(settings);
    /// });
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    public static void TxPull(this ICakeContext context, TxPullSettings settings)
        => Run(context, settings);

    /// <summary>
    /// Uploads all local source files to Transifex using the previously initalized configuration file.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="token">The token to use when authorizing with Transifex.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("Transifex-Push")
    ///     .Does(() =>
    /// {
    ///     TxPush("transifex-authorization-token");
    /// });
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    public static void TxPush(this ICakeContext context, string token)
    {
        Expects.NotNullOrWhitespace(token);

        TxPush(context, new TxPushSettings
        {
            Token = token,
        });
    }

    /// <summary>
    /// Uploads all local source files to Transifex using the previously initalized configuration file.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings for the arguments to pass to the tx executable.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("Transifex-Push")
    ///     .Does(() =>
    /// {
    ///     var settings = new TxPushSettings
    ///     {
    ///         Token = "transifex-authorization-token",
    ///         UploadSourceFile = true,
    ///         UseGitTimestamps = true,
    ///     };
    ///     TxPush(settings);
    /// });
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    public static void TxPush(this ICakeContext context, TxPushSettings settings)
        => Run(context, settings);

    /// <summary>
    /// Prints the status of the current project by reading the data in the configuration file.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="token">The token to use when authorizing with Transifex.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("Transifex-Status")
    ///     .Does(() =>
    /// {
    ///     TxStatus("transifex-authorization-token");
    /// });
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    public static void TxStatus(this ICakeContext context, string token)
    {
        Expects.NotNullOrWhitespace(token);

        TxStatus(context, new TxStatusSettings
        {
            Token = token,
        });
    }

    /// <summary>
    /// Prints the status of the current project by reading the data in the configuration file.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings for the arguments to pass to the tx executable.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// Task("Transifex-Status")
    ///     .Does(() =>
    /// {
    ///     var settings = new TxStatusSettings
    ///     {
    ///         Resources = new[] { "resource-name },
    ///         Token = "transifex-authorization-token"
    ///     };
    ///     TxStatus(settings);
    /// });]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    public static void TxStatus(this ICakeContext context, TxStatusSettings settings)
        => Run(context, settings);

    private static void Run(ICakeContext context, TxGlobalSettings settings)
    {
        Expects.NotNull(context);
        Expects.NotNull(settings);

        var runner = new TxRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);

        runner.Run(settings);
    }
}
