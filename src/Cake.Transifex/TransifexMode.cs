namespace Cake.Transifex
{
    /// <summary>
    /// Specifies the mode of the translation file to pull
    /// </summary>
    public enum TransifexMode
    {
        /// <summary>
        /// Only pull down reviewed translations.
        /// </summary>
        /// <remarks>
        /// All translations that have not been reviewed will either be empty, or be in the source
        /// language (depending on the file format used)
        /// </remarks>
        Reviewed,

        /// <summary>
        /// Pull down all translations, whether they have been translated or not.
        /// </summary>
        /// <remarks>These are files suitable for usage by developers in their source code tree.</remarks>
        Developer,

        /// <summary>
        /// Pull down all completed translations, whether they have been reviewed or not.
        /// </summary>
        /// <remarks>These are files suitable for offline translation of the resource(s).</remarks>
        Translator,

        /// <summary>
        /// Pull down only strings that have been translated.
        /// </summary>
        OnlyTranslated,

        /// <summary>
        /// Pull down only strings that have been translated and reviewed.
        /// </summary>
        OnlyReviewed,

        /// <summary>
        /// Pull down both translated and untranslated strings (untranslated strings will be set to
        /// the value of the source).
        /// </summary>
        SourceAsTranslation
    }
}
