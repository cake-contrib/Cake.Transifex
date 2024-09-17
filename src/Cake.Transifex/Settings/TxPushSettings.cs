// <copyright file="TxPushSettings.cs" company="Cake Contrib">
// Copyright (c) 2017-2024 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex.Settings;

using System;
using System.Collections.Generic;

/// <summary>
///     Defines the arguments that are available when pushing source or
///     translation files.
/// </summary>
/// <seealso cref="TxGlobalSettings" />
public sealed class TxPushSettings : TxGlobalSettings
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="TxPushSettings" /> class.
    /// </summary>
    public TxPushSettings()
        : base("push")
    {
    }

    /// <summary>
    ///     Gets or sets name of the base branch to use when pushing
    ///     sources.
    /// </summary>
    /// <value>The name to use as a base branch.</value>
    /// <remarks>
    ///     If a name is not set, the main resource will be used as the
    ///     base.
    /// </remarks>
    public string Base
    {
        get => GetAppendedValue<string>("--base");
        set => AppendValue("--base", value);
    }

    /// <summary>
    ///     Gets or sets the name of the current branch to use when
    ///     pushing sources.
    /// </summary>
    /// <value>The name to use as the current branch.</value>
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
    ///     Gets or sets a value indicating whether to create missing
    ///     languages on the remote server when possible.
    /// </summary>
    /// <value>
    ///     <c>true</c> if the server should try creating missing
    ///     languages; otherwise, <c>false</c>.
    /// </value>
    public bool CreateMissingLanguages
    {
        get => GetAppendedValue("--all", false);
        set => AppendValue("--all", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether all files sholud be
    ///     pushed without checking the modification time first.
    /// </summary>
    /// <value>
    ///     <c>true</c> to push all files no matter when it was modified;
    ///     otherwise, <c>false</c>.
    /// </value>
    public bool ForceUploads
    {
        get => GetAppendedValue("--force", false);
        set => AppendValue("--force", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether to keep translations
    ///     even when a source key changes.
    /// </summary>
    /// <value>
    ///     <c>true</c> to keep translations on source key changes;
    ///     otherwise, <c>false</c>.
    /// </value>
    public bool KeepTranslations
    {
        get => GetAppendedValue("--keep-translations", false);
        set => AppendValue("--keep-translations", value);
    }

    /// <summary>
    ///     Gets or sets the languages to upload.
    /// </summary>
    /// <value>The languages to upload.</value>
    public ICollection<string> Languages
    {
        get => GetAppendedCollectionValue<string>("--languages");
        set => AppendValue("--languages", value);
    }

    /// <summary>
    ///     Gets or sets the amount of parallel workers to use when
    ///     uploading files.
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
    ///     Gets or sets a value indicating whether to replace source
    ///     strings that have been edited.
    /// </summary>
    /// <value>
    ///     <c>true</c> if replacing edited source strings; otherwise,
    ///     <c>false</c>.
    /// </value>
    /// <remarks>
    ///     Free usage of Transifex does not allow editing source strings.
    /// </remarks>
    public bool ReplaceEditedStrings
    {
        get => GetAppendedValue("--replace-edited-strings", false);
        set => AppendValue("--replace-edited-strings", value);
    }

    /// <summary>
    ///     Gets or sets the resources to upload.
    /// </summary>
    /// <value>The resources to upload.</value>
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
    ///     Gets or sets a value indicating whether the source files
    ///     should be uploaded.
    /// </summary>
    /// <value>
    ///     <c>true</c> to upload the source files; otherwise,
    ///     <c>false</c>.
    /// </value>
    public bool UploadSourceFile
    {
        get => GetAppendedValue("--source", false);
        set => AppendValue("--source", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether translation files
    ///     should be uploaded.
    /// </summary>
    /// <value>
    ///     <c>true</c> to upload translation files; otherwise,
    ///     <c>false</c>.
    /// </value>
    public bool UploadTranslationFiles
    {
        get => GetAppendedValue("--translation", false);
        set => AppendValue("--translation", value);
    }

    /// <summary>
    ///     Gets or sets a value indicating whether to upload xliff files.
    /// </summary>
    /// <value>
    ///     <c>true</c> to upload xliff files; otherwise, <c>false</c>.
    /// </value>
    public bool UploadXliffFiles
    {
        get => GetAppendedValue("--xliff", false);
        set => AppendValue("--xliff", value);
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
