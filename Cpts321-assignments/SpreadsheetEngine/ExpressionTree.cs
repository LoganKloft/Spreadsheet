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

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression"> The expression to be evaluated in string form. </param>
        public ExpressionTree(string expression)
        {
            string[] parsedExpression = this.ParseExpression(expression);
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
        /// Extracts the operands and operators from the input string.
        /// </summary>
        /// <param name="expression"> A string represening an expression. </param>
        /// <returns> The list operands and operators contained in expression. </returns>
        private string[] ParseExpression(string expression)
        {
            char[] separators = { '+', '-', '/', '*' };
            return expression.Split(separators);
        }

        /// <summary>
        /// Sets the specified variable within the ExpresionTree variables dictionary.
        /// </summary>
        /// <param name="variableName"> The name of the variable, used as the key in the variable dictionary. </param>
        /// <param name="variableValue"> The value associated with the variable. </param>
        public void SetVariable(string variableName, double variableValue)
        {
        }

        /// <summary>
        /// Evaluates the expression stored ExpressionTree.
        /// </summary>
        /// <returns> A double value that is the result of evaluating the expression. </returns>
        public double Evaluate()
        {
            return 0.0;
        }
    }
}
