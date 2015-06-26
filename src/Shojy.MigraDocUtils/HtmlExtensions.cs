// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlExtensions.cs" company="Joshua Moon">
//     (c) 2015 Joshua Moon
// </copyright>
// <summary>
// The extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shojy.MigraDocUtils
{
    using MigraDoc.DocumentObjectModel;

    /// <summary>
    /// The extensions.
    /// </summary>
    public static class HtmlExtensions
    {
        /// <summary>
        /// The add html text.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="html">The html.</param>
        /// <returns>The <see cref="FormattedText" />.</returns>
        public static Paragraph AddHtmlText(this Section section, string html)
        {
            return section.AddParagraph();
        }

        /// <summary>
        /// The add html text.
        /// </summary>
        /// <param name="paragraph">The paragraph.</param>
        /// <param name="html">The html.</param>
        /// <returns>The <see cref="FormattedText" />.</returns>
        public static FormattedText AddHtmlText(this Paragraph paragraph, string html)
        {
            return paragraph.AddFormattedText();
        }
    }
}