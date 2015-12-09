#region Header
// <copyright company="Joshua Moon" file="DocumentTheme.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// DocumentTheme.cs is a part of the project Shojy.MigraDocUtils.Templates. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion

namespace Shojy.MigraDocUtils.Templates
{
    using MigraDoc.DocumentObjectModel;
    using Styles = Shojy.MigraDocUtils.Styles;

    /// <summary>
    /// The default theme for documents. Provides a clean A4 style, suitable for use as a report or similiar, and can
    /// be used as a base for extending and customising user themes.
    /// </summary>
    public class DocumentTheme : IDocumentTheme
    {
        /// <summary>
        /// Gets or sets an ordered array of prefered font names to use for document headings.
        /// </summary>
        protected string[] HeadingFonts { get; set; } = { "Calibri Light", "Calibri", "Tahoma" };

        /// <summary>
        /// Gets or sets an ordered array of prefered font names to use for document body text.
        /// </summary>
        protected string[] BodyFonts { get; set; } = { "Calibri Light", "Calibri", "Tahoma" };

        /// <summary>
        /// Gets or sets the argb color to use for headings.
        /// </summary>
        protected uint HeadingFontColor { get; set; } = 0xff2980b9;

        /// <summary>
        /// Applies the default theme to the whole document.
        /// </summary>
        /// <param name="document">
        /// The document to apply the styles to.
        /// </param>
        /// <returns>
        /// Returns the document being operated on for use in chaining.
        /// </returns>
        public Document Apply(Document document)
        {
            this.SetupDocumentStyles(document);
            this.SetupDocumentHeaders(document);
            this.SetupDocumentFooters(document);
            
            return document;
        }

        /// <summary>
        /// Defines the document styles to be used. This method can be used as a starting point to easily customise the
        /// look and feel of the document. The defaults provide a clean A4 document, suitable for use as a report, or similiar.
        /// </summary>
        /// <remarks>
        /// In order to customise the styles, it is recommended that you override this method, and call with
        /// <code>
        /// base.SetupDocumentStyles(document);
        /// </code>
        /// as the first action in the child method. This starts you with the default feel, and allows you to customise as needed.
        /// </remarks>
        /// <param name="document">
        /// The document object that the styles should be applied to.
        /// </param>
        protected virtual void SetupDocumentStyles(Document document)
        {
            // Default "Normal" style
            var style = document.Styles[Styles.Paragraph];
            style.Font.Name = Utils.BestFontMatch(this.BodyFonts);

            // Normal style without paragraph spacing
            style = document.Styles[Styles.NoSpacing];
            style.Font.Name = Utils.BestFontMatch(this.BodyFonts);

            // Heading styles
            var headingStyles = new[]
                                {
                                    Styles.Heading1, Styles.Heading2, Styles.Heading3,
                                    Styles.Heading4, Styles.Heading5, Styles.Heading6
                                };
            foreach (var heading in headingStyles)
            {
                style = document.Styles[heading];
                style.Font.Name = Utils.BestFontMatch(this.HeadingFonts);
                style.Font.Color = new Color(this.HeadingFontColor);
            }
        }

        /// <summary>
        /// Defines the document Header(s) to be used. This method can be used as a starting point to easily customise the
        /// look and feel of the document. The defaults provide a clean A4 document, suitable for use as a report, or similiar.
        /// </summary>
        /// <remarks>
        /// In order to customise the styles, it is recommended that you override this method, and call with
        /// <code>
        /// base.SetupDocumentHeaders(document);
        /// </code>
        /// as the first action in the child method. This starts you with the default feel, and allows you to customise as needed.
        /// </remarks>
        /// <param name="document">
        /// The document object that the styles should be applied to.
        /// </param>
        protected virtual void SetupDocumentHeaders(Document document)
        {
        }

        /// <summary>
        /// Defines the document Footer(s) to be used. This method can be used as a starting point to easily customise the
        /// look and feel of the document. The defaults provide a clean A4 document, suitable for use as a report, or similiar.
        /// </summary>
        /// <remarks>
        /// In order to customise the styles, it is recommended that you override this method, and call with
        /// <code>
        /// base.SetupDocumentFooters(document);
        /// </code>
        /// as the first action in the child method. This starts you with the default feel, and allows you to customise as needed.
        /// </remarks>
        /// <param name="document">
        /// The document object that the styles should be applied to.
        /// </param>
        protected virtual void SetupDocumentFooters(Document document)
        {
        }
    }
}