// <copyright company="Joshua Moon" file="ITableOfContents.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// ITableOfContents.cs is a part of the project Shojy.MigraDocUtils.Templates.
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
    /// Defines the standard behaviours for a Table of Contents section.
    /// </summary>
    public interface ITableOfContents : IDocumentPart
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the table should be automatically generated or
        /// user defined. If this value is set to true, then the contents should be manually setup
        /// by the user by adding headings to track. If false, then the Generate method should be
        /// called once the document is yielded to create the table of contents.
        /// </summary>
        bool IsUserDefined { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the maximum depth of headings to include. For example, 
        /// setting this to 3 will result in Heading1, Heading2, and Heading3 to be included. If 
        /// manually defined, this value is ignored.
        /// </summary>
        int IncludeHeadingsToLevel { get; set; }

        /// <summary>
        /// Gets the list of ignored headings
        /// </summary>
        List<Paragraph> IgnoredHeadings { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Adds a heading paragraph to track in the table of contents.
        /// </summary>
        /// <param name="heading">The paragraph reference to add to the tacking list.</param>
        /// <returns>The current <see cref="ITableOfContents" /> object for chaining.</returns>
        ITableOfContents AddItem(Paragraph heading);

        /// <summary>
        /// Adds a heading paragraph to an ignore list. Any items in the ignore list will not be 
        /// included in generated tables.
        /// </summary>
        /// <param name="heading">The heading paragraph object to exclude.</param>
        /// <returns>Returns the <see cref="ITableOfContents"/> item for chaining.</returns>
        ITableOfContents IgnoreItem(Paragraph heading);

        /// <summary>
        /// Generates the table of contents if <see cref="IsUserDefined" /> is set to false.
        /// </summary>
        void Generate();

        #endregion Public Methods
    }
}