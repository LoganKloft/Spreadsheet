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
        private bool isBGColorPropertyHandlerTriggered = false;

        /// <summary>
        /// Resets fields required for testing events.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.isTextPropertyHandlerTriggered = false;
            this.isBGColorPropertyHandlerTriggered = false;
        }

        /// <summary>
        /// Test that the property changed event in a SpreadsheetCell triggers when the BGColor is changed.
        /// </summary>
        [Test]
        public void TestBGColorPropertySetToDifferent()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(); // normal case
            testCell.PropertyChanged += this.HasBGColorChanged;
            testCell.BGColor = 0xFFFF0000;
            Assert.True(this.isBGColorPropertyHandlerTriggered);
        }

        /// <summary>
        /// Test that the property changed event in a SpreadsheetCell does not trigger if setting the same value.
        /// </summary>
        [Test]
        public void TestBGColorPropertySetToSame()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(); // edge case
            testCell.PropertyChanged += this.HasBGColorChanged;
            testCell.BGColor = 0xFFFFFFFF;
            Assert.False(this.isBGColorPropertyHandlerTriggered);
        }

        /// <summary>
        /// Turn local variable isBGColorPropertyHandlerTriggered to true if BGColor changed in a subscribed to SpreadsheetCell.
        /// </summary>
        /// <param name="sender"> The cell. </param>
        /// <param name="e"> The name of the changed property. </param>
        public void HasBGColorChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "BGColor")
            {
                this.isBGColorPropertyHandlerTriggered = true;
            }
        }

        /// <summary>
        /// Tests the default value of the background to be white.
        /// </summary>
        [Test]
        public void TestBGColorPropertyDefault()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(); // normal case
            Assert.AreEqual(0xFFFFFFFF, testCell.BGColor);
        }

        /// <summary>
        /// Tests setting BGColor a valid value.
        /// </summary>
        [Test]
        public void TestBGColorPropertyNormal()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(); // normal case
            testCell.BGColor = 0xFFFF0000;
            Assert.AreEqual(0xFFFF0000, testCell.BGColor);
        }

        /// <summary>
        /// Tests the lower boundary of the range of BGColor.
        /// </summary>
        [Test]
        public void TestBGColorPropertyLowerEdge()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(); // edge case
            testCell.BGColor = 0x00000000;
            Assert.AreEqual(0x00000000, testCell.BGColor);
        }

        /// <summary>
        /// Tests the upper boundary of the range of BGColor.
        /// </summary>
        [Test]
        public void TestBGColorPropertyUpperEdge()
        {
            SpreadsheetCellTestClass testCell = new SpreadsheetCellTestClass(); // edge case
            testCell.BGColor = 0xFFFFFFFF;
            Assert.AreEqual(0xFFFFFFFF, testCell.BGColor);
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
            testCell.Text = "test";
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
            testCell.Text = "test";
            Assert.AreEqual("test", testCell.Value);
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
            testCell.Text = "test";
            Assert.AreEqual("test", testCell.Value); // normal case (default)
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
        }
    }
}