// <copyright file="Spreadsheet.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    /// <summary>
    /// Factory for the SpreadsheetCell class.
    /// </summary>
    public class Spreadsheet
    {
        private List<List<Cell>> spreadSheet = new List<List<Cell>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numberRows"> The height of the spreadsheet. </param>
        /// <param name="numberColumns"> The width of the spreadsheet. </param>
        public Spreadsheet(int numberRows, int numberColumns)
        {
            // add rows and columns
            for (int row = 1; row <= numberRows; row++)
            {
                this.spreadSheet.Add(new List<Cell>());
                for (int column = 1; column <= numberColumns; column++)
                {
                    this.spreadSheet[row - 1].Add(new Cell(row, column));
                    this.spreadSheet[row - 1][column - 1].PropertyChanged += this.UpdateSpreadsheet;
                }
            }
        }

        /// <summary>
        /// This event triggers when any Cell in the 2-dimensional array is modified.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets the height of the spreadsheet.
        /// </summary>
        public int RowCount
        {
            get
            {
                if (this.spreadSheet == null)
                {
                    return 0;
                }

                return this.spreadSheet.Count;
            }
        }

        /// <summary>
        /// Gets the width of the spreadsheet.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                if (this.spreadSheet == null || this.spreadSheet.Count < 1)
                {
                    return 0;
                }

                return this.spreadSheet[0].Count;
            }
        }

        /// <summary>
        /// Accesses a cell.
        /// </summary>
        /// <param name="rowIndex"> The row of the cell one wants to access. </param>
        /// <param name="columnIndex"> The column of the cell one wants to access. </param>
        /// <returns> Returns the cell at location (rowIndex, columnIndex) or null if such a cell does not exist. </returns>
        public CptS321.SpreadsheetCell GetCell(int rowIndex, int columnIndex)
        {
            if (rowIndex < 1 || rowIndex > this.RowCount)
            {
                return null;
            }
            else if (columnIndex < 1 || columnIndex > this.ColumnCount)
            {
                return null;
            }

            return this.spreadSheet[rowIndex - 1][columnIndex - 1];
        }

        /// <summary>
        /// Triggers CellPropertyChanged and is called whenever a single cell in spreadSheet has its text field changed.
        /// </summary>
        /// <param name="sender"> The cell that was changed. </param>
        /// <param name="e"> The name of the property that was used for the change. </param>
        public void UpdateSpreadsheet(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CptS321.SpreadsheetCell changedCell = (CptS321.SpreadsheetCell)sender;
            if (changedCell.Text.StartsWith("="))
            {
                // Load the expression
                string expression = changedCell.Text.Substring(1);
                CptS321.ExpressionTree expressionTree = new CptS321.ExpressionTree(expression);

                // Set the values of the variables
                List<string> variableNames = expressionTree.GetVariableNames();
                foreach (string variableName in variableNames)
                {
                    int[] rowCol = this.ParseVariableName(variableName);
                    CptS321.SpreadsheetCell cell = this.GetCell(rowCol[0], rowCol[1]);
                    double val = 0;
                    double.TryParse(cell.Value, out val);
                    expressionTree.SetVariable(variableName, val);
                }

                // Update the Value of the changed cell
                changedCell.Value = expressionTree.Evaluate().ToString();
            }
            else
            {
                changedCell.Value = changedCell.Text;
            }

            this.CellPropertyChanged(sender, new System.ComponentModel.PropertyChangedEventArgs("Value"));
        }

        /// <summary>
        /// Splits a variable that consists of firstly a letter, followed by any number of numbers into a 2-d array.
        /// </summary>
        /// <param name="variableName"> A cell location. </param>
        /// <returns> The {row, col} in 1-based indexing. </returns>
        private int[] ParseVariableName(string variableName)
        {
            int row = int.Parse(variableName.Substring(1)); // already 1-based indexing.
            int column = variableName[0] - 'A' + 1; // normalize to 0-index, then add 1 for 1-based indexing.
            return new int[] { row, column };
        }

        /// <summary>
        /// Acts the same as a SpreadsheetCell, but can be initiated only inside of Spreadsheet.
        /// </summary>
        private class Cell : CptS321.SpreadsheetCell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Cell"/> class.
            /// Provides access to the constructor of SpreadsheetCell.
            /// </summary>
            /// <param name="rowIndex"> The current row number of this cell. </param>
            /// <param name="columnIndex"> The current column number of this cell. </param>
            public Cell(int rowIndex, int columnIndex)
                : base(rowIndex, columnIndex)
            {
            }

            /// <summary>
            /// Gets or Sets the value of a cell.
            /// </summary>
            public override string Value
            {
                get
                {
                    return this.value;
                }

                set
                {
                    this.value = value;
                }
            }
        }
    }
}
