// <copyright file="SpreadsheetCellTextCommand.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Command for changing the Text of a cell.
    /// </summary>
    public class SpreadsheetCellTextCommand : CptS321.ICommand
    {
        private CptS321.SpreadsheetCell spreadsheetCell;
        private string message;
        private string textBeforeCommand;
        private string textAfterCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCellTextCommand"/> class.
        /// </summary>
        /// <param name="spreadsheetCell"> The cell the command will act on. </param>
        /// <param name="textBeforeCommand"> The text of the cell before running the command. </param>
        /// <param name="textAfterCommand"> The text of the cell after running the command. </param>
        /// <param name="message"> Message describing what is being updated in the cell. </param>
        public SpreadsheetCellTextCommand(
            CptS321.SpreadsheetCell spreadsheetCell,
            string textBeforeCommand,
            string textAfterCommand,
            string message)
        {
            this.spreadsheetCell = spreadsheetCell;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
        }

        /// <summary>
        /// Updates spreadsheetCell's text to textAfterCommand.
        /// </summary>
        public void Execute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates spreadsheetCell's text to textBeforeCommand.
        /// </summary>
        public void Unexecute()
        {
            throw new NotImplementedException();
        }
    }
}
