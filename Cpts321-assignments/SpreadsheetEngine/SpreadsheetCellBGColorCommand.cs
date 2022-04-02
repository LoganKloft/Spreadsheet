// <copyright file="SpreadsheetCellBGColorCommand.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Command for changing the BGColor of a cell.
    /// </summary>
    public class SpreadsheetCellBGColorCommand : CptS321.ICommand
    {
        private CptS321.SpreadsheetCell spreadsheetCell;
        private uint bgcolorBeforeCommand;
        private uint bgcolorAfterCommand;
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCellBGColorCommand"/> class.
        /// </summary>
        /// <param name="spreadsheetCell"> The cell the command will act on. </param>
        /// <param name="bgcolorBeforeCommand"> The BGColor before running the command. </param>
        /// <param name="bgcolorAfterCommand"> The BGColor after running the command. </param>
        /// <param name="message"> Message describing what is being updated in the cell. </param>
        public SpreadsheetCellBGColorCommand(
            CptS321.SpreadsheetCell spreadsheetCell,
            uint bgcolorBeforeCommand,
            uint bgcolorAfterCommand,
            string message = null)
        {
            this.spreadsheetCell = spreadsheetCell;
            this.bgcolorBeforeCommand = bgcolorBeforeCommand;
            this.bgcolorAfterCommand = bgcolorAfterCommand;
            this.message = message;
        }

        /// <summary>
        /// Used to send a message to accompany the command.
        /// </summary>
        /// <returns> The message describing in low detail what the command does. </returns>
        public string Message()
        {
            return this.message;
        }

        /// <summary>
        /// Updates spreadsheetCell's BGColor to bgcolorAfterCommand.
        /// </summary>
        public void Execute()
        {
            this.spreadsheetCell.BGColor = this.bgcolorAfterCommand;
        }

        /// <summary>
        /// Updates spreadsheetCell's BGColor to bgcolorBeforeCommand.
        /// </summary>
        public void Unexecute()
        {
            this.spreadsheetCell.BGColor = this.bgcolorBeforeCommand;
        }
    }
}
