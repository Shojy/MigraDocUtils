#region Header
// <copyright company="Joshua Moon" file="Utils.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// Utils.cs is a part of the project Shojy.MigraDocUtils. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion
namespace Shojy.MigraDocUtils
{
    using System.Drawing;
    using System.Drawing.Text;
    using System.Linq;

    /// <summary>
    /// Provides a collection of utility methods that can be used.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Checks if a given font name is installed on the local system.
        /// </summary>
        /// <param name="fontName">The name of the font to check.</param>
        /// <returns>Boolean value indicating whether or not the font is installed.</returns>
        public static bool IsFontInstalled(string fontName)
        {
            var fonts = new InstalledFontCollection();
            return fonts.Families.Any(f => f.Name == fontName);
        }

        /// <summary>
        /// Returns the first font name that is installed from the fonts defined, or if none are installed
        /// returns the system default font.
        /// </summary>
        /// <param name="fontNames">Font names to check.</param>
        /// <returns>The best matched font name.</returns>
        public static string BestFontMatch(params string[] fontNames)
        {
            return fontNames.FirstOrDefault(IsFontInstalled) 
                ?? SystemFonts.DefaultFont.Name;
        }
    }
}