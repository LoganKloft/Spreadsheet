// <copyright file="ExpressionTreeTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Class for testing the ExpressionTree class in class library SpreadsheetEngine.
    /// </summary>
    public class ExpressionTreeTests
    {
        private CptS321.ExpressionTree expressionTree = new CptS321.ExpressionTree();

        /// <summary>
        /// ExpressionTree should throw an exception when an expression is evaluated with no value.
        /// </summary>
        [Test]
        public void TestDefaultVariableValue()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A2+B2");
            Assert.Throws<System.InvalidOperationException>(() => testExpressionTree.Evaluate()); // edge
        }

        /// <summary>
        /// Expressions should ignore white spaces during the parsing stage.
        /// </summary>
        [Test]
        public void TestIgnoreWhiteSpaces()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("3    + 4      * 5");
            Assert.AreEqual(23, testExpressionTree.Evaluate());
        }

        /// <summary>
        /// Tests to make sure infix expressions are correctly transformed into a list.
        /// </summary>
        [Test]
        public void TestParseExpression()
        {
            MethodInfo methodInfo = this.GetMethod("ParseExpression", new Type[] { typeof(string) });
            List<string> expected = new List<string> { "(", "a", "+", "b", ")" };
            Assert.That(methodInfo.Invoke(this.expressionTree, new object[] { "(a+b)" }), Is.EqualTo(expected)); // normal
        }

        /// <summary>
        /// Test to make sure the conversion of a list from infix to postfix is done correctly.
        /// </summary>
        [Test]
        public void TestInfixToPostfixNormal()
        {
            MethodInfo methodInfo = this.GetMethod("InfixToPostfix", new Type[] { typeof(List<string>) });
            List<string> prefix = new List<string> { "a", "b", "c", "*", "+" };
            List<string> infix = new List<string> { "(", "a", "+", "b", "*", "c", ")" };
            Assert.That(methodInfo.Invoke(this.expressionTree, new object[] { infix }), Is.EqualTo(prefix)); // normal with + and * operator
        }

        /// <summary>
        /// Uses parenthesis, and the first four operators that are defined.
        /// </summary>
        [Test]
        public void TestInfixToPostfixAllOperators()
        {
            MethodInfo methodInfo = this.GetMethod("InfixToPostfix", new Type[] { typeof(List<string>) });
            List<string> infix = new List<string> { "(", "A", "+", "2", "*", "3", ")", "/", "B", "*", "4", "-", "1", "+", "(", "2", "-", "(", "C", "*", "4", ")", ")" };
            List<string> prefix = new List<string> { "A", "2", "3", "*", "+", "B", "/", "4", "*", "1", "-", "2", "C", "4", "*", "-", "+" };
            Assert.That(methodInfo.Invoke(this.expressionTree, new object[] { infix }), Is.EqualTo(prefix)); // normal with +,/,-,*,(,and)
        }

        /// <summary>
        /// Tests precedence of operators and the use of parenthesis.
        /// </summary>
        /// <param name="expression"> String format of an expression in infix notation. </param>
        /// <returns> The evaluation of the expression. </returns>
        [Test]
        [TestCase("3+5", ExpectedResult = 8.0)] // simple expression with a single operator
        [TestCase("100/10*10", ExpectedResult = 100.0)] // mixing operators (/ and *) with same precedence
        [TestCase("100/(10*10)", ExpectedResult = 1.0)] // mixing operators (/ and *) with same precedence and parenthesis
        [TestCase("7-4+2", ExpectedResult = 5.0)] // mixing operators (+ and -) with same precedence
        [TestCase("10/(7-2)", ExpectedResult = 2.0)] // operators with difference precedence with parenthesis - higher precedence
        [TestCase("(12-2)/2", ExpectedResult = 5.0)] // operators with difference precedence with parenthesis - lower precedence
        [TestCase("(((((2+3)-(4+5)))))", ExpectedResult = -4.0)] // extra parenthesis and negative result
        [TestCase("2*3+5", ExpectedResult = 11.0)] // operators with different precedence - higher precedence first
        [TestCase("2+3*5", ExpectedResult = 17.0)] // operators with different precedence - lower precedence first
        [TestCase("2+3*5", ExpectedResult = 17.0)] // spaces and mixing operators (+ and *) with difference precedence
        public double TestEvaluateNormalCases(string expression) // not throwing any exceptions
        {
            CptS321.ExpressionTree exp = new CptS321.ExpressionTree(expression);
            return exp.Evaluate();
        }

        /// <summary>
        /// Tests to ensure the expression is correctly parsed. For this parse, there are no variables.
        /// </summary>
        [Test]
        public void TestConstructorWithNoVariables()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("1+12+123123");
            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.AreEqual(0, testExpressionTreeDictionary.Count); // Normal
        }

        /// <summary>
        /// Tests to ensure the expression is correctly parsed. For this parse, a single uppercase character.
        /// </summary>
        [Test]
        public void TestConstructorCapitalCharacter()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A+a+A2+aa+A2a");
            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.True(testExpressionTreeDictionary.ContainsKey("A")); // Normal
        }

        /// <summary>
        /// Tests to ensure the expression is correctly parsed. For this parse, a single lowercase character.
        /// </summary>
        [Test]
        public void TestConstructorLowercaseCharacter()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A+a+A2+aa+A2a");
            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.True(testExpressionTreeDictionary.ContainsKey("a")); // Normal
        }

        /// <summary>
        /// Tests to ensure the expression is correctly parsed. For this parse, a combination of a character followed by one or more integers.
        /// </summary>
        [Test]
        public void TestConstructorCharacterInteger()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A+a+A2+aa+A2a");
            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.True(testExpressionTreeDictionary.ContainsKey("A2")); // Normal
        }

        /// <summary>
        /// Tests to ensure the expression is correctly parsed. For this parse, a combination of more than one character.
        /// </summary>
        [Test]
        public void TestConstructorCharacterCharacter()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A+a+A2+aa+A2a");
            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.True(testExpressionTreeDictionary.ContainsKey("aa")); // Normal
        }

        /// <summary>
        /// Tests to ensure the expression is correctly parsed. For this parse, a combination of a character followed by a digit followed by a character.
        /// </summary>
        [Test]
        public void TestConstructorCharacterIntegerCombination()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A+a+A2+aa+A2a");
            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.True(testExpressionTreeDictionary.ContainsKey("A2a")); // Normal
        }

        /// <summary>
        /// Test providing an empty string for the variableName parameter.
        /// </summary>
        [Test]
        public void TestSetVariableEmptyString()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A1+B1+C1");
            Assert.Throws<System.ArgumentException>(() => testExpressionTree.SetVariable(string.Empty, 5.0)); // Exceptional
        }

        /// <summary>
        /// Test providing a null string for the variableName parameter.
        /// </summary>
        [Test]
        public void TestSetVariableNullString()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A1+B1+C1");
            Assert.Throws<System.ArgumentException>(() => testExpressionTree.SetVariable(null, 5.0)); // Exceptional
        }

        /// <summary>
        /// Test setting a variable that does not exist.
        /// </summary>
        [Test]
        public void TestSetVariableDoesNotExist()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A1+B1+C1");
            testExpressionTree.SetVariable("D1", 5.0);
            Assert.Pass(); // Edge
        }

        /// <summary>
        /// Test providing the maximum double value for the variableValue parameter.
        /// </summary>
        [Test]
        public void TestSetVariableValueMaximum()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A");
            double testValue = double.MaxValue;
            testExpressionTree.SetVariable("A", testValue);

            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.AreEqual(testValue, testExpressionTreeDictionary["A"].Value); // Edge
        }

        /// <summary>
        /// Test providing the minimum double value for the variableValue parameter.
        /// </summary>
        [Test]
        public void TestSetVariableValueMinimum()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A");
            double testValue = double.MinValue;
            testExpressionTree.SetVariable("A", testValue);

            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.AreEqual(testValue, testExpressionTreeDictionary["A"].Value); // Edge
        }

        /// <summary>
        /// Test providing 0.0 as the double value for the variableValue parameter.
        /// </summary>
        [Test]
        public void TestSetVariableValueZero()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A");
            double testValue = 0.0;
            testExpressionTree.SetVariable("A", testValue);

            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.AreEqual(testValue, testExpressionTreeDictionary["A"].Value); // Edge
        }

        /// <summary>
        /// Test providing 5.0 as the double value for the variableValue parameter.
        /// </summary>
        [Test]
        public void TestSetVariableValueNormal()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A");
            double testValue = 5.0;
            testExpressionTree.SetVariable("A", testValue);

            Type expressionTreeType = typeof(CptS321.ExpressionTree);
            FieldInfo expressionTreeInfo = expressionTreeType.GetField("variables", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, CptS321.ExpressionVariable> testExpressionTreeDictionary = (Dictionary<string, CptS321.ExpressionVariable>)expressionTreeInfo.GetValue(testExpressionTree);

            Assert.AreEqual(testValue, testExpressionTreeDictionary["A"].Value); // Normal
        }

        /// <summary>
        /// Tests an expression that has one variable.
        /// </summary>
        [Test]
        public void TestEvaluateOneVariable()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A");
            testExpressionTree.SetVariable("A", 2.0);
            double expected = 2.0;
            Assert.AreEqual(expected, testExpressionTree.Evaluate()); // Edge
        }

        /// <summary>
        /// Tests an expression that has one value.
        /// </summary>
        [Test]
        public void TestEvaluateOneValue()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("5");
            double expected = 5.0;
            Assert.AreEqual(expected, testExpressionTree.Evaluate()); // Edge
        }

        /// <summary>
        /// Tests an expression that has only variables and addition.
        /// </summary>
        [Test]
        public void TestEvaluateAdditionWithVariables()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A+B");
            testExpressionTree.SetVariable("A", 5.0);
            testExpressionTree.SetVariable("B", 5.0);
            double expected = 10.0;
            Assert.AreEqual(expected, testExpressionTree.Evaluate());
        }

        /// <summary>
        /// Tests an expression that has only values and addition.
        /// </summary>
        [Test]
        public void TestEvaluateAdditionWithValues()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("5+5");
            double expected = 10.0;
            Assert.AreEqual(expected, testExpressionTree.Evaluate());
        }

        /// <summary>
        /// Tests an expression that has variables, values, and addition.
        /// </summary>
        [Test]
        public void TestEvaluateAdditionWithVariablesAndValues()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A+5");
            testExpressionTree.SetVariable("A", 5.0);
            double expected = 10.0;
            Assert.AreEqual(expected, testExpressionTree.Evaluate());
        }

        /// <summary>
        /// Tests an expression that has variables, values, and subtraction.
        /// </summary>
        [Test]
        public void TestEvaluateWithSubtraction()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A-5");
            testExpressionTree.SetVariable("A", 10.0);
            double expected = 5.0;
            Assert.AreEqual(expected, testExpressionTree.Evaluate());
        }

        /// <summary>
        /// Tests an expression that has variables, values, and multiplication.
        /// </summary>
        [Test]
        public void TestEvaluateWithMultiplcation()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A*5");
            testExpressionTree.SetVariable("A", 5.0);
            double expected = 25.0;
            Assert.AreEqual(expected, testExpressionTree.Evaluate());
        }

        /// <summary>
        /// Tests an expression that has variables, values, and division.
        /// </summary>
        [Test]
        public void TestEvaluateWithDivision()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A/5");
            testExpressionTree.SetVariable("A", 5.0);
            double expected = 1.0;
            Assert.AreEqual(expected, testExpressionTree.Evaluate());
        }

        /// <summary>
        /// Tests an expression that divides by zero.
        /// </summary>
        [Test]
        public void TestEvaluateDivideByZero()
        {
            CptS321.ExpressionTree testExpressionTree = new CptS321.ExpressionTree("A/0");
            testExpressionTree.SetVariable("A", 5.0);
            Assert.AreEqual(double.PositiveInfinity, testExpressionTree.Evaluate());
        }

        private MethodInfo GetMethod(string methodName, Type[] parameterTypes)
        {
            if (string.IsNullOrWhiteSpace(methodName))
            {
                Assert.Fail("methodName cannot be null or whitespace");
            }

            var method = this.expressionTree.GetType().GetMethod(
                methodName,
                BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance,
                null,
                parameterTypes,
                null);

            if (method == null)
            {
                Assert.Fail(string.Format("{0} method not found", methodName));
            }

            return method;
        }
    }
}
