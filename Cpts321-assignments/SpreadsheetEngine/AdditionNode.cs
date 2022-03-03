// <copyright file="AdditionNode.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the addition binary operator.
    /// </summary>
    public class AdditionNode : BinaryOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionNode"/> class.
        /// </summary>
        /// <param name="leftNode"> The left child. </param>
        /// <param name="rightNode"> the right child. </param>
        public AdditionNode(Node leftNode = null, Node rightNode = null)
            : base(leftNode, rightNode)
        {
        }

        /// <summary>
        /// Adds the left and right node together.
        /// </summary>
        /// <returns> The value of the left node plus the right node. </returns>
        public override double Evaluate()
        {
            return this.LeftNode.Evaluate() + this.RightNode.Evaluate();
        }
    }
}
