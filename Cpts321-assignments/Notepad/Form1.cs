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
        /// Generic Loading Function that calls ReadLine() until null is returned.
        /// </summary>
        /// <param name="sr"> Any TextReader or Derived class that implements ReadLine(). </param>
        private void LoadText(System.IO.TextReader sr)
        {
            this.textBox1.Clear(); // remove previous text
            string line; // stores the line to display to textbox

            while ((line = sr.ReadLine()) != null)
            {
                this.textBox1.AppendText(line + System.Environment.NewLine); // Formatting for printing the line.
            }
        }

        /// <summary>
        /// Prompts the user for a file to read all text from.
        /// </summary>
        /// <param name="sender"> Object which raised the event. </param>
        /// <param name="e"> Further information about the event. </param>
        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream = openFileDialog.OpenFile();

                using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream))
                {
                    this.LoadText(streamReader);
                } // Automatically closes the StreamReader
            }
        }

        /// <summary>
        /// Prompts the user for a file to save the currently loaded text into.
        /// </summary>
        /// <param name="sender"> Object which raised the event. </param>
        /// <param name="e"> Further information about the event. </param>
        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.Stream stream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(this.textBox1.Text);
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Displays the first 50 fibonacci numbers in the TextBox of the form.
        /// </summary>
        /// <param name="sender"> Object which raised the event. </param>
        /// <param name="e"> Further information about the event. </param>
        private void LoadFibonacciNumbersfirstFiftyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad.FibonacciTextReader firstFifty = new Notepad.FibonacciTextReader(50);
            this.LoadText(firstFifty);
        }

        /// <summary>
        /// Displays the first 100 fibonacci numbers in the TextBox of the form.
        /// </summary>
        /// <param name="sender"> Object which raised the event. </param>
        /// <param name="e"> Further information about the event. </param>
        private void LoadFibonacciNumbersfirstHundredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad.FibonacciTextReader firstHundred = new Notepad.FibonacciTextReader(100);
            this.LoadText(firstHundred);
        }
    }
}
