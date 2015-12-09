#region Header
// <copyright company="Joshua Moon" file="IFrontPage.cs">
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
    using System;

    /// <summary>
    /// Represents the front cover of a document.
    /// </summary>
    public interface IFrontPage : IDocumentPart
    {
        /// <summary>
        /// Gets or sets the title of the document.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the document subtitle.
        /// </summary>
        string SubTitle { get; set; }

        /// <summary>
        /// Gets or sets the published date of the document.
        /// </summary>
        DateTime Published { get; set; }

        /// <summary>
        /// Gets or sets the name of the document author.
        /// </summary>
        string AuthorName { get; set; }
    }
}