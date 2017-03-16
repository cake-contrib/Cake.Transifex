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
        Reviewed,

        /// <summary>
        /// Pull down all translations, whether they have been translated or not.
        /// </summary>
        Developer,

        /// <summary>
        /// Pull down all completed translations, whether they have been reviewed or not.
        /// </summary>
        Translator
    }
}
