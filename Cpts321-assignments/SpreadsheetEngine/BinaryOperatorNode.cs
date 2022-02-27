// <copyright file="BinaryOperatorNode.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that represents an operator in an expression.
    /// </summary>
    public class BinaryOperatorNode : Node
    {
        private Node leftNode;
        private Node rightNode;
        private BinaryOperator op;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperatorNode"/> class.
        /// </summary>
        /// <param name="op"> The operator of the BinaryOperatorNode. </param>
        /// <param name="leftNode"> Reference to the left node. </param>
        /// <param name="rightNode"> Reference to the right node. </param>
        public BinaryOperatorNode(BinaryOperator op, Node leftNode, Node rightNode)
        {
            this.op = op;
            this.LeftNode = leftNode;
            this.RightNode = rightNode;
        }

        /// <summary>
        /// Gets or sets leftNode.
        /// </summary>
        public Node LeftNode
        {
            get { return this.leftNode; }
            set { this.leftNode = value; }
        }

        /// <summary>
        /// Gets or sets rightNode.
        /// </summary>
        public Node RightNode
        {
            get { return this.rightNode; }
            set { this.rightNode = value; }
        }

        /// <summary>
        /// Gets op.
        /// </summary>
        public BinaryOperator Op
        {
            get { return this.op; }
        }

        /// <summary>
        /// The result of this node.
        /// </summary>
        /// <returns> The value. </returns>
        public override double Evaluate()
        {
            return this.Op.Compute(this.LeftNode.Evaluate(), this.RightNode.Evaluate());
        }
    }
}
