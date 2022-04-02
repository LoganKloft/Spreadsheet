// <copyright file="SpreadsheetCellTextCommandTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the SpreadsheetCellTextCommand class.
    /// </summary>
    public class SpreadsheetCellTextCommandTests
    {
        /// <summary>
        /// Tests the Execute method of SpreadsheetCellTextCommand.
        /// </summary>
        [Test]
        public void TestExecute()
        {
            SpreadsheetCellTestClass spreadsheetCell = new SpreadsheetCellTestClass();
            string textBefore = "Before";
            string textAfter = "After";
            string message = "text change";
            spreadsheetCell.Text = textBefore;
            CptS321.SpreadsheetCellTextCommand textCommand = new CptS321.SpreadsheetCellTextCommand(
                spreadsheetCell,
                textBefore,
                textAfter,
                message);
            textCommand.Execute();
            Assert.AreEqual(textAfter, spreadsheetCell.Text); // normal
        }

        /// <summary>
        /// Tests the Unexecute method of SpreadsheetCellTextCommand.
        /// </summary>
        [Test]
        public void TestUnexecute()
        {
            SpreadsheetCellTestClass spreadsheetCell = new SpreadsheetCellTestClass();
            string textBefore = "Before";
            string textAfter = "After";
            string message = "text change";
            spreadsheetCell.Text = textAfter;
            CptS321.SpreadsheetCellTextCommand textCommand = new CptS321.SpreadsheetCellTextCommand(
                spreadsheetCell,
                textBefore,
                textAfter,
                message);
            textCommand.Unexecute();
            Assert.AreEqual(textBefore, spreadsheetCell.Text); // normal
        }

        /// <summary>
        /// Tests the Message property of SpreadsheetCellTextCommand.
        /// </summary>
        [Test]
        public void TestMessage()
        {
            SpreadsheetCellTestClass spreadsheetCell = new SpreadsheetCellTestClass();
            string textBefore = "Before";
            string textAfter = "After";
            string message = "text change";
            CptS321.SpreadsheetCellTextCommand textCommand = new CptS321.SpreadsheetCellTextCommand(
                spreadsheetCell,
                textBefore,
                textAfter,
                message);
            Assert.AreEqual(message, textCommand.Message()); // normal
        }

        /// <summary>
        /// Allows ability to test abstract class.
        /// </summary>
        internal class SpreadsheetCellTestClass : CptS321.SpreadsheetCell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SpreadsheetCellTestClass"/> class.
            /// </summary>
            public SpreadsheetCellTestClass()
                : base()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SpreadsheetCellTestClass"/> class.
            /// Constructor that allows creation of a SpreadsheetCell with a given rowIndex and columnIndex.
            /// </summary>
            /// <param name="rowIndex"> Initialize field rowIndex with parameter rowIndex. </param>
            /// <param name="columnIndex"> Initialize field columnIndex with paremeter columnIndex. </param>
            public SpreadsheetCellTestClass(int rowIndex, int columnIndex)
                : base(rowIndex, columnIndex)
            {
            }
        }
    }
}
