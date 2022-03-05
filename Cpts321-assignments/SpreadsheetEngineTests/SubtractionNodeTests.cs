// <copyright file="SubtractionNodeTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the SubtractionNode class.
    /// </summary>
    public class SubtractionNodeTests
    {
        /// <summary>
        /// Test the subtraction of two nodes.
        /// </summary>
        [Test]
        public void TestEvaluateValue()
        {
            CptS321.ValueNode leftNode = new CptS321.ValueNode(5.0);
            CptS321.ValueNode rightNode = new CptS321.ValueNode(5.0);
            CptS321.SubtractionNode subtractionNode = new CptS321.SubtractionNode(leftNode, rightNode); // normal
            double expected = 0.0;
            Assert.AreEqual(expected, subtractionNode.Evaluate());
        }

        /// <summary>
        /// Test the subtraction of two nodes whose result is the minimum double value.
        /// </summary>
        [Test]
        public void TestEvaluateMinimumValue()
        {
            CptS321.ValueNode leftNode = new CptS321.ValueNode(double.MinValue);
            CptS321.ValueNode rightNode = new CptS321.ValueNode(double.MaxValue);
            CptS321.SubtractionNode subtractionNode = new CptS321.SubtractionNode(leftNode, rightNode); // edge
            double expected = double.NegativeInfinity;
            Assert.AreEqual(expected, subtractionNode.Evaluate());
        }
    }
}
