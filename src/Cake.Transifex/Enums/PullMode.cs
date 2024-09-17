// <copyright file="PullMode.cs" company="Cake Contrib">
// Copyright (c) 2017-2024 Kim J. Nordmo and Cake Contrib.
// Licensed under the MIT license. See LICENSE in the project.
// </copyright>

namespace Cake.Transifex.Enums;

/// <summary>
///     Specifies the mode of the translation file to pull.
/// </summary>
public enum PullMode
{
    /// <summary>
    ///     Use the default mode for translations.
    /// </summary>
    Default,

    /// <summary>
    ///     Only pull down reviewed translations.
    /// </summary>
    /// <remarks>
    ///     All translations that have not been reviewed will either be
    ///     empty, or be in the source language (depending on the file
    ///     format used)
    /// </remarks>
    Reviewed,

    /// <summary>
    ///     Pull down all translations that have been proof read.
    /// </summary>
    /// <remarks>
    ///     All translations that have not been proof read will either be
    ///     empty, or be in the source language (depending on the file
    ///     format used).
    /// </remarks>
    Proofread,

    /// <summary>
    ///     Pull down all completed translations, whether they have been
    ///     reviewed or not.
    /// </summary>
    /// <remarks>
    ///     These are files suitable for offline translation of the
    ///     resource(s).
    /// </remarks>
    Translator,

    /// <summary>
    ///     Pull down translation strings that has not been translated
    ///     yet.
    /// </summary>
    Untranslated,

    /// <summary>
    ///     Pull down only strings that have been translated.
    /// </summary>
    OnlyTranslated,

    /// <summary>
    ///     Pull down only strings that have been translated and reviewed.
    /// </summary>
    OnlyReviewed,

    /// <summary>
    ///     Pull down only strings that have been proofread.
    /// </summary>
    OnlyProofread,

    /// <summary>
    ///     Pull down both translated and untranslated strings
    ///     (untranslated strings will be set to the value of the source).
    /// </summary>
    SourceAsTranslation,
}
