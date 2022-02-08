// <copyright file="FibonacciTextReader.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace Notepad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Inherits from System.IO.TextReader. Overrides the ReadLine() function
    /// to return the next fibonacci number. Starts at 0.
    /// </summary>
    public class FibonacciTextReader : System.IO.TextReader
    {
        private int currentLine;
        private int maxLines;
        private System.Numerics.BigInteger currentFibonacciNumber;
        private System.Numerics.BigInteger previousFibonacciNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// Use this constructor to specify the maximum number of times that text can be read.
        /// </summary>
        /// <param name="maxLines"> The maximum amount of times that ReadLine() can be called. </param>
        public FibonacciTextReader(int maxLines)
        {
            this.MaxLines = maxLines;
            this.currentLine = 1;
            this.currentFibonacciNumber = new System.Numerics.BigInteger(0);
            this.previousFibonacciNumber = new System.Numerics.BigInteger(0);
        }

        /// <summary>
        /// Gets or sets the maxLines that ReadLine() can read.
        /// </summary>
        public int MaxLines
        {
            get
            {
                return this.maxLines;
            }

            set
            {
                this.maxLines = System.Math.Max(0, value);
            }
        }

        /// <summary>
        /// Returns text representing the current fibonacci number.
        /// </summary>
        /// <returns> A string that represents the current fibonacci number, null when ReadLine() has no more text. </returns>
        public override string ReadLine()
        {
            return "Default text";
        }
    }
}
