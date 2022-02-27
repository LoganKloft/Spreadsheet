﻿// <copyright file="VariableNode.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Leaf node that represents a variable in an expression.
    /// </summary>
    public class VariableNode : Node
    {
        private ExpressionVariable variable;


        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="variable"> Reference to the variable that this node will store. </param>
        public VariableNode(ExpressionVariable variable)
        {
            this.variable = variable;
        }

        /// <summary>
        /// Gets the variable of this node.
        /// </summary>
        public ExpressionVariable Variable
        {
            get { return this.variable; }
        }
    }
}
