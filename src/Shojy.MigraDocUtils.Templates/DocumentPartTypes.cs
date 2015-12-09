#region Header
// <copyright company="Joshua Moon" file="DocumentPartTypes.cs">
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
    public static class DocumentPartTypes
    {
        /// <summary>
        /// Represents the Front Page of the document.
        /// </summary>
        public const string FrontPage = "DOCUMENT::FRONT_PAGE";

        /// <summary>
        /// Represents a document's table of contents.
        /// </summary>
        public const string TableOfContents = "DOCUMENT::TABLE_OF_CONTENTS";

        /// <summary>
        /// Represents the collection of appendices for a document.
        /// </summary>
        public const string Appendices = "DOCUMENT::APPENDICES";

        /// <summary>
        /// Represents the document's main content. Usually this will be the collection of chapters, but can be any type of document part.
        /// </summary>
        public const string Chapters = "DOCUMENT::CHAPTERS";
    }
}