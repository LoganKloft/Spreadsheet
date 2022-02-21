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

            // add columns from A-Z
            for (char columnName = 'A'; columnName <= 'Z'; columnName++)
            {
                this.dataGridView1.Columns.Add(columnName.ToString(), columnName.ToString());
            }
        }
    }
}
