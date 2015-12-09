#region Header
// <copyright company="Joshua Moon" file="IDocumentTheme.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// IDocumentTheme.cs is a part of the project Shojy.MigraDocUtils.Templates. 
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

    public interface IDocumentTheme
    {
        /// <summary>
        /// Handles the theme setup and applies it to the provided document object.
        /// </summary>
        /// <param name="document">The <see cref="Document"/> to be themed.</param>
        /// <returns>The <see cref="Document"/> that was themed for chaining.</returns>
        Document Apply(Document document);
    }
}