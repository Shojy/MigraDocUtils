#region Header

// <copyright company="Joshua Moon" file="IChapter.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// IChapter.cs is a part of the project Shojy.MigraDocUtils.Templates. 
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

    /// <summary>
    /// The Chapter interface.
    /// </summary>
    public interface IChapter : IDocumentPart
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the chapter number.
        /// </summary>
        int ChapterNumber { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets the underlying <see cref="Section"/> object.
        /// </summary>
        Section Section { get; }

        /// <summary>
        /// Adds a child part to the document.
        /// </summary>
        /// <param name="part">The part to be rendered within the chapter.</param>
        /// <returns>The IChapter object being operated on.</returns>
        IChapter AddPart(IDocumentPart part);
        
        #endregion Public Properties
    }
}