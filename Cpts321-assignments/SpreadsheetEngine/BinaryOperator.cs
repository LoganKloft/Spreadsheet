// <copyright file="BinaryOperator.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class for creating BinaryOperators.
    /// </summary>
    public abstract class BinaryOperator
    {
        /// <summary>
        /// A generic class for creating new operators.
        /// </summary>
        /// <param name="arg1"> The first argument to the operator. </param>
        /// <param name="arg2"> The second argument to the operator. </param>
        /// <returns> Returns the result of the operator on arg1 and arg2. </returns>
        public abstract double Compute(double arg1, double arg2);
    }
}
