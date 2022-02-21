// <copyright file="SpreadsheetCellTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using NUnit.Framework;

    /// <summary>
    /// Class that contains the tests for the SpreadsheetCell class.
    /// </summary>
    public class SpreadsheetCellTests
    {
        private bool isTextPropertyHandlerTriggered = false;

        /// <summary>
        /// Resets fields required for testing events.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.isTextPropertyHandlerTriggered = false;
        }

        /// <summary>
        /// Tests the RowIndex property.
        /// </summary>
        [Test]
        public void TestRowIndexPropertyNormal()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(0, 0);
            Assert.AreEqual(0, testCell.RowIndex); // normal case
        }

        /// <summary>
        /// Tests the RowIndex property.
        /// </summary>
        [Test]
        public void TestRowIndexPropertyMinimum()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(int.MinValue, int.MinValue);
            Assert.AreEqual(int.MinValue, testCell.RowIndex); // edge case
        }

        /// <summary>
        /// Tests the RowIndex property.
        /// </summary>
        [Test]
        public void TestRowIndexPropertyMaximum()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(int.MaxValue, int.MaxValue);
            Assert.AreEqual(int.MaxValue, testCell.RowIndex); // edge case
        }

        /// <summary>
        /// Tests the ColumnIndex property.
        /// </summary>
        [Test]
        public void TestColumnIndexProperty()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(0, 0);
            Assert.AreEqual(0, testCell.ColumnIndex); // normal case
        }

        /// <summary>
        /// Tests the ColumnIndex property.
        /// </summary>
        [Test]
        public void TestColumnIndexPropertyMinimum()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(int.MinValue, int.MinValue);
            Assert.AreEqual(int.MinValue, testCell.ColumnIndex); // edge case
        }

        /// <summary>
        /// Tests the ColumnIndex property.
        /// </summary>
        [Test]
        public void TestColumnIndexPropertyMaximum()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(int.MaxValue, int.MaxValue);
            Assert.AreEqual(int.MaxValue, testCell.ColumnIndex); // edge case
        }

        /// <summary>
        /// Tests the Text property.
        /// </summary>
        [Test]
        public void TestTextPropertyEvent()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass();
            testCell.PropertyChanged += this.HasTextChanged;
            testCell.TextInterface = "test";
            Assert.IsTrue(this.isTextPropertyHandlerTriggered);
        }

        /// <summary>
        /// Tests the Text property.
        /// </summary>
        [Test]
        public void TestTextProperty()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass();
            testCell.PropertyChanged += this.HasTextChanged;
            testCell.TextInterface = "test";
            Assert.AreEqual("test", testCell.ValueInterface);
        }

        /// <summary>
        /// Used in pair with TestTextProperty to assure the PropertyHandler is triggered.
        /// </summary>
        /// <param name="sender"> Class from which the event was triggered. </param>
        /// <param name="e"> Name of the property that was triggered. </param>
        public void HasTextChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                this.isTextPropertyHandlerTriggered = true;
            }
        }

        /// <summary>
        /// Tests the Value property.
        /// </summary>
        [Test]
        public void TestValuePropertyGetter()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass();
            testCell.TextInterface = "test";
            Assert.AreEqual("test", testCell.ValueInterface); // normal case (default)
        }

        /// <summary>
        /// Allows ability to test abstract class.
        /// </summary>
        internal class SpreadsheetCellTestClass : CptS321.SpreadsheetCell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SpreadsheetCellTestClass"/> class.
            /// </summary>
            public SpreadsheetCellTestClass()
                : base()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SpreadsheetCellTestClass"/> class.
            /// Constructor that allows creation of a SpreadsheetCell with a given rowIndex and columnIndex.
            /// </summary>
            /// <param name="rowIndex"> Initialize field rowIndex with parameter rowIndex. </param>
            /// <param name="columnIndex"> Initialize field columnIndex with paremeter columnIndex. </param>
            public SpreadsheetCellTestClass(int rowIndex, int columnIndex)
                : base(rowIndex, columnIndex)
            {
            }

            /// <summary>
            /// Gets or Sets the protected Text property of SpreadsheetCell for testing purposes.
            /// </summary>
            public string TextInterface
            {
                get { return this.Text; }
                set { this.Text = value; }
            }

            /// <summary>
            /// Gets the protected Text property of SpreadsheetCell for testing purposes.
            /// </summary>
            public string ValueInterface
            {
                get { return this.Value; }
            }
        }
    }
}