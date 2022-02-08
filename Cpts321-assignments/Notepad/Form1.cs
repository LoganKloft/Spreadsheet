// <copyright file="Form1.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace Notepad
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
    /// The class for the main Windows Form.
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

        /// <summary>
        /// Prompts the user for a file to read all text from.
        /// </summary>
        /// <param name="sender"> Object which raised the event. </param>
        /// <param name="e"> Further information about the event. </param>
        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Displays the first 50 fibonacci numbers in the TextBox of the form.
        /// </summary>
        /// <param name="sender"> Object which raised the event. </param>
        /// <param name="e"> Further information about the event. </param>
        private void LoadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad.FibonacciTextReader firstFifty = new Notepad.FibonacciTextReader(50);
            this.textBox1.Clear(); // remove previous text
            string line; // stores the line to display to textbox
            int i = 1; // current line number

            // Logic for printing all Fibonacci numbers contained by firstFifty
            while ((line = firstFifty.ReadLine()) != null)
            {
                this.textBox1.AppendText((i++).ToString() + ". " + line + System.Environment.NewLine); // Formatting for printing the line.
            }
        }

        /// <summary>
        /// Displays the first 100 fibonacci numbers in the TextBox of the form.
        /// </summary>
        /// <param name="sender"> Object which raised the event. </param>
        /// <param name="e"> Further information about the event. </param>
        private void LoadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad.FibonacciTextReader firstHundred = new Notepad.FibonacciTextReader(100);
            this.textBox1.Clear(); // remove previous text
            string line; // stores the line to display to textbox
            int i = 1; // current line number

            // Logic for printing all Fibonacci numbers contained by firstHundred
            while ((line = firstHundred.ReadLine()) != null)
            {
                this.textBox1.AppendText((i++).ToString() + ". " + line + System.Environment.NewLine); // Formatting for printing the line.
            }
        }

        /// <summary>
        /// Prompts the user for a file to save the currently loaded text into.
        /// </summary>
        /// <param name="sender"> Object which raised the event. </param>
        /// <param name="e"> Further information about the event. </param>
        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
