// <copyright file="CommandCollection.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Stores a collection of commands and a message describing their action.
    /// </summary>
    public class CommandCollection
    {
        private List<CptS321.ICommand> commandList;
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCollection"/> class.
        /// </summary>
        /// <param name="commandList"> List of commands. </param>
        /// <param name="message"> Message describing overall action of the list of commands. </param>
        public CommandCollection(List<CptS321.ICommand> commandList, string message)
        {
            this.commandList = commandList;
            this.message = message;
        }

        /// <summary>
        /// Gets the commandList.
        /// </summary>
        public List<CptS321.ICommand> CommandList
        {
            get
            {
                return this.commandList;
            }
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
