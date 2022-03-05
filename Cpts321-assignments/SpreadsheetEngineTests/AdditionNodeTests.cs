// <copyright file="AdditionNodeTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the AdditionNode class.
    /// </summary>
    public class AdditionNodeTests
    {
        /// <summary>
        /// Test the addition of two nodes.
        /// </summary>
        [Test]
        public void TestEvaluateValue()
        {
            CptS321.ValueNode leftNode = new CptS321.ValueNode(5.0);
            CptS321.ValueNode rightNode = new CptS321.ValueNode(5.0);
            CptS321.AdditionNode additionNode = new CptS321.AdditionNode(leftNode, rightNode); // normal
            double expected = 10.0;
            Assert.AreEqual(expected, additionNode.Evaluate());
        }

        /// <summary>
        /// Test the addition of two nodes with maximum double values.
        /// </summary>
        [Test]
        public void TestEvaluateMaximumValue()
        {
            CptS321.ValueNode leftNode = new CptS321.ValueNode(double.MaxValue);
            CptS321.ValueNode rightNode = new CptS321.ValueNode(double.MaxValue);
            CptS321.AdditionNode additionNode = new CptS321.AdditionNode(leftNode, rightNode); // edge
            double expected = double.PositiveInfinity;
            Assert.AreEqual(expected, additionNode.Evaluate());
        }
    }
}
