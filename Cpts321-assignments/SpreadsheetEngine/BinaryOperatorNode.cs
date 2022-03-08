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
    public abstract class BinaryOperatorNode : Node
    {
        private Node leftNode;
        private Node rightNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperatorNode"/> class.
        /// </summary>
        /// <param name="leftNode"> Reference to the left node. </param>
        /// <param name="rightNode"> Reference to the right node. </param>
        public BinaryOperatorNode(Node leftNode = null, Node rightNode = null)
        {
            this.LeftNode = leftNode;
            this.RightNode = rightNode;
        }

        /// <summary>
        /// Represents the associative of a binary operator.
        /// </summary>
        public enum Associative
        {
            /// <summary>
            /// The operator is Right associative.
            /// </summary>
            Right,

            /// <summary>
            /// The operator is Left associative.
            /// </summary>
            Left,
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
    }
}
