﻿// <copyright file="SpreadsheetTests.cs" company="Logan Kloft 11728076">
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
        /// Tests a formula that includes a circular reference with more than two cells in the cycle.
        /// </summary>
        [Test]
        public void TestMultipleStepCircularReference()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(2, 2);
            CptS321.SpreadsheetCell a1 = testSpreadsheet.GetCell(1, 1);
            CptS321.SpreadsheetCell a2 = testSpreadsheet.GetCell(2, 1);
            CptS321.SpreadsheetCell b1 = testSpreadsheet.GetCell(1, 2);
            CptS321.SpreadsheetCell b2 = testSpreadsheet.GetCell(2, 2);
            a1.Text = "=B1";
            b1.Text = "=B2";
            b2.Text = "=A2";
            a2.Text = "=A1";
            Assert.AreEqual("!(circular reference)", a2.Value); // exceptional
        }

        /// <summary>
        /// Tests a formula that includes a circular reference with only two cells in the cycle.
        /// </summary>
        [Test]
        public void TestSingleStepCircularReference()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(2, 1);
            CptS321.SpreadsheetCell a1 = testSpreadsheet.GetCell(1, 1);
            CptS321.SpreadsheetCell a2 = testSpreadsheet.GetCell(2, 1);
            a1.Text = "=A2";
            a2.Text = "=A1";
            Assert.AreEqual("!(circular reference)", a2.Value); // exceptional
        }

        /// <summary>
        /// Tests a formula that includes a self reference.
        /// </summary>
        [Test]
        public void TestSelfReference()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(1, 1);
            CptS321.SpreadsheetCell testCell = testSpreadsheet.GetCell(1, 1);
            testCell.Text = "=6+A1*27";
            Assert.AreEqual("!(self reference)", testCell.Value); // exceptional
        }

        /// <summary>
        /// Tests a formula that includes a cell that is out of bounds of the spreadsheet.
        /// </summary>
        [Test]
        public void TestCellNameOutOfRange()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(1, 1);
            CptS321.SpreadsheetCell testCell = testSpreadsheet.GetCell(1, 1);
            testCell.Text = "=6+Cell*27";
            Assert.AreEqual("!(bad reference)", testCell.Value); // exceptional
        }

        /// <summary>
        /// Tests a formula that includes a cell name that has no meaning.
        /// </summary>
        [Test]
        public void TestBadCellName()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(1, 1);
            CptS321.SpreadsheetCell testCell = testSpreadsheet.GetCell(1, 1);
            testCell.Text = "=6+Z123123*27";
            Assert.AreEqual("!(bad reference)", testCell.Value); // exceptional
        }

        /// <summary>
        /// Tests cell changing when the reference of the cell it is referencing changes.
        /// </summary>
        [Test]
        public void TestExpressionWithReferenceOfReference()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(3, 3);
            testSpreadsheet.GetCell(1, 1).Text = "1";
            testSpreadsheet.GetCell(2, 1).Text = "=A1";
            testSpreadsheet.GetCell(3, 1).Text = "=A2";
            testSpreadsheet.GetCell(1, 1).Text = "2";
            Assert.AreEqual("2", testSpreadsheet.GetCell(3, 1).Value); // edge
        }

        /// <summary>
        /// Tests that changing the value of one cell updates all cells that refer to that value.
        /// </summary>
        [Test]
        public void TestExpressionWhenValueChanges()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(2, 2);
            CptS321.SpreadsheetCell cell11 = testSpreadsheet.GetCell(1, 1);
            CptS321.SpreadsheetCell cell12 = testSpreadsheet.GetCell(1, 2);
            CptS321.SpreadsheetCell cell21 = testSpreadsheet.GetCell(2, 1);
            CptS321.SpreadsheetCell cell22 = testSpreadsheet.GetCell(2, 2);
            cell11.Text = "1";
            cell12.Text = "2";
            cell21.Text = "3";
            cell22.Text = "=A1+A2+B1";
            cell21.Text = "7";
            Assert.AreEqual("10", cell22.Value); // normal
        }

        /// <summary>
        /// Test an evaluation using the spreadsheet with no variables.
        /// </summary>
        [Test]
        public void TestExpressionWithNoVariables()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(2, 2);
            CptS321.SpreadsheetCell cell = testSpreadsheet.GetCell(1, 1);
            cell.Text = "1";
            Assert.AreEqual("1", cell.Value); // normal
        }

        /// <summary>
        /// Test an evaluation using the spreadsheet with variables.
        /// </summary>
        [Test]
        public void TestExpressionEvaluationWithVariables()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(2, 2);
            CptS321.SpreadsheetCell cell11 = testSpreadsheet.GetCell(1, 1);
            CptS321.SpreadsheetCell cell12 = testSpreadsheet.GetCell(1, 2);
            CptS321.SpreadsheetCell cell21 = testSpreadsheet.GetCell(2, 1);
            CptS321.SpreadsheetCell cell22 = testSpreadsheet.GetCell(2, 2);
            cell11.Text = "1";
            cell12.Text = "2";
            cell21.Text = "3";
            cell22.Text = "=A1+A2+B1";
            Assert.AreEqual("6", cell22.Value); // normal
        }

        /// <summary>
        /// Test if CellPropertyEvent triggers when a cell is changed.
        /// </summary>
        [Test]
        public void TestCellPropertyChangedWithNoEqual()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(5, 5);
            testSpreadsheet.CellPropertyChanged += this.HasSpreadsheetChanged;
            CptS321.SpreadsheetCell cell = testSpreadsheet.GetCell(1, 1);
            cell.Text = "test";
            Assert.IsTrue(this.isCellPropertyHandlerTriggered); // normal case
        }

        /// <summary>
        /// Test UpdateSpreadsheet.
        /// </summary>
        [Test]
        public void TestUpdateSpreadsheet()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(5, 5);
            testSpreadsheet.CellPropertyChanged += this.HasSpreadsheetChanged;
            CptS321.SpreadsheetCell cell1 = testSpreadsheet.GetCell(1, 1);
            CptS321.SpreadsheetCell cell2 = testSpreadsheet.GetCell(2, 2);
            cell1.Text = "test";
            cell2.Text = "=A1";
            Assert.AreEqual("0", cell2.Value); // normal case
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
            Assert.AreNotEqual(null, testSpreadsheet.GetCell(1, 1)); // normal case
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
