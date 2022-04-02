// <copyright file="ICommand.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Defines the basic behavior of any command in the Command Design Pattern.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The logic of the action of the command.
        /// </summary>
        void Execute();

        /// <summary>
        /// The logic for undoing the action of the command.
        /// </summary>
        void Unexecute();
    }
}
