// <copyright file="WorkbookTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace SpreadsheetEngineTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the Workbook tests.
    /// Using defensive programming versus throwing exceptions.
    /// </summary>
    public class WorkbookTests
    {
        /// <summary>
        /// Test saving a null spreadsheet.
        /// </summary>
        [Test]
        public void TestSaveEmptySpreadsheet()
        {
            CptS321.Spreadsheet testSpreadsheet = null;
            CptS321.Workbook testWorkbook = new CptS321.Workbook();
            bool result = false;
            using (System.IO.Stream stream = new System.IO.FileStream("OutputTestFile.xml", System.IO.FileMode.Open))
            {
                result = testWorkbook.Save(stream, testSpreadsheet);
            }

            Assert.False(result);
        }

        /// <summary>
        /// Tests saving when the stream parameter is null.
        /// </summary>
        [Test]
        public void TestSaveNullStream()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(2, 2);
            CptS321.Workbook testWorkbook = new CptS321.Workbook();
            bool result = false;
            System.IO.Stream stream = null;
            result = testWorkbook.Save(stream, testSpreadsheet);
            Assert.False(result);
        }

        /// <summary>
        /// Test saving an unedited spreadsheet.
        /// </summary>
        [Test]
        public void TestSaveUneditedSpreadsheet()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(1, 1);
            CptS321.Workbook testWorkbook = new CptS321.Workbook();
            bool result = false;
            using (System.IO.Stream stream = new System.IO.FileStream("OutputTestFile.xml", System.IO.FileMode.Open))
            {
                result = testWorkbook.Save(stream, testSpreadsheet);
            }

            Assert.True(result);
        }

        /// <summary>
        /// Test saving an edited spreadsheet.
        /// </summary>
        [Test]
        public void TestSaveEditedSpreadsheet()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(1, 1);
            testSpreadsheet.GetCell(1, 1).Text = "test";
            CptS321.Workbook testWorkbook = new CptS321.Workbook();
            bool result = false;
            using (System.IO.Stream stream = new System.IO.FileStream("OutputTestFile.xml", System.IO.FileMode.Open))
            {
                result = testWorkbook.Save(stream, testSpreadsheet);
            }

            Assert.True(result);
        }

        /// <summary>
        /// Tests load when the stream parameter is null.
        /// </summary>
        [Test]
        public void TestLoadNullStream()
        {
            CptS321.Spreadsheet testSpreadsheet = null;
            CptS321.Workbook testWorkbook = new CptS321.Workbook();
            bool result = false;
            using (System.IO.Stream stream = new System.IO.FileStream("OutputTestFile.xml", System.IO.FileMode.Open))
            {
                result = testWorkbook.Load(stream, testSpreadsheet);
            }

            Assert.False(result);
        }

        /// <summary>
        /// Test loading a file with only a root element spreadsheet.
        /// </summary>
        [Test]
        public void TestLoadFileNoCells()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(5, 5);
            CptS321.Workbook testWorkbook = new CptS321.Workbook();
            bool result = false;
            using (System.IO.Stream stream = new System.IO.FileStream("NoCells.xml", System.IO.FileMode.Open))
            {
                result = testWorkbook.Load(stream, testSpreadsheet);
            }

            Assert.True(result);
        }

        /// <summary>
        /// An ideal file is one that has only the root element spreadsheet, and nested elements cell, bgcolor, and text.
        /// </summary>
        [Test]
        public void TestLoadIdealFile()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(5, 5);
            CptS321.Workbook testWorkbook = new CptS321.Workbook();
            bool result = false;
            using (System.IO.Stream stream = new System.IO.FileStream("Ideal.xml", System.IO.FileMode.Open))
            {
                result = testWorkbook.Load(stream, testSpreadsheet);
            }

            Assert.True(result);
        }

        /// <summary>
        /// Test loading a file with ideal elements and also non-ideal elements which could be named anything allowed by xml.
        /// </summary>
        [Test]
        public void TestLoadNoisyFile()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(5, 5);
            CptS321.Workbook testWorkbook = new CptS321.Workbook();
            bool result = false;
            using (System.IO.Stream stream = new System.IO.FileStream("Noisy.xml", System.IO.FileMode.Open))
            {
                result = testWorkbook.Load(stream, testSpreadsheet);
            }

            Assert.True(result);
        }

        /// <summary>
        /// Test Load when spreadsheet parameter is null.
        /// </summary>
        [Test]
        public void TestLoadWithNullSpreadsheet()
        {
            CptS321.Spreadsheet testSpreadsheet = new CptS321.Spreadsheet(1, 1);
            CptS321.Workbook testWorkbook = new CptS321.Workbook();
            bool result = false;
            System.IO.Stream stream = null;
            result = testWorkbook.Load(stream, testSpreadsheet);
            Assert.False(result);
        }
    }
}
