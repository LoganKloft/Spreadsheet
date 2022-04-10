// <copyright file="Globals.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Defines global varaibles for the spreadsheet application.
    /// </summary>
    public static class Globals
    {
        /// <summary>
        /// Contains the global variables for the SpreadsheetCell class.
        /// </summary>
        public static class SpreadsheetCell
        {
            /// <summary>
            /// Gets the default value for the BGColor property of the SpreadsheetCell class.
            /// </summary>
            public static uint Default_BGColor
            {
                get
                {
                    return 0xFFFFFFFF;
                }
            }

            /// <summary>
            /// Gets the default value for the Text property of teh SpreadsheetCell class.
            /// </summary>
            public static string Default_Text
            {
                get
                {
                    return string.Empty;
                }
            }
        }
    }
}
