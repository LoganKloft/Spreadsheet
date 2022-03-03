// <copyright file="SubtractionNode.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the subtraction binary operator.
    /// </summary>
    public class SubtractionNode : BinaryOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionNode"/> class.
        /// </summary>
        /// <param name="leftNode"> The left child. </param>
        /// <param name="rightNode"> the right child. </param>
        public SubtractionNode(Node leftNode = null, Node rightNode = null)
            : base(leftNode, rightNode)
        {
        }

        /// <summary>
        /// Subtracts the right node from the left..
        /// </summary>
        /// <returns> The value of the right node minus the left node. </returns>
        public override double Evaluate()
        {
            return this.LeftNode.Evaluate() - this.RightNode.Evaluate();
        }
    }
}
