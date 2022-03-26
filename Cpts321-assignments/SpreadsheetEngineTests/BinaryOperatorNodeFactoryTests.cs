// <copyright file="BinaryOperatorNodeFactoryTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Class that contains the tests for the BinaryOperatorNodeFactory class.
    /// </summary>
    public class BinaryOperatorNodeFactoryTests
    {
        /// <summary>
        /// Adds operators to operator dictionary.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            CptS321.BinaryOperatorNodeFactory binaryOperatorNodeFactory = new CptS321.BinaryOperatorNodeFactory();
        }

        /// <summary>
        /// Tests the creation of an AdditionNode.
        /// </summary>
        [Test]
        public void TestCreateBinaryOperatorNodeAddition()
        {
            object testNode = CptS321.BinaryOperatorNodeFactory.CreateBinaryOperatorNode('+');
            bool passed = false;
            if (testNode is CptS321.AdditionNode)
            {
                passed = true;
            }

            Assert.True(passed); // normal
        }

        /// <summary>
        /// Tests the creation of an SubtractionNode.
        /// </summary>
        [Test]
        public void TestCreateBinaryOperatorNodeSubtraction()
        {
            object testNode = CptS321.BinaryOperatorNodeFactory.CreateBinaryOperatorNode('-');
            bool passed = false;
            if (testNode is CptS321.SubtractionNode)
            {
                passed = true;
            }

            Assert.True(passed); // normal
        }

        /// <summary>
        /// Tests the creation of an MultiplicationNode.
        /// </summary>
        [Test]
        public void TestCreateBinaryOperatorNodeMultiplication()
        {
            object testNode = CptS321.BinaryOperatorNodeFactory.CreateBinaryOperatorNode('*');
            bool passed = false;
            if (testNode is CptS321.MultiplicationNode)
            {
                passed = true;
            }

            Assert.True(passed); // normal
        }

        /// <summary>
        /// Tests the creation of an DivisionNode.
        /// </summary>
        [Test]
        public void TestCreateBinaryOperatorNodeDivision()
        {
            object testNode = CptS321.BinaryOperatorNodeFactory.CreateBinaryOperatorNode('/');
            bool passed = false;
            if (testNode is CptS321.DivisionNode)
            {
                passed = true;
            }

            Assert.True(passed); // normal
        }

        /// <summary>
        /// Test that uses a non-existing BinaryOperator.
        /// </summary>
        [Test]
        public void TestCreateBinaryOperatorNodeBadOperator()
        {
            Assert.Throws<Exception>(() => CptS321.BinaryOperatorNodeFactory.CreateBinaryOperatorNode('a')); // edge
        }
    }
}
