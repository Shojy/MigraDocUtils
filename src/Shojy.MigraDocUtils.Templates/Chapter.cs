// <copyright company="Joshua Moon" file="Chapter.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// Chapter.cs is a part of the project Shojy.MigraDocUtils.Templates.
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

    using Styles = Shojy.MigraDocUtils.Styles;

    /// <summary>
    /// The chapter.
    /// </summary>
    public class Chapter : IChapter
    {
        #region Private Fields

        /// <summary>
        /// Storage field for <see cref="Children" />
        /// </summary>
        private List<IDocumentPart> _children;

        /// <summary>
        /// Storage field for <see cref="Section" />
        /// </summary>
        private Section _section;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the chapter number.
        /// </summary>
        public int ChapterNumber { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        public List<IDocumentPart> Children
        {
            get
            {
                return this._children ?? (this._children = new List<IDocumentPart>());
            }

            set
            {
                this._children = value;
            }
        }

        /// <summary>
        /// Gets the underlying Section element.
        /// </summary>
        public Section Section => this._section ?? (this._section = this.GenerateSection());

        /// <summary>
        /// Gets or sets the chapter title.
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties

        #region Protected Properties

        /// <summary>
        /// Gets or sets the Chapter heading.
        /// </summary>
        protected Paragraph Heading { get; set; }

        #endregion Protected Properties

        #region Public Methods

        /// <summary>
        /// Adds a new child part to be rendered within this chapter.
        /// </summary>
        /// <param name="part">The part.</param>
        /// <returns>The <see cref="IChapter" />.</returns>
        public IChapter AddPart(IDocumentPart part)
        {
            this.Children.Add(part);

            return this;
        }

        /// <summary>
        /// Renders the document part and yields the result.
        /// </summary>
        /// <returns>The <see cref="Section" />.</returns>
        public Section Yield(Section section)
        {
            this.Heading.AddText($"{this.ChapterNumber}. {this.Title}");

            foreach (var part in this.Children)
            {
                part.Yield(section);
            }

            return section;
        }

        /// <summary>
        /// Renders the Chapter into the provided document
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>The <see cref="Document" />.</returns>
        public Document Yield(Document document)
        {
            document.Add(this.Section);
            this.Yield(this.Section);

            return document;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Prepares a section with a heading element as the first child.
        /// </summary>
        /// <returns>The prepared section.</returns>
        protected virtual Section GenerateSection()
        {
            var section = new Section();

            this.Heading = section.AddParagraph(string.Empty, Styles.Heading1);

            return section;
        }

        #endregion Protected Methods
    }
}