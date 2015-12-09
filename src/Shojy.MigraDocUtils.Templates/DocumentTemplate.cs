// <copyright company="Joshua Moon" file="DocumentTemplate.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// DocumentTemplate.cs is a part of the project Shojy.MigraDocUtils.Templates.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

namespace Shojy.MigraDocUtils.Templates
{
    using System.Collections.Generic;

    using MigraDoc.DocumentObjectModel;

    /// <summary>
    /// The document template.
    /// </summary>
    public class DocumentTemplate : IDocumentTemplate
    {
        #region Private Fields

        /// <summary>
        /// Storage field for <see cref="Appendices" />.
        /// </summary>
        private List<IAppendix> _appendices;

        /// <summary>
        /// Storage field for <see cref="DocumentOrder" />
        /// </summary>
        private string[] _documentOrder;

        /// <summary>
        /// Storage field for <see cref="DocumentParts" />
        /// </summary>
        private List<IDocumentPart> _documentParts;

        /// <summary>
        /// Storage field for <see cref="DocumentTheme" />
        /// </summary>
        private IDocumentTheme _documentTheme;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the theme in use on the document.
        /// </summary>
        public IDocumentTheme DocumentTheme
        {
            get
            {
                return this._documentTheme ?? (this._documentTheme = new DocumentTheme());
            }

            set
            {
                this._documentTheme = value;
            }
        }

        #endregion Public Properties

        #region Protected Properties

        /// <summary>
        /// The appendices.
        /// </summary>
        protected List<IAppendix> Appendices => this._appendices ?? (this._appendices = new List<IAppendix>());

        /// <summary>
        /// Gets or sets the document order.
        /// </summary>
        protected string[] DocumentOrder
        {
            get
            {
                return this._documentOrder
                       ?? (this._documentOrder = new[]
                           {
                                DocumentPartTypes.FrontPage,
                                DocumentPartTypes.TableOfContents,
                                DocumentPartTypes.Chapters,
                                DocumentPartTypes.Appendices
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
        /// <param name="appendix">The appendix.</param>
        /// <returns>The <see cref="IDocumentTemplate" />.</returns>
        public IDocumentTemplate AddAppendix(IAppendix appendix)
        {
            this.Appendices.Add(appendix);
            return this;
        }

        /// <summary>
        /// The add front page.
        /// </summary>
        /// <param name="frontPage">The front page.</param>
        /// <returns>The <see cref="IDocumentTemplate" />.</returns>
        public IDocumentTemplate AddFrontPage(IFrontPage frontPage)
        {
            this.FrontPage = frontPage;
            return this;
        }

        /// <summary>
        /// The add part.
        /// </summary>
        /// <param name="documentPart">The document part.</param>
        /// <param name="position">The position.</param>
        /// <returns>The <see cref="IDocumentTemplate" />.</returns>
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
        /// <param name="tableOfContents">The table of contents.</param>
        /// <returns>The <see cref="IDocumentTemplate" />.</returns>
        public IDocumentTemplate AddTableOfContents(ITableOfContents tableOfContents)
        {
            this.TableOfContents = tableOfContents;
            return this;
        }

        /// <summary>
        /// The order document.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The <see cref="IDocumentTemplate" />.</returns>
        public IDocumentTemplate OrderDocument(params string[] items)
        {
            this.DocumentOrder = items;
            return this;
        }

        /// <summary>
        /// Sets the document theme to the provided one.
        /// </summary>
        /// <param name="theme">Theme to use.</param>
        /// <returns>The document template object for chaining.</returns>
        public IDocumentTemplate SetTheme(IDocumentTheme theme)
        {
            this.DocumentTheme = theme;
            return this;
        }

        public Document YieldDocument()
        {
            var document = new Document();

            this.ApplyTheme(document);

            foreach (var partType in this.DocumentOrder)
            {
                this.YieldPart(partType, document);
            }

            this.TableOfContents.Generate();

            return document;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Applies the document theme that is currently set. If additional tweaks are required to a
        /// theme, this method may be overriden to apply minor changes. It is always suggested that
        /// you create a new theme for anything other than minor tweaks.
        /// </summary>
        /// <remarks>
        /// In order to customise the styles, it is recommended that you override this method, and
        /// call with
        /// <code>
        /// base.ApplyTheme(document);
        /// </code>
        /// as the first action in the child method. This starts you with the default feel, and
        /// allows you to customise as needed.
        /// </remarks>
        /// <param name="document"></param>
        /// <returns></returns>
        protected virtual IDocumentTemplate ApplyTheme(Document document)
        {
            this._documentTheme.Apply(document);

            return this;
        }

        /// <summary>
        /// Renders the components of a document by group. In order to add custom groupings,
        /// override this method, and handle the additional types after making a base call. If not
        /// overridden the default behaviour is to render yield only the Front Page, Table of
        /// Contents, Chapters, and Appendices.
        /// </summary>
        /// <param name="partType">Part type identifier</param>
        /// <param name="document">The document the part group should be rendered to.</param>
        protected virtual void YieldPart(string partType, Document document)
        {
            switch (partType)
            {
                case DocumentPartTypes.FrontPage:
                    this.FrontPage?.Yield(document);
                    break;

                case DocumentPartTypes.TableOfContents:
                    this.TableOfContents?.Yield(document);
                    break;

                case DocumentPartTypes.Appendices:
                    foreach (var appendix in this.Appendices)
                    {
                        appendix.Yield(document);
                    }
                    break;

                case DocumentPartTypes.Chapters:
                    foreach (var chapter in this.DocumentParts)
                    {
                        chapter.Yield(document);
                    }
                    break;
            }
        }

        #endregion Protected Methods
    }
}