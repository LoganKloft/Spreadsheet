// <copyright file="UnsupportedOperatorException.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Use this when trying to access a property or initialize an operator that does not exist.
    /// </summary>
    public class UnsupportedOperatorException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedOperatorException"/> class.
        /// </summary>
        public UnsupportedOperatorException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedOperatorException"/> class.
        /// </summary>
        /// <param name="message"> The error message that should be displayed in the console. </param>
        public UnsupportedOperatorException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedOperatorException"/> class.
        /// </summary>
        /// <param name="message"> The error message that should be displayed in the console. </param>
        /// <param name="inner"> The less specific related error message. </param>
        public UnsupportedOperatorException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
