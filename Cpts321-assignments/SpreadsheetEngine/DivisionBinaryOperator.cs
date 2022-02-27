// <copyright file="DivisionBinaryOperator.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a / operator.
    /// </summary>
    public class DivisionBinaryOperator : BinaryOperator
    {
        /// <summary>
        /// Represents / operator.
        /// </summary>
        /// <param name="arg1"> The first argument. </param>
        /// <param name="arg2"> The second argument. </param>
        /// <returns> The division of arg1 by arg2. </returns>
        /// <exception> Divide by zero. </exception>
        public override double Compute(double arg1, double arg2)
        {
            if (arg2 == 0.0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }

            return arg1 / arg2;
        }
    }
}