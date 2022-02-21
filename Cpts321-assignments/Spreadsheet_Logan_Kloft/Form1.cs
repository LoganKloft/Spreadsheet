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
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
        }
    }
}
