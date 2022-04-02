// <copyright file="SpreadsheetCellBGColorCommandTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// The class for testing SpreadsheetCellBGColorCommand.
    /// </summary>
    public class SpreadsheetCellBGColorCommandTests
    {
        /// <summary>
        /// Tests the Execute command of SpreadsheetCellBGColorCommand.
        /// </summary>
        [Test]
        public void TestExecute()
        {
            SpreadsheetCellTestClass spreadsheetCell = new SpreadsheetCellTestClass();
            uint bgcolorBefore = 0xFFFF0000;
            uint bgcolorAfter = 0xFF00FF00;
            string message = "background color change";
            spreadsheetCell.BGColor = bgcolorBefore;
            CptS321.SpreadsheetCellBGColorCommand bgcolorCommand = new CptS321.SpreadsheetCellBGColorCommand(
                spreadsheetCell,
                bgcolorBefore,
                bgcolorAfter,
                message);
            bgcolorCommand.Execute();
            Assert.AreEqual(bgcolorAfter, spreadsheetCell.BGColor); // normal
        }

        /// <summary>
        /// Tests the Unexecute method of SpreadsheetCellBGColorCommand.
        /// </summary>
        [Test]
        public void TestUnexecute()
        {
            SpreadsheetCellTestClass spreadsheetCell = new SpreadsheetCellTestClass();
            uint bgcolorBefore = 0xFFFF0000;
            uint bgcolorAfter = 0xFF00FF00;
            string message = "background color change";
            spreadsheetCell.BGColor = bgcolorAfter;
            CptS321.SpreadsheetCellBGColorCommand bgcolorCommand = new CptS321.SpreadsheetCellBGColorCommand(
                spreadsheetCell,
                bgcolorBefore,
                bgcolorAfter,
                message);
            bgcolorCommand.Unexecute();
            Assert.AreEqual(bgcolorAfter, spreadsheetCell.BGColor); // normal
        }

        /// <summary>
        /// Tests the message property of SpreadsheetCellBGColorCommand.
        /// </summary>
        public void TestMessage()
        {
            SpreadsheetCellTestClass spreadsheetCell = new SpreadsheetCellTestClass();
            uint bgcolorBefore = 0xFFFF0000;
            uint bgcolorAfter = 0xFF00FF00;
            string message = "background color change";
            CptS321.SpreadsheetCellBGColorCommand bgcolorCommand = new CptS321.SpreadsheetCellBGColorCommand(
                spreadsheetCell,
                bgcolorBefore,
                bgcolorAfter,
                message);
            Assert.AreEqual(message, bgcolorCommand.Message); // normal
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
