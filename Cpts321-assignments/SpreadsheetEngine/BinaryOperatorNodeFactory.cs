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
        private static Dictionary<char, Type> operators = new Dictionary<char, Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperatorNodeFactory"/> class.
        /// </summary>
        public BinaryOperatorNodeFactory()
        {
            this.TraverseAvailableOperators((op, type) =>
            {
                if (!operators.ContainsKey(op))
                {
                    operators.Add(op, type);
                }
            });
        }

        private delegate void OnOperator(char op, Type type);

        /// <summary>
        /// Given the character representation of an operator, returns the corresponding BinaryOperatorNode.
        /// </summary>
        /// <param name="op"> The character represenatation of a binary operator. </param>
        /// <returns> A child of the BinaryOperatorNode class. </returns>
        public static CptS321.BinaryOperatorNode CreateBinaryOperatorNode(char op)
        {
            if (operators.ContainsKey(op))
            {
                object binaryOperatorNodeType = System.Activator.CreateInstance(operators[op]);
                if (binaryOperatorNodeType is CptS321.BinaryOperatorNode)
                {
                    return (CptS321.BinaryOperatorNode)binaryOperatorNodeType;
                }
            }

            throw new Exception("Unhandled operator");
        }

        private void TraverseAvailableOperators(OnOperator onOperator)
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
                    System.Reflection.PropertyInfo binaryOperatorField = type.GetProperty("Operator");
                    if (binaryOperatorField != null)
                    {
                        // Get the character of the Operator
                        object value = binaryOperatorField.GetValue(type);

                        // If the property is not static, use the following code instead:
                        // object value = operatorField.GetValue(Activator.CreateInstance(type,
                        //                      new ConstantNode("0"), new ConstantNode("0")));
                        if (value is char)
                        {
                            char binaryOperatorSymbol = (char)value;

                            // And invoke the function passed as parameter
                            // with the operator symbol and the operator class
                            onOperator(binaryOperatorSymbol, type);
                        }
                    }
                }
            }
        }
    }
}
