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
        private Dictionary<string, List<string>> referenceCells = new Dictionary<string, List<string>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numberRows"> The height of the spreadsheet. </param>
        /// <param name="numberColumns"> The width of the spreadsheet. </param>
        public Spreadsheet(int numberRows, int numberColumns)
        {
            // subscribe to event
            this.CellPropertyChanged += this.CellPropertyChangedHandler;

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
        /// Splits a variable that consists of firstly a letter, followed by any number of numbers into a 2-d array.
        /// </summary>
        /// <param name="variableName"> A cell location. </param>
        /// <returns> The {row, col} in 1-based indexing. </returns>
        public static int[] ParseVariableName(string variableName)
        {
            int row = int.Parse(variableName.Substring(1)); // already 1-based indexing.
            int column = variableName[0] - 'A' + 1; // normalize to 0-index, then add 1 for 1-based indexing.
            return new int[] { row, column };
        }

        /// <summary>
        /// Resets every cell in the spreadsheet to their default values.
        /// </summary>
        public void ResetToDefault()
        {
            this.referenceCells.Clear();
            for (int row = 1; row <= this.RowCount; row++)
            {
                for (int col = 1; col <= this.ColumnCount; col++)
                {
                    this.GetCell(row, col).ResetCell();
                }
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
            if (e.PropertyName == "Text")
            {
                CptS321.SpreadsheetCell changedCell = (CptS321.SpreadsheetCell)sender;
                if (changedCell.Text != null && changedCell.Text.StartsWith("="))
                {
                    // Remove all appearances of this cell from the List<string> in the referenceCells dictionary.
                    foreach (List<string> cellNames in this.referenceCells.Values)
                    {
                        // found in dictionary, remove it.
                        if (cellNames != null && cellNames.Contains(changedCell.ToString()))
                        {
                            cellNames.Remove(changedCell.ToString());
                        }
                    }

                    // Load the expression
                    string expression = changedCell.Text.Substring(1);
                    CptS321.ExpressionTree expressionTree = new CptS321.ExpressionTree(expression);

                    // Set the values of the variables
                    List<string> variableNames = expressionTree.GetVariableNames();
                    foreach (string variableName in variableNames)
                    {
                        // Add the changedCell as a reference to variableName
                        // At this point, any previous occurences of changedCell in any values in the referenceCells dictionary
                        // have been removed.
                        if (this.referenceCells.ContainsKey(variableName))
                        {
                            this.referenceCells[variableName].Add(changedCell.ToString());
                        }
                        else
                        {
                            this.referenceCells.Add(variableName, new List<string>() { changedCell.ToString() });
                        }

                        int[] rowCol = ParseVariableName(variableName);
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

            if (e.PropertyName == "BGColor")
            {
                this.CellPropertyChanged(sender, new System.ComponentModel.PropertyChangedEventArgs("BGColor"));
            }
        }

        /// <summary>
        ///  Called when the value of a Cell has been changed. Should update all cells that reference this cell.
        /// </summary>
        /// <param name="sender"> The cell whose value changed. </param>
        /// <param name="e"> The name of the property that has changed. </param>
        private void CellPropertyChangedHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                // Recalculate Values for cells that depend on this one.
                CptS321.SpreadsheetCell changedCell = (CptS321.SpreadsheetCell)sender;
                this.RecalculateCellsWhoReference(changedCell.ToString());
            }
        }

        /// <summary>
        /// Given a cell name, will search all cells who depend on this cell and recalculate their values using an expression tree.
        /// </summary>
        /// <param name="cellName"> The name of the cell name who other cells reference in there Text property. </param>
        private void RecalculateCellsWhoReference(string cellName)
        {
            List<string> referenceCellNames = null;
            if (this.referenceCells.TryGetValue(cellName, out referenceCellNames))
            {
                foreach (string referenceCellName in referenceCellNames)
                {
                    int[] rowCol = ParseVariableName(referenceCellName);
                    CptS321.SpreadsheetCell spreadsheetCell = this.GetCell(rowCol[0], rowCol[1]);
                    this.RecalculateCellExpression(spreadsheetCell);
                }
            }
        }

        /// <summary>
        /// Performs the same function as UpdateSpreadsheet but on a cell with an expression
        /// and can be explicitly called.
        /// </summary>
        /// <param name="spreadsheetCell"> A spreadsheet cell whose text property must start with '='. </param>
        private void RecalculateCellExpression(CptS321.SpreadsheetCell spreadsheetCell)
        {
            // Load the expression
            string expression = spreadsheetCell.Text;
            if (expression != null)
            {
                expression = spreadsheetCell.Text.Substring(1);
                CptS321.ExpressionTree expressionTree = new CptS321.ExpressionTree(expression);

                // Set the values of the variables
                List<string> variableNames = expressionTree.GetVariableNames();
                foreach (string variableName in variableNames)
                {
                    int[] rowCol = ParseVariableName(variableName);
                    CptS321.SpreadsheetCell cell = this.GetCell(rowCol[0], rowCol[1]);
                    double val = 0;
                    double.TryParse(cell.Value, out val);
                    expressionTree.SetVariable(variableName, val);
                }

                spreadsheetCell.Value = expressionTree.Evaluate().ToString();
                this.CellPropertyChanged(spreadsheetCell, new System.ComponentModel.PropertyChangedEventArgs("Value"));
            }
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
