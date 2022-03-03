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

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression"> The expression to be evaluated in string form. </param>
        public ExpressionTree(string expression)
        {
            this.expression = expression;

            // Add variables to the dictionary.
            this.LoadVariables();

            // Build the ExpressionTree
            this.Build();
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
                this.LoadVariables();
                this.Build();
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
        /// Extracts the operands and operators from the input string.
        /// </summary>
        /// <param name="expression"> A string represening an expression. </param>
        /// <returns> A list of the operands and operators contained in expression an expression. </returns>
        private List<string> ParseExpression(string expression)
        {
            List<string> expressionAsList = new List<string>();
            string expressionElement = string.Empty;

            for (int i = 0; i < expression.Length; i++)
            {
                if (!char.IsLetterOrDigit(expression[i]))
                {
                    // found a delimiter
                    if (!string.IsNullOrEmpty(expressionElement))
                    {
                        expressionAsList.Add(expressionElement);
                        expressionAsList.Add(expression[i].ToString());
                        expressionElement = string.Empty;
                    }
                    else
                    {
                        expressionElement += expression[i].ToString();
                    }
                }
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
        private void LoadVariables()
        {
            this.variables.Clear();
            List<string> parsedExpression = this.ParseExpression(this.expression);

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
        /// Builds the parse tree based off of the current expression string.
        /// </summary>
        private void Build()
        {
            Queue<Node> nodes = new Queue<Node>();
            Queue<string> operatorStack = new Queue<string>();

            List<string> parsedExpression = this.ParseExpression(this.expression);

            // Create the Expression Tree.
            string operatorString = "+-/*";

            foreach (string s in parsedExpression)
            {
                if (operatorString.Contains(s))
                {
                    // s is an operator
                    operatorStack.Enqueue(s);
                }
                else
                {
                    // s is an operand
                    if (char.IsLetter(s[0]))
                    {
                        // s is a variable
                        nodes.Enqueue(new VariableNode(this.variables[s]));
                    }
                    else
                    {
                        // s is a value
                        int value = 0;
                        int.TryParse(s, out value);

                        nodes.Enqueue(new ValueNode(value));
                    }

                    if (nodes.Count > 1 && operatorStack.Count > 0)
                    {
                        // enough nodes to create a new headNode.
                        string op = operatorStack.Dequeue();
                        BinaryOperatorNode interiorNode = null;

                        if (op == "+")
                        {
                            interiorNode = new CptS321.AdditionNode(nodes.Dequeue(), nodes.Dequeue());
                        }
                        else if (op == "-")
                        {
                            interiorNode = new CptS321.SubtractionNode(nodes.Dequeue(), nodes.Dequeue());
                        }
                        else if (op == "/")
                        {
                            interiorNode = new CptS321.DivisionNode(nodes.Dequeue(), nodes.Dequeue());
                        }
                        else
                        {
                            // multiplication
                            interiorNode = new CptS321.MultiplicationNode(nodes.Dequeue(), nodes.Dequeue());
                        }

                        // push node to queue
                        nodes.Enqueue(interiorNode);
                    }
                }
            }

            this.headNode = nodes.Dequeue();
        }
    }
}
