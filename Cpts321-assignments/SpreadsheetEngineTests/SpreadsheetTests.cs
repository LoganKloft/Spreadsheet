// <copyright file="SpreadsheetTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Contains the tests for the Spreadsheet class.
    /// </summary>
    public class SpreadsheetTests
    {
        private bool isCellPropertyHandlerTriggered = false;

        /// <summary>
        /// Test if CellPropertyEvent triggers when a cell is changed.
        /// </summary>
        [Test]
        public void TestCellPropertyChanged()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(5, 5);
            testSpreadsheet.CellPropertyChanged += this.HasSpreadsheetChanged;
            CptS321.SpreadsheetCell cell = testSpreadsheet.GetCell(0, 0);
            cell.Text = "test";
            Assert.IsTrue(this.isCellPropertyHandlerTriggered); // normal case
        }

        /// <summary>
        /// Allows testing of the CellPropertyChagned event.
        /// </summary>
        /// <param name="sender"> Object that triggered the event. </param>
        /// <param name="e"> Property that triggered the event. </param>
        public void HasSpreadsheetChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.isCellPropertyHandlerTriggered = true;
        }

        /// <summary>
        /// Test the call to GetCell when the arguments are out of bounds.
        /// </summary>
        [Test]
        public void TestGetCellOutOfBounds()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(0, 0);
            Assert.AreEqual(null, testSpreadsheet.GetCell(100, 100)); // edge case
        }

        /// <summary>
        /// Test the call to GetCell when the arguments are in bounds.
        /// </summary>
        [Test]
        public void TestGetCellInBounds()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(5, 5);
            Assert.AreNotEqual(null, testSpreadsheet.GetCell(0, 0)); // normal case
        }

        /// <summary>
        /// Test ColumnCount when there are no cells.
        /// </summary>
        [Test]
        public void TestColumnCountIsZero()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(0, 0);
            Assert.AreEqual(0, testSpreadsheet.ColumnCount); // edge case
        }

        /// <summary>
        /// Test ColumnCount when the spreadsheet is 5x5.
        /// </summary>
        [Test]
        public void TestColumnCountIsFive()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(5, 5);
            Assert.AreEqual(5, testSpreadsheet.ColumnCount); // normal case
        }

        /// <summary>
        /// Test RowCount when there are no cells.
        /// </summary>
        [Test]
        public void TestRowCountIsZero()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(0, 0);
            Assert.AreEqual(0, testSpreadsheet.RowCount); // edge case
        }

        /// <summary>
        /// Test RowCount when the spreadsheet is 5x5.
        /// </summary>
        [Test]
        public void TestRowCountIsFive()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(5, 5);
            Assert.AreEqual(5, testSpreadsheet.RowCount); // normal case
        }
    }
}
