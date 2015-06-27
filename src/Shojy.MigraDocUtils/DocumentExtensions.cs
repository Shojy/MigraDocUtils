// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentExtensions.cs" company="Joshua Moon">
//     (c) Copyright Joshua Moon 2015
// </copyright>
// <summary>
// The document extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Shojy.MigraDocUtils
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MigraDoc.DocumentObjectModel;
    using MigraDoc.DocumentObjectModel.Shapes;
    using MigraDoc.DocumentObjectModel.Tables;

    /// <summary>
    /// The document extensions.
    /// </summary>
    public static class DocumentExtensions
    {
        #region Public Methods

        /// <summary>
        /// Gets the plain-text string value of the element.
        /// </summary>
        /// <param name="obj">The element.</param>
        /// <returns>The unformatted text within the element.</returns>
        public static string PlainText(this DocumentObject obj)
        {
            var builder = new StringBuilder();

            PlainText(obj, builder);

            return builder.ToString();
        }

        /// <summary>
        /// Converts a <see cref="SymbolName" /> to it's equivalent unicode character.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>The <see cref="char" />.</returns>
        public static char ToChar(this SymbolName symbol)
        {
            switch (symbol)
            {
                case SymbolName.Bullet:
                    return '\u2022';

                case SymbolName.Copyright:
                    return '\u00A9';

                case SymbolName.EmQuarter:
                    return '\u2012';

                case SymbolName.Em:
                case SymbolName.EmDash:
                    return '\u2014';

                case SymbolName.En:
                case SymbolName.EnDash:
                    return '\u2013';

                case SymbolName.Euro:
                    return '\u20AC';

                case SymbolName.Not:
                    return '\u2260';

                case SymbolName.ParaBreak:
                case SymbolName.LineBreak:
                    return '\n';

                case SymbolName.Trademark:
                    return '\u2122';

                case SymbolName.RegisteredTrademark:
                    return '\u00AE';

                case SymbolName.Tab:
                    return '\t';

                case SymbolName.HardBlank:
                    return '\u00A0';

                case SymbolName.Blank:
                default:
                    return '\u0020';
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Traverses the object structure and appends the text values to the string builder.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="builder">The builder.</param>
        private static void PlainText(DocumentObject obj, StringBuilder builder)
        {
            var type = obj.GetType();

            // If the object is Text or a Character, we've reached the leaf on this branch, so we
            // can just get the value and return.
            if (type == typeof(Text))
            {
                builder.Append(((Text)obj).Content);
                return;
            }

            if (type == typeof(Character))
            {
                var c = (Character)obj;
                builder.Append(c.Char != '\0' ? c.Char : c.SymbolName.ToChar());
            }

            // If not, we should get the children of the element and recurse on them.
            var objs = new List<DocumentObject>();

            if (type == typeof(FormattedText))
            {
                objs.AddRange(((FormattedText)obj).Elements.Cast<DocumentObject>());
            }
            else if (type == typeof(Paragraph))
            {
                objs.AddRange(((Paragraph)obj).Elements.Cast<DocumentObject>());
            }
            else if (type == typeof(Cell))
            {
                objs.AddRange(((Cell)obj).Elements.Cast<DocumentObject>());
            }
            else if (type == typeof(Row))
            {
                objs.AddRange(((Row)obj).Cells.Cast<DocumentObject>());
            }
            else if (type == typeof(Table))
            {
                objs.AddRange(((Table)obj).Rows.Cast<DocumentObject>());
            }
            else if (type == typeof(TextFrame))
            {
                objs.AddRange(((TextFrame)obj).Elements.Cast<DocumentObject>());
            }
            else if (type == typeof(Hyperlink))
            {
                objs.AddRange(((Hyperlink)obj).Elements.Cast<DocumentObject>());
            }
            else if (type == typeof(Section))
            {
                objs.AddRange(((Section)obj).Elements.Cast<DocumentObject>());
            }
            else if (type == typeof(Document))
            {
                objs.AddRange(((Document)obj).Sections.Cast<Section>());
            }
            else if (type == typeof(Footnote))
            {
                objs.AddRange(((Footnote)obj).Elements.Cast<DocumentObject>());
            }
            else if (type == typeof(HeaderFooter))
            {
                objs.AddRange(((HeaderFooter)obj).Elements.Cast<DocumentObject>());
            }

            // Recurse
            foreach (var o in objs)
            {
                PlainText(o, builder);
            }
        }

        #endregion Private Methods
    }
}