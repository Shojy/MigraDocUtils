namespace Shojy.MigraDocUtils.Templates
{
    using System.Collections.Generic;

    using MigraDoc.DocumentObjectModel;

    /// <summary>
    /// Represents a part of a document.
    /// </summary>
    public interface IDocumentPart
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a list of child elements
        /// </summary>
        List<IDocumentPart> Children { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Renders the part into a given section. 
        /// </summary>
        /// <param name="section">The target section to render to.</param>
        /// <returns>The provided section for chaining.</returns>
        Section Yield(Section section);

        /// <summary>
        /// Renders the part to a given document.
        /// </summary>
        /// <param name="document">The target section to render to.</param>
        /// <returns>The provided document for chaining.</returns>
        Document Yield(Document document);

        #endregion Public Methods
    }
}