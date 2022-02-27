// <copyright file="SubtractionBinaryOperator.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents a - operator.
    /// </summary>
    public class SubtractionBinaryOperator : BinaryOperator
    {
        /// <summary>
        /// Represents - operator.
        /// </summary>
        /// <param name="arg1"> The first argument. </param>
        /// <param name="arg2"> The second argument. </param>
        /// <returns> The difference of arg1 and arg2. </returns>
        public override double Compute(double arg1, double arg2)
        {
            return arg1 - arg2;
        }
    }
}
