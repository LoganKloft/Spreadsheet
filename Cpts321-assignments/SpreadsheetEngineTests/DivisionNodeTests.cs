// <copyright file="DivisionNodeTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the DivisionNode class.
    /// </summary>
    public class DivisionNodeTests
    {
        /// <summary>
        /// Tests the division of two values.
        /// </summary>
        [Test]
        public void TestEvaluateValues()
        {
            CptS321.ValueNode leftNode = new CptS321.ValueNode(5.0);
            CptS321.ValueNode rightNode = new CptS321.ValueNode(5.0);
            CptS321.DivisionNode divisionNode = new CptS321.DivisionNode(leftNode, rightNode); // normal
            double expected = 1.0;
            Assert.AreEqual(expected, divisionNode.Evaluate());
        }

        /// <summary>
        /// Test division by 0.
        /// </summary>
        [Test]
        public void TestEvaluateMaximumValue()
        {
            CptS321.ValueNode leftNode = new CptS321.ValueNode(5.0);
            CptS321.ValueNode rightNode = new CptS321.ValueNode(0.0);
            CptS321.DivisionNode divisionNode = new CptS321.DivisionNode(leftNode, rightNode); // edge
            double expected = double.PositiveInfinity;
            Assert.AreEqual(expected, divisionNode.Evaluate());
        }
    }
}
