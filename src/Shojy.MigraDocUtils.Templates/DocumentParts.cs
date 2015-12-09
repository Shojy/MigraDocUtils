#region Header
// <copyright company="Joshua Moon" file="DocumentParts.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// DocumentPart.cs is a part of the project Shojy.MigraDocUtils.Templates. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion
namespace Shojy.MigraDocUtils.Templates
{
    /// <summary>
    /// Represents a type of document part.
    /// </summary>
    public enum DocumentParts
    {
        /// <summary>
        /// Represents the Front Page of the document.
        /// </summary>
        FrontPage,

        /// <summary>
        /// Represents a document's table of contents.
        /// </summary>
        TableOfContents,

        /// <summary>
        /// Represents the collection of appendices for a document.
        /// </summary>
        Appendices,

        /// <summary>
        /// Represents the document's content. Usually this will be the collection of chapters, but can be any type of document part.
        /// </summary>
        Content
    }
}