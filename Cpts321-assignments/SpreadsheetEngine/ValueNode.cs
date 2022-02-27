// <copyright file="ValueNode.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Leaf node that represents a constant numerical value.
    /// </summary>
    public class ValueNode : Node
    {
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueNode"/> class.
        /// </summary>
        /// <param name="value"> The value that the leaf will store. </param>
        public ValueNode(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the value of the node.
        /// </summary>
        public double Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// The result of this node.
        /// </summary>
        /// <returns> The value. </returns>
        public override double Compute()
        {
            return this.Value;
        }
    }
}
