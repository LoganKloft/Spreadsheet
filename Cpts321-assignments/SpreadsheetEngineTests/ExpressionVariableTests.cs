// <copyright file="ExpressionVariableTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Class for testing the ExpressionVariable class in the SpreadsheetEngine class library.
    /// </summary>
    public class ExpressionVariableTests
    {
        /// <summary>
        /// Tests the getter and setter for the Name property of the ExpressionVariable class.
        /// </summary>
        [Test]
        public void TestName()
        {
            CptS321.ExpressionVariable expressionVariable = new CptS321.ExpressionVariable(string.Empty);
            string actual = "test";
            expressionVariable.Name = actual;
            Assert.AreEqual(expressionVariable.Name, actual); // Normal
        }

        /// <summary>
        /// Tests the getter and setter for the Value property of the ExpressionVaraible class.
        /// </summary>
        [Test]
        public void TestValue()
        {
            CptS321.ExpressionVariable expressionVariable = new CptS321.ExpressionVariable(string.Empty);
            double actual = 5.0;
            expressionVariable.Value = actual;
            Assert.AreEqual(expressionVariable.Value, actual); // Normal
        }
    }
}
