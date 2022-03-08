// <copyright file="BinaryOperatorNodeFactory.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that controls the creation of BinaryOperatorNodes.
    /// </summary>
    public class BinaryOperatorNodeFactory
    {
        /// <summary>
        /// Given the character representation of an operator, returns the corresponding BinaryOperatorNode.
        /// </summary>
        /// <param name="op"> The character represenatation of a binary operator. </param>
        /// <returns> A child of the BinaryOperatorNode class. </returns>
        public static CptS321.BinaryOperatorNode CreateBinaryOperatorNode(char op)
        {
            switch (op)
            {
                case '+':
                    return new AdditionNode();
                case '-':
                    return new SubtractionNode();
                case '*':
                    return new MultiplicationNode();
                case '/':
                    return new DivisionNode();
                default:
                    return null;
            }
        }
    }
}
