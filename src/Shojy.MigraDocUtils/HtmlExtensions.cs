// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlExtensions.cs" company="Joshua Moon">
//     (c) Copyright Joshua Moon 2015
// </copyright>
// <summary>
// The extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Shojy.MigraDocUtils
{
    using HtmlAgilityPack;

    using MigraDoc.DocumentObjectModel;

    /// <summary>
    /// The extensions.
    /// </summary>
    public static class HtmlExtensions
    {
        #region Public Methods

        /// <summary>
        /// Appends text formatted in HTML to the section.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="html">The html.</param>
        /// <returns>The <see cref="FormattedText" />.</returns>
        public static Section AddHtmlText(this Section section, string html)
        {
            return (Section)RenderFromHtmlString(html, section);
        }

        /// <summary>
        /// Appends text formatted in HTML to the paragraph.
        /// </summary>
        /// <param name="paragraph">The paragraph.</param>
        /// <param name="html">The html.</param>
        /// <returns>The <see cref="FormattedText" />.</returns>
        public static Paragraph AddHtmlText(this Paragraph paragraph, string html)
        {
            return (Paragraph)RenderFromHtmlString(html, paragraph);
        }

        /// <summary>
        /// Appends text formatted as HTML to the text.
        /// </summary>
        /// <param name="text">The paragraph.</param>
        /// <param name="html">The html.</param>
        /// <returns>The <see cref="FormattedText" />.</returns>
        public static FormattedText AddHtmlText(this FormattedText text, string html)
        {
            return text.AddFormattedText();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Recurses though the children of the given html element, or if the node is text, adds it
        /// as the leaf on the MigraDoc DOM tree.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="text">The text.</param>
        private static void RecurseNodes(HtmlNode element, FormattedText text)
        {
            // Recurse child elements
            foreach (var elem in element.ChildNodes)
            {
                switch (elem.NodeType)
                {
                    case HtmlNodeType.Text:
                        text.AddText(elem.InnerText);
                        break;

                    case HtmlNodeType.Document:
                    case HtmlNodeType.Element:
                        RenderHtmlElement(elem, text);
                        break;
                }
            }
        }

        /// <summary>
        /// The render from html string.
        /// </summary>
        /// <param name="html">The html.</param>
        /// <param name="root">The root.</param>
        /// <returns>The <see cref="DocumentObject" />.</returns>
        private static DocumentObject RenderFromHtmlString(string html, DocumentObject root)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            doc.OptionOutputAsXml = true;

            var rootNode = doc.DocumentNode;

            foreach (var node in rootNode.ChildNodes)
            {
                if (root is Section)
                {
                    RenderHtmlElement(node, ((Section)root).AddParagraph());
                }
                else if (root is Paragraph)
                {
                    RenderHtmlElement(node, ((Paragraph)root).AddFormattedText());
                }
                else if (root is FormattedText)
                {
                    RenderHtmlElement(node, (FormattedText)root);
                }
            }

            return root;
        }

        /// <summary>
        /// The render html element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="text">The text.</param>
        private static void RenderHtmlElement(HtmlNode element, Paragraph text)
        {
            switch (element.Name.ToLower())
            {
                case "p":
                    text.Style = Styles.Paragraph;
                    break;

                case "h1":
                    text.Style = Styles.Heading1;
                    break;

                case "h2":
                    text.Style = Styles.Heading2;
                    break;

                case "h3":
                    text.Style = Styles.Heading3;
                    break;

                case "h4":
                    text.Style = Styles.Heading4;
                    break;

                case "h5":
                    text.Style = Styles.Heading5;
                    break;

                case "h6":
                    text.Style = Styles.Heading6;
                    break;
            }

            RecurseNodes(element, text.AddFormattedText());
        }

        /// <summary>
        /// The render html element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="text">The text.</param>
        private static void RenderHtmlElement(HtmlNode element, FormattedText text)
        {
            switch (element.Name.ToLower())
            {
                case "b":
                case "strong":
                    text = text.AddFormattedText(TextFormat.Bold);
                    break;

                case "i":
                case "em":
                    text = text.AddFormattedText(TextFormat.Italic);
                    break;

                case "u":
                    text = text.AddFormattedText(TextFormat.Underline);
                    break;

                case "br":
                    text.AddLineBreak();
                    break;
            }

            RecurseNodes(element, text);
        }

        #endregion Private Methods
    }
}