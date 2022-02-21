// <copyright file="SpreadsheetCell.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Class that provides the functionality of a single cell in the spreadsheet.
    /// </summary>
    public abstract class SpreadsheetCell : INotifyPropertyChanged
    {
        private string text;
        private string value;
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
        protected string Text
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
        /// Gets the SpreadsheetCell's value.
        /// </summary>
        protected virtual string Value
        {
            get
            {
                if (this.value == null || this.value[0] != '=')
                {
                    return this.Text;
                }

                return this.Text;
            }
        }
    }
}
