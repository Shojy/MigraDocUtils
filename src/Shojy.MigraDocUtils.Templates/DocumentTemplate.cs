#region Header

// <copyright company="Joshua Moon" file="DocumentTemplate.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// DocumentTemplate.cs is a part of the project Shojy.MigraDocUtils.Templates. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion

namespace Shojy.MigraDocUtils.Templates
{
    using System.Collections.Generic;

    /// <summary>
    /// The document template.
    /// </summary>
    public class DocumentTemplate : IDocumentTemplate
    {
        #region Private Fields

        /// <summary>
        /// The _appendices.
        /// </summary>
        private List<IAppendix> _appendices;

        /// <summary>
        /// The _document order.
        /// </summary>
        private DocumentParts[] _documentOrder;

        /// <summary>
        /// The _document parts.
        /// </summary>
        private List<IDocumentPart> _documentParts;

        #endregion Private Fields

        #region Protected Properties

        /// <summary>
        /// The appendices.
        /// </summary>
        protected List<IAppendix> Appendices => this._appendices ?? (this._appendices = new List<IAppendix>());

        /// <summary>
        /// Gets or sets the document order.
        /// </summary>
        protected DocumentParts[] DocumentOrder
        {
            get
            {
                return this._documentOrder
                       ?? (this._documentOrder = new[]
                           {
                                Templates.DocumentParts.FrontPage,
                                Templates.DocumentParts.TableOfContents, 
                                Templates.DocumentParts.Content,
                                Templates.DocumentParts.Appendices
                           });
            }

            set
            {
                this._documentOrder = value;
            }
        }

        /// <summary>
        /// The document parts.
        /// </summary>
        protected List<IDocumentPart> DocumentParts
            => this._documentParts ?? (this._documentParts = new List<IDocumentPart>());

        /// <summary>
        /// Gets or sets the front page.
        /// </summary>
        protected IFrontPage FrontPage { get; set; }

        /// <summary>
        /// Gets or sets the table of contents.
        /// </summary>
        protected ITableOfContents TableOfContents { get; set; }

        #endregion Protected Properties

        #region Public Methods

        /// <summary>
        /// The add appendix.
        /// </summary>
        /// <param name="appendix">
        /// The appendix.
        /// </param>
        /// <returns>
        /// The <see cref="IDocumentTemplate"/>.
        /// </returns>
        public IDocumentTemplate AddAppendix(IAppendix appendix)
        {
            this.Appendices.Add(appendix);
            return this;
        }

        /// <summary>
        /// The add front page.
        /// </summary>
        /// <param name="frontPage">
        /// The front page.
        /// </param>
        /// <returns>
        /// The <see cref="IDocumentTemplate"/>.
        /// </returns>
        public IDocumentTemplate AddFrontPage(IFrontPage frontPage)
        {
            this.FrontPage = frontPage;
            return this;
        }

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
        /// The <see cref="IDocumentTemplate"/>.
        /// </returns>
        public IDocumentTemplate AddPart(IDocumentPart documentPart, int position = -1)
        {
            // If position is negative, or greater than the number of parts we have, insert it at
            // the end of the list.
            if (0 > position || this.DocumentParts.Count < position)
            {
                position = this.DocumentParts.Count;
            }

            this.DocumentParts.Insert(position, documentPart);

            return this;
        }

        /// <summary>
        /// The add table of contents.
        /// </summary>
        /// <param name="tableOfContents">
        /// The table of contents.
        /// </param>
        /// <returns>
        /// The <see cref="IDocumentTemplate"/>.
        /// </returns>
        public IDocumentTemplate AddTableOfContents(ITableOfContents tableOfContents)
        {
            this.TableOfContents = tableOfContents;
            return this;
        }

        /// <summary>
        /// The order document.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// The <see cref="IDocumentTemplate"/>.
        /// </returns>
        public IDocumentTemplate OrderDocument(params DocumentParts[] items)
        {
            this.DocumentOrder = items;
            return this;
        }

        #endregion Public Methods
    }
}