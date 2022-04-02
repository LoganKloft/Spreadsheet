// <copyright file="CommandInvoker.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Responsible for redoing and undoing commands.
    /// </summary>
    public class CommandInvoker
    {
        private Stack<CptS321.ICommand> redoStack;
        private Stack<CptS321.ICommand> undoStack;

        /// <summary>
        /// Adds a command that can be undone by calling CommandInvoker.Undo().
        /// </summary>
        /// <param name="undoCommand"> The command that was just executed. </param>
        public void AddUndo(CptS321.ICommand undoCommand)
        {
        }

        /// <summary>
        /// Pops the command at the top of the undo stack.
        /// Unexecutes the popped command and pushes it to the redoStack.
        /// </summary>
        public void Undo()
        {
        }

        /// <summary>
        /// Returns true if undoStack is not empty, false otherwise.
        /// </summary>
        /// <returns> A boolean value that means whether there are any commands left to undo. </returns>
        public bool CanUndo()
        {
            return false;
        }

        /// <summary>
        /// Returns true if redoStack is not empty, false otherwise.
        /// </summary>
        /// <returns> A boolean value that means whether there are any commands left to redo. </returns>
        public bool CanRedo()
        {
            return false;
        }

        /// <summary>
        /// Pops the command at the top of the redo stack.
        /// Executes the popped comman and pushes it to the undoStack.
        /// </summary>
        public void Redo()
        {
        }
    }
}
