﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TableExtensions.cs" company="Joshua Moon">
//     (c) Copyright Joshua Moon 2015
// </copyright>
// <summary>
// The table extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Shojy.MigraDocUtils
{
    using System;
    using System.Linq;

    using MigraDoc.DocumentObjectModel;
    using MigraDoc.DocumentObjectModel.Shapes;
    using MigraDoc.DocumentObjectModel.Shapes.Charts;
    using MigraDoc.DocumentObjectModel.Tables;

    /// <summary>
    /// The table extensions.
    /// </summary>
    public static class TableExtensions
    {
        #region Public Methods

        /// <summary>
        /// Adds data to a table cell.
        /// </summary>
        /// <remarks>
        /// <para>
        /// <seealso cref="Paragraph" />, <seealso cref="TextFrame" />, <seealso cref="Image" />,
        /// <seealso cref="Chart" />, <seealso cref="Text" />, and <seealso cref="FormattedText" />
        /// are added as-is. Other types are converted to strings and added within a
        /// <seealso cref="Paragraph" /> and <seealso cref="FormattedText" /> wrapper.
        /// </para>
        /// <para>
        /// For other data types to be added differently, they should be wrapped within one of the
        /// supported types.
        /// </para>
        /// </remarks>
        /// <param name="cell">The cell.</param>
        /// <param name="data">The data.</param>
        public static void AddData(this Cell cell, object data)
        {
            if (data is Paragraph)
            {
                cell.Add((Paragraph)data);
            }
            else if (data is TextFrame)
            {
                cell.Add((TextFrame)data);
            }
            else if (data is Image)
            {
                cell.Add((Image)data);
            }
            else if (data is Chart)
            {
                cell.Add((Chart)data);
            }
            else if (data is Text)
            {
                cell.AddParagraph().Add((Text)data);
            }
            else if (data is FormattedText)
            {
                cell.AddParagraph().Add((FormattedText)data);
            }
            else
            {
                // Default all other data types as their string versions.
                cell.AddParagraph(data.ToString());
            }
        }

        /// <summary>
        /// <para>Adds a row of variable data types to the table.</para>
        /// <para>The supported data types are the same as <see cref="AddData" /></para>
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="data">The data.</param>
        /// <returns>The <see cref="Table" />.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Number of <paramref name="data" /> values to add must be equal to or fewer than the
        /// number of columns in the table.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="data" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="OverflowException">
        /// Number of values in <paramref name="data" /> exceeds the maximum countable value.
        /// </exception>
        public static Table AddRow(this Table table, params object[] data)
        {
            // Validate the data values to be added to the table.
            if (null == data)
            {
                throw new ArgumentNullException(nameof(data), "data cannot be null.");
            }

            try
            {
                if (table.Columns.Count < data.Count())
                {
                    throw new ArgumentOutOfRangeException(nameof(data), "Number of values to add is greater than the number of columns in the table");
                }
            }
            catch (OverflowException overflowException)
            {
                throw new OverflowException("Number of values in data exceeds the maximum countable value.", overflowException);
            }

            // Add the data values to a new row of the table.
            var row = table.AddRow();

            foreach (var obj in data)
            {
                var cell = new Cell();

                cell.AddData(obj);

                row.Cells.Add(cell);
            }

            return table;
        }

        /// <summary>
        /// The create table.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="columnWidths">The column widths.</param>
        /// <returns>The <see cref="Table" />.</returns>
        public static Table CreateTable(this Section section, params int[] columnWidths)
        {
            var table = section.AddTable();

            foreach (var width in columnWidths)
            {
                table.Columns.AddColumn().Width = width;
            }

            return table;
        }

        #endregion Public Methods
    }
}