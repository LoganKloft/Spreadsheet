// <copyright file="VariableNodeTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Class that contains test for the VariableNode class in the SpreadsheetEngine class library.
    /// </summary>
    public class VariableNodeTests
    {
        /// <summary>
        /// Affirms that an ExpressionVariable is properly stored inside of a VariableNode.
        /// </summary>
        [Test]
        public void TestVariableNode()
        {
            CptS321.ExpressionVariable expressionVariable = new CptS321.ExpressionVariable("test");
            CptS321.VariableNode testVariableNode = new CptS321.VariableNode(expressionVariable);
            Assert.AreEqual(testVariableNode.Variable, expressionVariable); // Normal
        }
    }
}
