// <copyright file="BinaryOperatorNodeTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Class the contains the tests for the BinaryOperatorNode class in the SpreadsheetEngine class library.
    /// </summary>
    public class BinaryOperatorNodeTests
    {
        /// <summary>
        /// Tests the proper storing of the leftNode in a BinaryOperatorNode.
        /// </summary>
        [Test]
        public void TestLeftNode()
        {
            BinaryOperatorNodeTestClass binaryOperatorNode = new BinaryOperatorNodeTestClass(null, null);
            CptS321.ValueNode actual = new CptS321.ValueNode(10.0);
            binaryOperatorNode.LeftNode = actual;
            Assert.AreEqual(binaryOperatorNode.LeftNode, actual); // Normal
        }

        /// <summary>
        /// Tests the proper storing of the rightNode in a BinaryOperatorNode.
        /// </summary>
        [Test]
        public void TestRightNode()
        {
            BinaryOperatorNodeTestClass binaryOperatorNode = new BinaryOperatorNodeTestClass(null, null);
            CptS321.ValueNode actual = new CptS321.ValueNode(10.0);
            binaryOperatorNode.RightNode = actual;
            Assert.AreEqual(binaryOperatorNode.RightNode, actual); // Normal
        }

        private class BinaryOperatorNodeTestClass : CptS321.BinaryOperatorNode
        {
            public BinaryOperatorNodeTestClass(CptS321.Node leftNode = null, CptS321.Node rightNode = null)
                : base(leftNode, rightNode)
            {
            }

            public override double Evaluate()
            {
                throw new NotImplementedException();
            }
        }
    }
}
