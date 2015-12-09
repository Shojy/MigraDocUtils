#region Header

// <copyright company="Joshua Moon" file="IDocumentTemplate.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// IDocumentTemplate.cs is a part of the project Shojy.MigraDocUtils.Templates. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion

namespace Shojy.MigraDocUtils.Templates
{
    /// <summary>The DocumentTemplate interface.</summary>
    public interface IDocumentTemplate
    {
        #region Public Methods

        /// <summary>
        /// The add appendix.
        /// </summary>
        /// <param name="appendix">
        /// The appendix.
        /// </param>
        /// <returns>
        /// The <see cref="IDocumentTemplate"/> being operated on.
        /// </returns>
        IDocumentTemplate AddAppendix(IAppendix appendix);

        /// <summary>
        /// The add front page.
        /// </summary>
        /// <param name="frontPage">
        /// The front page.
        /// </param>
        /// <returns>
        /// The <see cref="IDocumentTemplate"/> being operated on.
        /// </returns>
        IDocumentTemplate AddFrontPage(IFrontPage frontPage);

        /// <summary>
        /// The add part.
        /// </summary>
        /// <param name="documentPart">
        /// The document part.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// The <see cref="IDocumentTemplate"/> being operated on.
        /// </returns>
        IDocumentTemplate AddPart(IDocumentPart documentPart, int position = -1);

        /// <summary>
        /// The add table of contents.
        /// </summary>
        /// <param name="tableOfContents">
        /// The table of contents.
        /// </param>
        /// <returns>
        /// The <see cref="IDocumentTemplate"/> being operated on.
        /// </returns>
        IDocumentTemplate AddTableOfContents(ITableOfContents tableOfContents);

        /// <summary>
        /// Defines the order of items within the document.
        /// </summary>
        /// <param name="items">
        /// An in-order collection of document part types.
        /// </param>
        /// <returns>
        /// The <see cref="IDocumentTemplate"/> being operated on.
        /// </returns>
        IDocumentTemplate OrderDocument(params string[] items);

        #endregion Public Methods
    }
}