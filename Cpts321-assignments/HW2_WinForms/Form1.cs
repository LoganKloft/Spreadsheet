// <copyright file="Form1.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace HW2_WinForms
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
    /// Starting place of the form.
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
        /// Initial call that will load the text to the WinForm.
        /// </summary>
        /// <param name="sender"> Not used in this implementation. </param>
        /// <param name="e"> Not used in this version of Form1_Load. </param>
        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> randomNumberList = new List<int>();
            Random randomNumberGenerator = new Random();

            // Add 10,000 random integers in the range [0,20000] to randomNumberList.
            for (int i = 0; i < 10000; i++)
            {
                randomNumberList.Add(randomNumberGenerator.Next(0, 20001));
            }

            // formatting the strings for the output to the textbox.
            string hashSetText = string.Format("1. HashSet method: {0} unique numbers.\n", Distinct.CalculateDistinctByHashSet(randomNumberList));
            string hashSetReasoning = " The time complexity of the HashSet solution is O(n) because the" + Environment.NewLine +
                " solution iterates through the entire input list and calls the Add method" + Environment.NewLine +
                " of the HashSet. The operations on the HashSet itself are O(1) in this" + Environment.NewLine +
                " case. My primary worry was on whether I would need to rehash or not." + Environment.NewLine +
                " However, I took advantage of setting the default size of the HashSet" + Environment.NewLine +
                " to 10000. Since there are at maximum, 10000 unique values in the " + Environment.NewLine +
                " List and HashSet, it will never have to resize because the" + Environment.NewLine +
                " documentation says that resizing only happens when inserting on a" + Environment.NewLine +
                " HashSet where Count == Capacity. This will never occur in my " + Environment.NewLine +
                " solution.";
            string constantMemoryText = string.Format("2. O(1) storage method: {0} unique numbers.", Distinct.CalculateDistinctInConstantMemory(randomNumberList));
            string sortText = string.Format("3. Sorted method: {0} unique numbers.", Distinct.CalculateDistinctUsingSort(randomNumberList));
            this.textBox1.AppendText(hashSetText);
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText(hashSetReasoning);
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText(constantMemoryText);
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText(sortText);
        }
    }
}
