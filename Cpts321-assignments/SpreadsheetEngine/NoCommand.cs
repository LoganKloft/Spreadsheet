// <copyright file="NoCommand.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The NoCommand is used as a plcae holder for a command that does nothing.
    /// </summary>
    public class NoCommand : CptS321.ICommand
    {
        /// <summary>
        /// Represents a command that does nothing. Used as a place holder instead of null.
        /// </summary>
        public void Execute()
        {
        }

        /// <summary>
        /// Represents a command that does nothing. Used as a place holder instead of null.
        /// </summary>
        public void Unexecute()
        {
        }

        /// <summary>
        /// Used to send a message to accompany the command.
        /// </summary>
        /// <returns> The message describing in low detail what the command does. </returns>
        public string Message()
        {
            return string.Empty;
        }
    }
}
