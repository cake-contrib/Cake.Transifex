// <copyright file="TxPullSettings.cs" company="Cake Contrib">
// Copyright (c) 2017-2024 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex.Settings;

using System;
using System.Collections.Generic;

using Cake.Transifex.Enums;

/// <summary>
///     Defines the arguments available when pulling down translations
///     from transifex.
/// </summary>
/// <seealso cref="TxGlobalSettings" />
public sealed class TxPullSettings : TxGlobalSettings
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="TxPullSettings" /> class.
    /// </summary>
    public TxPullSettings()
        : base("pull")
    {
    }

    /// <summary>
    ///     Gets or sets the name of the current branch to use when
    ///     pulling files.
    /// </summary>
    /// <value>The name of the branch to pull files from.</value>
    /// <remarks>
    ///     Set the property as an empty string to have the tx utility try
    ///     resolving the current branch name.
    /// </remarks>
    public string Branch
    {
        get => GetAppendedValue<string>("--branch");
        set => AppendValue("--branch", value, allowEmptyValue: true);
    }

    /// <summary>
    ///     Gets or sets the content encoding to use.
    /// </summary>
    /// <value>The content encoding.</value>
    public ContentEncodings ContentEncoding
    {
        get => GetAppendedValue("--content_encoding", ContentEncodings.Text);
        set => AppendValue("--content_encoding", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether existing files should
    ///     be overwritten.
    /// </summary>
    /// <value>
    ///     <c>true</c> to overwrite files; otherwise, <c>false</c>.
    /// </value>
    public bool DisableOverwrite
    {
        get => GetAppendedValue("--disable-overwrite", false);
        set => AppendValue("--disable-overwrite", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether all files should be
    ///     downloaded no matter what the status is.
    /// </summary>
    /// <value>
    ///     <c>true</c> to download all files; otherwise, <c>false</c>.
    /// </value>
    public bool DownloadAllFiles
    {
        get => GetAppendedValue("--all", false);
        set => AppendValue("--all", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether to download
    ///     translations as JSON files.
    /// </summary>
    /// <value>
    ///     <c>true</c> if to download JSON files; otherwise,
    ///     <c>false</c>.
    /// </value>
    public bool DownloadJsonFiles
    {
        get => GetAppendedValue("--json", false);
        set => AppendValue("--json", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the source files
    ///     should be downloaded.
    /// </summary>
    /// <value>
    ///     <c>true</c> to download the source files; otherwise,
    ///     <c>false</c>.
    /// </value>
    public bool DownloadSourceFile
    {
        get => GetAppendedValue("--source", false);
        set => AppendValue("--source", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether translation files
    ///     should be downloaded.
    /// </summary>
    /// <value>
    ///     <c>true</c> to download translation files; otherwise,
    ///     <c>false</c>.
    /// </value>
    public bool DownloadTranslationFiles
    {
        get => GetAppendedValue("--translations", false);
        set => AppendValue("--translations", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether to download
    ///     translations as xliff files.
    /// </summary>
    /// <value>
    ///     <c>true</c> to download xliff files; otherwise, <c>false</c>.
    /// </value>
    public bool DownloadXliffFiles
    {
        get => GetAppendedValue("--xliff", false);
        set => AppendValue("--xliff", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether files that are still
    ///     up to date should be downloaded or not.
    /// </summary>
    /// <value>
    ///     <c>true</c> to download files that are up to date; otherwise,
    ///     <c>false</c>.
    /// </value>
    public bool ForceDownloads
    {
        get => GetAppendedValue("--force", false);
        set => AppendValue("--force", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether to create new files
    ///     with the .new file extension.
    /// </summary>
    /// <value>
    ///     <c>true</c> to keep new files; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    ///     Used together when the <see cref="DisableOverwrite" /> is
    ///     <c>true</c>.
    /// </remarks>
    public bool KeepNewFiles
    {
        get => GetAppendedValue("--keep-new-files", false);
        set => AppendValue("--keep-new-files", value);
    }

    /// <summary>
    ///     Gets or sets the languages that should be downloaded.
    /// </summary>
    /// <value>The languages to download.</value>
    public ICollection<string> Languages
    {
        get => GetAppendedCollectionValue<string>("--languages");
        set => AppendValue("--languages", value);
    }

    /// <summary>
    ///     Gets or sets the minimum acceptable percentage of a
    ///     translation mode in order to download it.
    /// </summary>
    /// <value>
    ///     The minimum acceptable percentage for the mode for it to be
    ///     downloaded.
    /// </value>
    public short MinimumPercentage
    {
        get => GetAppendedValue<short>("--minimum-perc", -1);
        set
        {
            Expects.Range(1, 100, value, nameof(MinimumPercentage));

            AppendValue("--minimum-perc", value);
        }
    }

    /// <summary>
    ///     Gets or sets the mode to use when downloading translations.
    /// </summary>
    /// <value>The mode to use when downloading translations.</value>
    public PullMode Mode
    {
        get => GetAppendedValue("--mode", PullMode.Default);
        set => AppendValue("--mode", value);
    }

    /// <summary>
    ///     Gets or sets the amount of parallel workers to use when
    ///     downloading files.
    /// </summary>
    /// <value>The amount of parallel workers.</value>
    /// <remarks>
    ///     The tx client defaults to 5 workers, with a maximum value of
    ///     20 workers.
    /// </remarks>
    public byte ParallelWorkers
    {
        get => GetAppendedValue<byte>("--workers", 5);
        set
        {
            Expects.Range(1, 20, value, nameof(ParallelWorkers));

            AppendValue("--workers", value);
        }
    }

    /// <summary>
    ///     Gets or sets a value indicating whether pulling translations
    ///     should generate mock strings.
    /// </summary>
    /// <value>
    ///     <c>true</c> to generate mock strings; otherwise, <c>false</c>.
    /// </value>
    public bool Pseudo
    {
        get => GetAppendedValue("--pseudo", false);
        set => AppendValue("--pseudo", value);
    }

    /// <summary>
    ///     Gets or sets the resources to download.
    /// </summary>
    /// <value>The resources to download.</value>
    public ICollection<string> Resources
    {
        get => GetAppendedCollectionValue<string>("--resources");
        set => AppendValue("--resources", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the tx client should
    ///     reduce its verbosity or not.
    /// </summary>
    /// <value><c>true</c> if silent; otherwise, <c>false</c>.</value>
    public bool Silent
    {
        get => GetAppendedValue("--silent", false);
        set => AppendValue("--silent", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether errors should be
    ///     ignored.
    /// </summary>
    /// <value>
    ///     <c>true</c> to ignore errors; otherwise, <c>false</c>.
    /// </value>
    public bool SkipErrors
    {
        get => GetAppendedValue("--skip", false);
        set => AppendValue("--skip", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether local files should be
    ///     compared with their transifex equivalent based on the git
    ///     timestamp.
    /// </summary>
    /// <value>
    ///     <c>true</c> if files should be compared using git timestamps;
    ///     otherwise, <c>false</c>.
    /// </value>
    public bool UseGitTimestamps
    {
        get => GetAppendedValue("--use-git-timestamps", false);
        set => AppendValue("--use-git-timestamps", value);
    }
}
