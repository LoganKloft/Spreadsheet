// <copyright file="Form1.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace Spreadsheet_Logan_Kloft
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The main form of the Spreadsheet application.
    /// </summary>
    public partial class Form1 : Form
    {
        private CptS321.Spreadsheet spreadsheet;
        private CptS321.CommandInvoker commandInvoker = new CptS321.CommandInvoker();
        private CptS321.Workbook workbook = new CptS321.Workbook();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

            // remove already existing columns
            this.dataGridView1.Columns.Clear();

            // remove already existing rows
            this.dataGridView1.Rows.Clear();

            // subscribe to the CellBeginEdit event
            this.dataGridView1.CellBeginEdit += this.CellBeginEditHandler;

            // subscribe to the CellEndEdit event
            this.dataGridView1.CellEndEdit += this.CellEndEditHandler;

            // subscribe to UndoRedoStackChanged event
            this.commandInvoker.UndoRedoStackChanged += this.UndoRedoVisibilityHandler;

            // add columns from A-Z
            for (char columnName = 'A'; columnName <= 'Z'; columnName++)
            {
                this.dataGridView1.Columns.Add(columnName.ToString(), columnName.ToString());
            }

            // add rows from 1-50
            this.dataGridView1.Rows.Add(49);
            int rowNumber = 1;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.HeaderCell.Value = rowNumber.ToString();
                rowNumber++;
            }

            this.spreadsheet = new CptS321.Spreadsheet(50, 26);
            this.spreadsheet.CellPropertyChanged += this.UpdateDataGridView;
        }

        /// <summary>
        /// Event handler when cell is being edited.
        /// </summary>
        /// <param name="sender"> The object sending the event. dataGridView1. </param>
        /// <param name="e"> The parameters included in the event. </param>
        public void CellBeginEditHandler(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            CptS321.SpreadsheetCell cell = this.spreadsheet.GetCell(row + 1, col + 1);
            this.dataGridView1[col, row].Value = cell.Text;
        }

        /// <summary>
        /// Event handler when cell is not being edited anymore.
        /// </summary>
        /// <param name="sender"> The object sending the event. dataGridView1. </param>
        /// <param name="e"> The parameters included in the event. </param>
        public void CellEndEditHandler(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            CptS321.SpreadsheetCell cell = this.spreadsheet.GetCell(row + 1, col + 1);

            string currentText = cell.Text;
            string newText = string.Empty;

            if (this.dataGridView1[col, row].Value != null)
            {
                newText = this.dataGridView1[col, row].Value.ToString();
            }

            CptS321.SpreadsheetCellTextCommand textCommand = new CptS321.SpreadsheetCellTextCommand(
                cell,
                currentText,
                newText,
                "text change");
            if (currentText != newText)
            {
                List<CptS321.ICommand> commandList = new List<CptS321.ICommand>();
                commandList.Add(textCommand);
                this.commandInvoker.AddUndo(commandList, "text change");
            }

            if (this.dataGridView1[col, row].Value == null)
            {
                cell.Text = string.Empty;
            }
            else
            {
                cell.Text = this.dataGridView1[col, row].Value.ToString();
                this.dataGridView1[col, row].Value = cell.Value; // if no change to text, go back to displaying value
            }
        }

        /// <summary>
        /// Updates the Text property of a cell in DataGridView when a Value changes in a spreadsheet cell.
        /// </summary>
        /// <param name="sender"> The cell that was changed. </param>
        /// <param name="e"> Has no meaning. </param>
        public void UpdateDataGridView(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CptS321.SpreadsheetCell changedCell = (CptS321.SpreadsheetCell)sender;
            if (e.PropertyName == "Value")
            {
                this.dataGridView1[changedCell.ColumnIndex - 1, changedCell.RowIndex - 1].Value = changedCell.Value;
            }

            if (e.PropertyName == "BGColor")
            {
                this.dataGridView1[changedCell.ColumnIndex - 1, changedCell.RowIndex - 1].Style.BackColor = Color.FromArgb((int)changedCell.BGColor);
            }
        }

        /// <summary>
        /// Runs the demo for step 7.
        /// </summary>
        /// <param name="sender"> Button. </param>
        /// <param name="e"> Has no meaning. </param>
        public void Demo(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                int column = rand.Next(1, 26);
                int row = rand.Next(1, 50);
                this.spreadsheet.GetCell(row, column).Text = "Hello World!";
            }

            // Set the text in every cell in column B to "This is cell B#"
            for (int i = 1; i <= 50; i++)
            {
                this.spreadsheet.GetCell(i, 2).Text = "This is cell B" + i.ToString();
            }

            // Set the text in every cell in column A to "=B#"
            for (int i = 1; i <= 50; i++)
            {
                this.spreadsheet.GetCell(i, 1).Text = "=B" + i.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Event handler for changing the background color of selected cells.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event parameters. </param>
        private void ChangeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    List<CptS321.ICommand> commandList = new List<CptS321.ICommand>();
                    foreach (DataGridViewCell selectedCell in this.dataGridView1.SelectedCells)
                    {
                        int row = selectedCell.RowIndex;
                        int col = selectedCell.ColumnIndex;
                        CptS321.SpreadsheetCell cell = this.spreadsheet.GetCell(row + 1, col + 1);

                        uint currentBGColor = cell.BGColor;
                        uint newBGColor = (uint)colorDialog.Color.ToArgb();

                        CptS321.SpreadsheetCellBGColorCommand bgcolorCommand = new CptS321.SpreadsheetCellBGColorCommand(
                            cell,
                            currentBGColor,
                            newBGColor,
                            "background color change");
                        commandList.Add(bgcolorCommand);

                        cell.BGColor = (uint)colorDialog.Color.ToArgb();
                    }

                    this.commandInvoker.AddUndo(commandList, "background color change");
                }
            }
        }

        /// <summary>
        /// Event handler for when the Undo menu item is clicked within the Edit menu.
        /// </summary>
        /// <param name="sender"> The Undo menu item. </param>
        /// <param name="e"> The parameters of the event. </param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.commandInvoker.Undo();
        }

        /// <summary>
        /// Event handler for when the Redo menu item is clicked within the Edit menu.
        /// </summary>
        /// <param name="sender"> The Redo menu item. </param>
        /// <param name="e"> The parameters of the event. </param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.commandInvoker.Redo();
        }

        /// <summary>
        /// Handles the enability of the Undo and Redo menu strip items. Triggered whenever Redo or Undo is called in CommandInvoker.
        /// </summary>
        /// <param name="sender"> The instance of the CommandInvoker that had its method called. </param>
        /// <param name="e"> The event parameters. </param>
        private void UndoRedoVisibilityHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem edit = this.menuStrip1.Items["Edit"] as ToolStripMenuItem;
            ToolStripItem undoMenuItem = edit.DropDownItems["Undo"];
            ToolStripItem redoMenuItem = edit.DropDownItems["Redo"];

            if (this.commandInvoker.CanUndo())
            {
                // enable the enability of the Undo menu strip item.
                undoMenuItem.Enabled = true;
            }
            else
            {
                // disable the enability of the Undo menu strip item.
                undoMenuItem.Enabled = false;
            }

            if (this.commandInvoker.CanRedo())
            {
                // enable the enability of the Redo menu strip item.
                redoMenuItem.Enabled = true;
            }
            else
            {
                // disable the enability of the Redo menu strip item.
                redoMenuItem.Enabled = false;
            }

            undoMenuItem.Text = this.commandInvoker.UndoText();
            redoMenuItem.Text = this.commandInvoker.RedoText();
        }

        /// <summary>
        /// Saves the current spreadsheet.
        /// </summary>
        /// <param name="sender"> The ToolStripItem that invoked this event. </param>
        /// <param name="e"> The event parameters. </param>
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML-File | *.xml";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != string.Empty)
            {
                System.IO.Stream stream = saveFileDialog.OpenFile();
                this.workbook.Save(stream, this.spreadsheet);
                stream.Close();
            }
        }

        /// <summary>
        /// Loads an xml file.
        /// </summary>
        /// <param name="sender"> The TollStripItem that invoked this event. </param>
        /// <param name="e"> The event parameters. </param>
        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML-File | *.xml";
            openFileDialog.ShowDialog();
            this.spreadsheet.ResetToDefault();
            this.commandInvoker.ClearRedoStack();
            this.commandInvoker.ClearUndoStack();

            if (openFileDialog.FileName != string.Empty)
            {
                System.IO.Stream stream = openFileDialog.OpenFile();
                this.workbook.Load(stream, this.spreadsheet);
                stream.Close();
            }
        }
    }
}
