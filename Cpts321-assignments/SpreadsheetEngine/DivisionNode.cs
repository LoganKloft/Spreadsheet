// <copyright file="DivisionNode.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the division binary operator.
    /// </summary>
    public class DivisionNode : BinaryOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionNode"/> class.
        /// </summary>
        /// <param name="leftNode"> The left child. </param>
        /// <param name="rightNode"> the right child. </param>
        public DivisionNode(Node leftNode = null, Node rightNode = null)
            : base(leftNode, rightNode)
        {
        }

        /// <summary>
        /// Gets the operator.
        /// </summary>
        public static char Operator => '/';

        /// <summary>
        /// Gets the precedence.
        /// </summary>
        public static int Precedence => 6;

        /// <summary>
        /// Gets the associativity.
        /// </summary>
        public static Associative Associativity => Associative.Left;

        /// <summary>
        /// Divides the left and right node.
        /// </summary>
        /// <returns> The value of the left node divided by the right node. </returns>
        public override double Evaluate()
        {
            return this.LeftNode.Evaluate() / this.RightNode.Evaluate();
        }
    }
}
