// <copyright file="CommandInvokerTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the CommandInvoker class.
    /// </summary>
    public class CommandInvokerTests
    {
        /// <summary>
        /// Tests the CanUndo method of CommandInvoker on a non-empty undo stack.
        /// </summary>
        [Test]
        public void TestCanUndo()
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

            CptS321.CommandInvoker commandInvoker = new CptS321.CommandInvoker();
            List<CptS321.ICommand> commandList = new List<CptS321.ICommand>();
            commandList.Add(textCommand);

            commandInvoker.AddUndo(commandList, "text change");
            Assert.True(commandInvoker.CanUndo()); // Normal
            commandInvoker.Undo();
            commandInvoker.Redo();
            Assert.True(commandInvoker.CanUndo()); // Normal
        }

        /// <summary>
        /// Tests the CanUndo method of CommandInvoker on an empty undo stack.
        /// </summary>
        [Test]
        public void TestCanUndoEmpty()
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

            CptS321.CommandInvoker commandInvoker = new CptS321.CommandInvoker();
            Assert.False(commandInvoker.CanUndo()); // Edge
            List<CptS321.ICommand> commandList = new List<CptS321.ICommand>();
            commandList.Add(textCommand);

            commandInvoker.AddUndo(commandList, "text change");
            commandInvoker.Undo();
            Assert.False(commandInvoker.CanUndo()); // Normal
        }

        /// <summary>
        /// Tests the Undo method of CommandInvoker.
        /// </summary>
        [Test]
        public void TestUndo()
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

            CptS321.CommandInvoker commandInvoker = new CptS321.CommandInvoker();
            List<CptS321.ICommand> commandList = new List<CptS321.ICommand>();
            commandList.Add(textCommand);

            commandInvoker.AddUndo(commandList, "text change");
            commandInvoker.Undo();
            Assert.AreEqual(textBefore, spreadsheetCell.Text); // Normal
        }

        /// <summary>
        /// Tests the CanRedo method of CommandInvoker on a non-empty redo stack.
        /// </summary>
        [Test]
        public void TestCanRedo()
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

            CptS321.CommandInvoker commandInvoker = new CptS321.CommandInvoker();
            List<CptS321.ICommand> commandList = new List<CptS321.ICommand>();
            commandList.Add(textCommand);

            commandInvoker.AddUndo(commandList, "text change");
            commandInvoker.Undo();
            Assert.True(commandInvoker.CanRedo()); // Normal
        }

        /// <summary>
        /// Tests the CanRedo method of CommandInvoker on an empty redo stack.
        /// </summary>
        [Test]
        public void TestCanRedoEmpty()
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

            CptS321.CommandInvoker commandInvoker = new CptS321.CommandInvoker();
            Assert.False(commandInvoker.CanRedo()); // Edge
            List<CptS321.ICommand> commandList = new List<CptS321.ICommand>();
            commandList.Add(textCommand);

            commandInvoker.AddUndo(commandList, "text change");
            Assert.False(commandInvoker.CanRedo()); // Normal
            commandInvoker.Undo();
            commandInvoker.Redo();
            Assert.False(commandInvoker.CanRedo()); // Normal
        }

        /// <summary>
        /// Tests the Redo method of CommandInvoker.
        /// </summary>
        public void TestRedo()
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

            CptS321.CommandInvoker commandInvoker = new CptS321.CommandInvoker();
            List<CptS321.ICommand> commandList = new List<CptS321.ICommand>();
            commandList.Add(textCommand);

            commandInvoker.AddUndo(commandList, "text change");
            commandInvoker.Undo();
            commandInvoker.Redo();
            Assert.AreEqual(textAfter, spreadsheetCell.Text); // Normal
        }

        /// <summary>
        /// Tests the AddUndo method of CommandInvoker.
        /// </summary>
        [Test]
        public void TestAddUndo()
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

            CptS321.CommandInvoker commandInvoker = new CptS321.CommandInvoker();
            List<CptS321.ICommand> commandList = new List<CptS321.ICommand>();
            commandList.Add(textCommand);

            commandInvoker.AddUndo(commandList, "text change");

            Assert.True(commandInvoker.CanUndo()); // Normal
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
