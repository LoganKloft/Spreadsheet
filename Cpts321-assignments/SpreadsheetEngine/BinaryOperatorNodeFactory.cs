// <copyright file="BinaryOperatorNodeFactory.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class that controls the creation of BinaryOperatorNodes.
    /// </summary>
    public class BinaryOperatorNodeFactory
    {
        private static Dictionary<string, Type> operators = new Dictionary<string, Type>();
        private static Dictionary<string, CptS321.BinaryOperatorNode.Associative> associativities = new Dictionary<string, BinaryOperatorNode.Associative>();
        private static Dictionary<string, int> precedences = new Dictionary<string, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperatorNodeFactory"/> class.
        /// </summary>
        public BinaryOperatorNodeFactory()
        {
            this.TraverseAvailableOperators(
                (op, type) =>
            {
                if (!operators.ContainsKey(op))
                {
                    operators.Add(op, type);
                }
            },
                (op, precedence) =>
            {
                if (!precedences.ContainsKey(op))
                {
                    precedences.Add(op, precedence);
                }
            },
                (op, associativty) =>
            {
                if (!associativities.ContainsKey(op))
                {
                    associativities.Add(op, associativty);
                }
            });
        }

        private delegate void OnOperator(string op, Type type);

        private delegate void OnPrecedence(string op, int precedence);

        private delegate void OnAssociativity(string op, CptS321.BinaryOperatorNode.Associative associativity);

        /// <summary>
        /// Given the character representation of an operator, returns the corresponding BinaryOperatorNode.
        /// </summary>
        /// <param name="op"> The character represenatation of a binary operator. </param>
        /// <returns> A child of the BinaryOperatorNode class. </returns>
        public static CptS321.BinaryOperatorNode CreateBinaryOperatorNode(string op)
        {
            if (operators.ContainsKey(op))
            {
                object binaryOperatorNodeType = System.Activator.CreateInstance(operators[op]);
                if (binaryOperatorNodeType is CptS321.BinaryOperatorNode)
                {
                    return (CptS321.BinaryOperatorNode)binaryOperatorNodeType;
                }
            }

            throw new CptS321.UnsupportedOperatorException("Unhandled operator: " + op);
        }

        /// <summary>
        /// Given two operators, returns a negative value if the first parameter is lower precedence,
        /// 0 if the first parameter is of equal precedence, and greater than 0 if of higher precedence.
        /// </summary>
        /// <param name="op1"> The first operator. </param>
        /// <param name="op2"> The second operator. </param>
        /// <returns> An integer value representing whether the first operator is lower, equal, or higher predence. </returns>
        public static int ComparePrecedence(string op1, string op2)
        {
            if (precedences.ContainsKey(op1) && precedences.ContainsKey(op2))
            {
                return precedences[op1] - precedences[op2];
            }

            throw new CptS321.UnsupportedOperatorException("Unhandled operator: " + op1 + " or " + op2);
        }

        /// <summary>
        /// Returns the associativity of an operator.
        /// </summary>
        /// <param name="op"> String representation of an operator. </param>
        /// <returns> The associativity of the given operator. </returns>
        public static CptS321.BinaryOperatorNode.Associative GetAssociativity(string op)
        {
            if (associativities.ContainsKey(op))
            {
                return associativities[op];
            }

            throw new CptS321.UnsupportedOperatorException("Unhandled operator: " + op);
        }

        private void TraverseAvailableOperators(OnOperator onOperator, OnPrecedence onPrecedence, OnAssociativity onAssociativity)
        {
            // get the type declaration of OperatorNode
            Type binaryOperatorNodeType = typeof(CptS321.BinaryOperatorNode);

            // Iterate over all loaded assemblies:
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Get all types that inherit from our OperatorNode class using LINQ
                IEnumerable<Type> binaryOperatorTypes =
                assembly.GetTypes().Where(type => type.IsSubclassOf(binaryOperatorNodeType));

                // Iterate over those subclasses of OperatorNode
                foreach (var type in binaryOperatorTypes)
                {
                    // for each subclass, retrieve the Operator property
                    System.Reflection.PropertyInfo binaryOperatorOperatorField = type.GetProperty("Operator");
                    System.Reflection.PropertyInfo binaryOperatorPrecedenceField = type.GetProperty("Precedence");
                    System.Reflection.PropertyInfo binaryOperatorAssociativityField = type.GetProperty("Associativity");

                    if (binaryOperatorOperatorField != null && binaryOperatorPrecedenceField != null && binaryOperatorAssociativityField != null)
                    {
                        // Get the character of the Operator
                        object operatorValue = binaryOperatorOperatorField.GetValue(type);
                        object precedenceValue = binaryOperatorPrecedenceField.GetValue(type);
                        object associativityValue = binaryOperatorAssociativityField.GetValue(type);

                        // If the property is not static, use the following code instead:
                        // object value = operatorField.GetValue(Activator.CreateInstance(type,
                        //                      new ConstantNode("0"), new ConstantNode("0")));
                        if (operatorValue is char && precedenceValue is int && associativityValue is CptS321.BinaryOperatorNode.Associative)
                        {
                            string binaryOperatorSymbol = ((char)operatorValue).ToString();
                            int binaryOperatorPrecedence = (int)precedenceValue;
                            CptS321.BinaryOperatorNode.Associative binaryOperatorAssociativity = (CptS321.BinaryOperatorNode.Associative)associativityValue;

                            // And invoke the function passed as parameter
                            // with the operator symbol and the operator class
                            onOperator(binaryOperatorSymbol, type);
                            onPrecedence(binaryOperatorSymbol, binaryOperatorPrecedence);
                            onAssociativity(binaryOperatorSymbol, binaryOperatorAssociativity);
                        }
                    }
                }
            }
        }
    }
}
