// <copyright file="ValueNodeTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the ValueNode class of the SpreadsheetEngine class library.
    /// </summary>
    public class ValueNodeTests
    {
        /// <summary>
        /// Tests the proper storing of a normal value in ValueNode.
        /// </summary>
        [Test]
        public void TestValueNode()
        {
            CptS321.ValueNode valueNode = new CptS321.ValueNode(5.0);
            Assert.AreEqual(valueNode.Value, 5.0); // Normal
        }

        /// <summary>
        /// Tests the proper storing of a zero value in ValueNode.
        /// </summary>
        [Test]
        public void TestValueNodeZero()
        {
            CptS321.ValueNode valueNode = new CptS321.ValueNode(0.0);
            Assert.AreEqual(valueNode.Value, 0.0); // Edge
        }

        /// <summary>
        /// Tests the proper storing of a minimum value in a ValueNode.
        /// </summary>
        [Test]
        public void TestValueNodeMaxMinimum()
        {
            CptS321.ValueNode valueNode = new CptS321.ValueNode(double.MinValue);
            Assert.AreEqual(valueNode.Value, double.MinValue); // Edge
        }

        /// <summary>
        /// Tests the proper storing of a maximum value in a ValueNode.
        /// </summary>
        [Test]
        public void TestValueNodeMaxValue()
        {
            CptS321.ValueNode valueNode = new CptS321.ValueNode(double.MaxValue);
            Assert.AreEqual(valueNode.Value, double.MaxValue); // Edge
        }
    }
}
