// <copyright file="MultiplicationNodeTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the MultiplicationNode class.
    /// </summary>
    public class MultiplicationNodeTests
    {
        /// <summary>
        /// Test the multiplication of two nodes.
        /// </summary>
        [Test]
        public void TestEvaluateValue()
        {
            CptS321.ValueNode leftNode = new CptS321.ValueNode(5.0);
            CptS321.ValueNode rightNode = new CptS321.ValueNode(5.0);
            CptS321.MultiplicationNode multiplicationNode = new CptS321.MultiplicationNode(leftNode, rightNode); // normal
            double expected = 25.0;
            Assert.AreEqual(expected, multiplicationNode.Evaluate());
        }

        /// <summary>
        /// Test the multiplication of two nodes with maximum double values.
        /// </summary>
        [Test]
        public void TestEvaluateMaximumValue()
        {
            CptS321.ValueNode leftNode = new CptS321.ValueNode(double.MaxValue);
            CptS321.ValueNode rightNode = new CptS321.ValueNode(double.MaxValue);
            CptS321.MultiplicationNode multiplicationNode = new CptS321.MultiplicationNode(leftNode, rightNode); // edge
            double expected = double.PositiveInfinity;
            Assert.AreEqual(expected, multiplicationNode.Evaluate());
        }
    }
}
