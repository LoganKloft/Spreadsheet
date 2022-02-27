// <copyright file="Node.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// For polymorphism of future nodes.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Everynode has a value that it can return, Compute returns that value.
        /// </summary>
        /// <returns> Returns the value of the Node. </returns>
        public abstract double Evaluate();
    }
}
