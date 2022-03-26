// <copyright file="ExpressionVariable.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents a variable in an expression.
    /// </summary>
    public class ExpressionVariable
    {
        private string name;
        private double? value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionVariable"/> class.
        /// </summary>
        /// <param name="name"> The name of the new variable. </param>
        /// <param name="value"> The value of the new variable. </param>
        public ExpressionVariable(string name, double? value = null)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets or Sets name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or Sets value.
        /// </summary>
        public double? Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
