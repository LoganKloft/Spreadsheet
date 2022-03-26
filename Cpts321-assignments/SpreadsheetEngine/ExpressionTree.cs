// <copyright file="ExpressionTree.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class for evaluating expressions.
    /// </summary>
    public class ExpressionTree
    {
        private Dictionary<string, CptS321.ExpressionVariable> variables = new Dictionary<string, CptS321.ExpressionVariable>();
        private Node headNode;
        private string expression;
        private CptS321.BinaryOperatorNodeFactory binaryOperatorNodeFactory = new CptS321.BinaryOperatorNodeFactory(); // load BinaryOperators

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        public ExpressionTree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression"> The expression to be evaluated in string form. </param>
        public ExpressionTree(string expression)
        {
            this.expression = expression;

            // Add variables to the dictionary.
            this.LoadVariables(this.expression);

            // Build the ExpressionTree
            this.Build(this.ParseExpression(this.expression));
        }

        /// <summary>
        /// Gets or Sets expression.
        /// </summary>
        public string Expression
        {
            get
            {
                return this.expression;
            }

            set
            {
                this.expression = value;
                this.LoadVariables(value);
                this.Build(this.ParseExpression(value));
            }
        }

        /// <summary>
        /// Sets the specified variable within the ExpresionTree variables dictionary.
        /// </summary>
        /// <param name="variableName"> The name of the variable, used as the key in the variable dictionary. </param>
        /// <param name="variableValue"> The value associated with the variable. </param>
        public void SetVariable(string variableName, double variableValue)
        {
            if (variableName == null)
            {
                throw new ArgumentException("In SetVariable of ExpressionTree: parameter variableName is null.");
            }

            if (variableName == string.Empty)
            {
                throw new ArgumentException("In SetVariable of ExpressionTree: parameter variableName is an empty string.");
            }

            if (this.variables.ContainsKey(variableName))
            {
                this.variables[variableName].Value = variableValue;
            }
        }

        /// <summary>
        /// Evaluates the expression stored ExpressionTree.
        /// </summary>
        /// <returns> A double value that is the result of evaluating the expression. </returns>
        public double Evaluate()
        {
            return this.headNode.Evaluate();
        }

        /// <summary>
        /// Accepts an expression in infix notation and returns a list of the operands (values and variables)
        /// and operators of the string in infix order.
        /// </summary>
        /// <param name="expression"> A string representing an expression in infix order. </param>
        /// <returns> A list of the operands (values and variables) and operators in infix order. </returns>
        private List<string> ParseExpression(string expression)
        {
            List<string> expressionAsList = new List<string>();
            string expressionElement = string.Empty;

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsWhiteSpace(expression[i]))
                {
                    continue;
                }

                // check for delimeter
                if (!char.IsLetterOrDigit(expression[i]))
                {
                    if (!string.IsNullOrEmpty(expressionElement))
                    {
                        expressionAsList.Add(expressionElement);
                        expressionElement = string.Empty;
                    }

                    expressionAsList.Add(expression[i].ToString());
                }

                // add to value / variable - assumes values and variables are correctly entered
                else
                {
                    expressionElement += expression[i].ToString();
                }
            }

            if (!string.IsNullOrEmpty(expressionElement))
            {
                expressionAsList.Add(expressionElement);
            }

            return expressionAsList;
        }

        /// <summary>
        /// Resets the variable dictionary and fills it out again.
        /// </summary>
        private void LoadVariables(string expression)
        {
            this.variables.Clear();
            List<string> parsedExpression = this.ParseExpression(expression);

            // Add variables to the dictionary.
            foreach (string s in parsedExpression)
            {
                if (char.IsLetter(s[0]))
                {
                    // s is a variable, add to dictionary if not already in it.
                    if (!this.variables.ContainsKey(s))
                    {
                        this.variables.Add(s, new ExpressionVariable(s));
                    }
                }
            }
        }

        /// <summary>
        /// Given two operators, returns a negative value if the first parameter is lower precedence,
        /// 0 if the first parameter is of equal precedence, and greater than 0 if of higher precedence.
        /// </summary>
        /// <param name="s1"> The first operator. </param>
        /// <param name="s2"> The second operator. </param>
        /// <returns> An integer value representing whether the first operator is lower, equal, or higher predence. </returns>
        private int ComparePrecedence(string s1, string s2)
        {
            int p1 = 0;
            int p2 = 0;

            switch (s1)
            {
                case "+":
                    p1 = AdditionNode.Precedence;
                    break;
                case "-":
                    p1 = SubtractionNode.Precedence;
                    break;
                case "/":
                    p1 = DivisionNode.Precedence;
                    break;
                case "*":
                    p1 = MultiplicationNode.Precedence;
                    break;
            }

            switch (s2)
            {
                case "+":
                    p2 = AdditionNode.Precedence;
                    break;
                case "-":
                    p2 = SubtractionNode.Precedence;
                    break;
                case "/":
                    p2 = DivisionNode.Precedence;
                    break;
                case "*":
                    p2 = MultiplicationNode.Precedence;
                    break;
            }

            return p1 - p2;
        }

        /// <summary>
        /// Returns the associativity of an operator.
        /// </summary>
        /// <param name="s"> String representation of an operator. </param>
        private CptS321.BinaryOperatorNode.Associative GetAssociativity(string s)
        {
            switch (s)
            {
                case "+":
                    return AdditionNode.Associativity;
                case "-":
                    return SubtractionNode.Associativity;
                case "/":
                    return DivisionNode.Associativity;
                case "*":
                    return MultiplicationNode.Associativity;
            }

            return CptS321.BinaryOperatorNode.Associative.Left;
        }

        /// <summary>
        /// Uses shunting yard algorithm to convert an infix expression into postfix.
        /// </summary>
        /// <param name="infix"> An expression in list format in infix notation. </param>
        /// <returns> A list of values, variables, and operators in postfix notation. </returns>
        private List<string> InfixToPostfix(List<string> infix)
        {
            // Shunting Yard Algorithm - create postfix expression
            // Assuming variables are 1 character long
            List<string> postfix = new List<string>();
            Stack<string> symbol = new Stack<string>();

            int i = 0;
            while (i < infix.Count)
            {
                // 1 - value or variable
                if (char.IsLetterOrDigit(infix[i][0]))
                {
                    postfix.Add(infix[i]);
                }

                // 2 - left parenthesis
                else if (infix[i] == "(")
                {
                    symbol.Push(infix[i]);
                }

                // 3 - right parenthesis
                else if (infix[i] == ")")
                {
                    string temp = symbol.Pop();
                    while (symbol.Count > 0 && temp != "(")
                    {
                        postfix.Add(temp);
                        temp = symbol.Pop();
                    }
                }

                // operator
                else
                {
                    // 4 - empty stack or left parenthesis on top
                    if (symbol.Count == 0 || symbol.Peek() == "(")
                    {
                        symbol.Push(infix[i]);
                    }

                    // 5 - higher precedence or equal and right-assoc
                    else if (this.ComparePrecedence(infix[i], symbol.Peek()) < 0
                        || (this.ComparePrecedence(infix[i], symbol.Peek()) == 0 &&
                        this.GetAssociativity(infix[i]) == CptS321.BinaryOperatorNode.Associative.Right))
                    {
                        symbol.Push(infix[i]);
                    }

                    // 6 - lower precedence or equal and left-associative
                    else
                    {
                        // lower or equal and left-associative to top
                        while (symbol.Count > 0 && (this.ComparePrecedence(infix[i], symbol.Peek()) > 0
                        || (this.ComparePrecedence(infix[i], symbol.Peek()) == 0 &&
                        this.GetAssociativity(infix[i]) == CptS321.BinaryOperatorNode.Associative.Left)))
                        {
                            postfix.Add(symbol.Pop());
                        }

                        symbol.Push(infix[i]);
                    }
                }

                i++;
            }

            // 7 - Add all operators from stack to postfix
            while (symbol.Count > 0)
            {
                postfix.Add(symbol.Pop());
            }

            return postfix;
        }

        /// <summary>
        /// Builds the parse tree based off of the current expression string.
        /// </summary>
        private void Build(List<string> infix)
        {
            Stack<Node> nodes = new Stack<Node>();
            List<string> postfix = this.InfixToPostfix(infix);

            // Create the Expression Tree.
            foreach (string s in postfix)
            {
                // operand - value
                if (char.IsDigit(s[0]))
                {
                    nodes.Push(new ValueNode(int.Parse(s)));
                }

                // operand - variable
                else if (char.IsLetter(s[0]))
                {
                    nodes.Push(new VariableNode(this.variables[s]));
                }

                // symbol
                else
                {
                    BinaryOperatorNode binaryOperatorNode = null;
                    Node last = nodes.Pop();
                    Node previousToLast = nodes.Pop();
                    switch (s)
                    {
                        case "+":
                            binaryOperatorNode = new AdditionNode();
                            break;
                        case "-":
                            binaryOperatorNode = new SubtractionNode();
                            break;
                        case "/":
                            binaryOperatorNode = new DivisionNode();
                            break;
                        case "*":
                            binaryOperatorNode = new MultiplicationNode();
                            break;
                    }

                    binaryOperatorNode.RightNode = last;
                    binaryOperatorNode.LeftNode = previousToLast;

                    nodes.Push(binaryOperatorNode);
                }
            }

            this.headNode = nodes.Pop();
        }
    }
}
