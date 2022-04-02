// <copyright file="SpreadsheetCell.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Class that provides the functionality of a single cell in the spreadsheet.
    /// </summary>
    public abstract class SpreadsheetCell : INotifyPropertyChanged
    {
        /// <summary>
        /// The string of the cell that can be seen in the GUI.
        /// </summary>
        protected string text;

        /// <summary>
        /// The calculated value of the cell in the GUI.
        /// </summary>
        protected string value;

        private uint bgColor = 0xFFFFFFFF;

        private int rowIndex;
        private int columnIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        public SpreadsheetCell()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// Constructor that allows creation of a SpreadsheetCell with a given rowIndex and columnIndex.
        /// </summary>
        /// <param name="rowIndex"> Initialize field rowIndex with parameter rowIndex. </param>
        /// <param name="columnIndex"> Initialize field columnIndex with paremeter columnIndex. </param>
        public SpreadsheetCell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }

        /// <summary>
        /// Triggers when any of the properties are changed, argument sent is the name of the property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets the SpreadsheetCell's rowIndex.
        /// </summary>
        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// Gets the SpreadsheetCell's columnIndex.
        /// </summary>
        public int ColumnIndex
        {
            get { return this.columnIndex; }
        }

        /// <summary>
        /// Gets or Sets the SpreadsheetCell's text.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value == this.text)
                {
                    return;
                }

                this.text = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        /// <summary>
        /// Gets or sets the SpreadsheetCell's value.
        /// </summary>
        public virtual string Value
        {
            get
            {
                if (this.value == null)
                {
                    return this.Text;
                }
                else
                {
                    return this.value;
                }
            }

            set
            {
                return;
            }
        }

        /// <summary>
        /// Gets or sets the bgColor.
        /// </summary>
        public uint BGColor
        {
            get
            {
                return this.bgColor;
            }

            set
            {
                if (value == this.BGColor)
                {
                    return;
                }

                this.bgColor = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("BGColor"));
            }
        }

        /// <summary>
        /// Represents the string format of a SpreadsheetCell object.
        /// </summary>
        /// <returns> Returns the ColumnIndex in character form concatenated to the RowIndex.
        /// i.e a SpreadsheetCell with ColumnIndex 1 and RowIndex 1 will return "A1". </returns>
        public override string ToString()
        {
            string result = string.Empty;
            result += (char)(this.ColumnIndex + 'A' - 1); // convert integer-based column to letter representation.
            result += this.RowIndex.ToString();
            return result;
        }
    }
}
