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
        private Stack<CptS321.CommandCollection> redoStack = new Stack<CptS321.CommandCollection>();
        private Stack<CptS321.CommandCollection> undoStack = new Stack<CptS321.CommandCollection>();

        /// <summary>
        /// Event that gets raised when either redoStack or undoStack or changed.
        /// </summary>
        public event EventHandler UndoRedoStackChanged = (sender, e) => { };

        /// <summary>
        /// Adds a list of commands that can be undone by calling CommandInvoker.Undo().
        /// </summary>
        /// <param name="commandList"> A list of one or more commands to be executed or unexecuted. </param>
        /// <param name="message"> The message describing the overal action of the list of commands. </param>
        public void AddUndo(List<CptS321.ICommand> commandList, string message)
        {
            CptS321.CommandCollection commandCollection = new CptS321.CommandCollection(commandList, message);
            this.AddUndo(commandCollection);
        }

        /// <summary>
        /// Adds a commandCollection to the undoStack.
        /// </summary>
        /// <param name="commandCollection"> A collection of a list of commands and a message describing the action of the commands. </param>
        public void AddUndo(CptS321.CommandCollection commandCollection)
        {
            this.undoStack.Push(commandCollection);
            this.redoStack.Clear();
            this.UndoRedoStackChanged(this, new EventArgs());
        }

        /// <summary>
        /// Pops the commandList at the top of the undo stack.
        /// Unexecutes the popped commandList and pushes it to the redoStack.
        /// </summary>
        public void Undo()
        {
            CptS321.CommandCollection commandCollection = this.undoStack.Pop();
            foreach (ICommand command in commandCollection.CommandList)
            {
                command.Unexecute();
            }

            this.redoStack.Push(commandCollection);
            this.UndoRedoStackChanged(this, new EventArgs());
        }

        /// <summary>
        /// Returns true if undoStack is not empty, false otherwise.
        /// </summary>
        /// <returns> A boolean value that means whether there are any commands left to undo. </returns>
        public bool CanUndo()
        {
            return this.undoStack.Count > 0;
        }

        /// <summary>
        /// Returns the message of the top Command on the undo stack, otherwise returns "Undo".
        /// </summary>
        /// <returns> The message of the top undo command. </returns>
        public string UndoText()
        {
            if (this.undoStack.Count > 0)
            {
                return "Undo " + this.undoStack.Peek().Message;
            }

            return "Undo";
        }

        /// <summary>
        /// Returns true if redoStack is not empty, false otherwise.
        /// </summary>
        /// <returns> A boolean value that means whether there are any commands left to redo. </returns>
        public bool CanRedo()
        {
            return this.redoStack.Count > 0;
        }

        /// <summary>
        /// Pops the command at the top of the redo stack.
        /// Executes the popped comman and pushes it to the undoStack.
        /// </summary>
        public void Redo()
        {
            CptS321.CommandCollection commandCollection = this.redoStack.Pop();
            foreach (ICommand command in commandCollection.CommandList)
            {
                command.Execute();
            }

            this.undoStack.Push(commandCollection);
            this.UndoRedoStackChanged(this, new EventArgs());
        }

        /// <summary>
        /// Returns the message of the top Command on the redo stack, otherwise returns "Redo".
        /// </summary>
        /// <returns> The message of the top redo command. </returns>
        public string RedoText()
        {
            if (this.redoStack.Count > 0)
            {
                return "Redo " + this.redoStack.Peek().Message;
            }

            return "Redo";
        }

        /// <summary>
        /// Empty the undo Stack. Called in the Load event handler.
        /// </summary>
        public void ClearUndoStack()
        {
            this.undoStack.Clear();
            this.UndoRedoStackChanged(this, new EventArgs());
        }

        /// <summary>
        /// Empty the redo stack. Called in the Load event handler.
        /// </summary>
        public void ClearRedoStack()
        {
            this.redoStack.Clear();
            this.UndoRedoStackChanged(this, new EventArgs());
        }
    }
}
