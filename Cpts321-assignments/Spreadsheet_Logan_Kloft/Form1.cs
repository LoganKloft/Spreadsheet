// <copyright file="Form1.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace Spreadsheet_Logan_Kloft
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The main form of the Spreadsheet application.
    /// </summary>
    public partial class Form1 : Form
    {
        private CptS321.Spreadsheet spreadsheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

            // remove already existing columns
            this.dataGridView1.Columns.Clear();

            // remove already existing rows
            this.dataGridView1.Rows.Clear();

            // add columns from A-Z
            for (char columnName = 'A'; columnName <= 'Z'; columnName++)
            {
                this.dataGridView1.Columns.Add(columnName.ToString(), columnName.ToString());
            }

            // add rows from 1-50
            this.dataGridView1.Rows.Add(49);
            int rowNumber = 1;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.HeaderCell.Value = rowNumber.ToString();
                rowNumber++;
            }

            this.spreadsheet = new CptS321.Spreadsheet(50, 26);
            this.spreadsheet.CellPropertyChanged += this.UpdateDataGridView;
        }

        /// <summary>
        /// Updates the Text property of a cell in DataGridView when a Value changes in a spreadsheet cell.
        /// </summary>
        /// <param name="sender"> The cell that was changed. </param>
        /// <param name="e"> Has no meaning. </param>
        public void UpdateDataGridView(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CptS321.SpreadsheetCell changedCell = (CptS321.SpreadsheetCell)sender;
            this.dataGridView1[changedCell.ColumnIndex - 1, changedCell.RowIndex - 1].Value = changedCell.Value;
        }

        /// <summary>
        /// Runs the demo for step 7.
        /// </summary>
        /// <param name="sender"> Button. </param>
        /// <param name="e"> Has no meaning. </param>
        public void Demo(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                int column = rand.Next(1, 26);
                int row = rand.Next(1, 50);
                this.spreadsheet.GetCell(row, column).Text = "Hello World!";
            }

            // Set the text in every cell in column B to "This is cell B#"
            for (int i = 1; i <= 50; i++)
            {
                this.spreadsheet.GetCell(i, 2).Text = "This is cell B" + i.ToString();
            }

            // Set the text in every cell in column A to "=B#"
            for (int i = 1; i <= 50; i++)
            {
                this.spreadsheet.GetCell(i, 1).Text = "=B" + i.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
