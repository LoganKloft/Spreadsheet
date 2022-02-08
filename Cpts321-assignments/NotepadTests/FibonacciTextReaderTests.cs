// <copyright file="FibonacciTextReaderTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace NotepadTests
{
    using NUnit.Framework;

    /// <summary>
    /// Class that will test the constructor and ReadLine() method of the FibonacciTextReader class.
    /// </summary>
    public class FibonacciTextReaderTests
    {
        /// <summary>
        /// Tests the ReadLine() method of the FibonacciTextReader class.
        /// </summary>
        [Test]
        public void ReadLineTest()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(5);

            string actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual("0", actual); // First fibonacci number (edge case)

            actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual("1", actual); // Second fibonacci number (edge case)

            actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual("1", actual); // Third fibonacci number (normal case)

            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual("3", actual); // Last fibonacci number (edge case)

            actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual(null, actual); // No fibonacci numbers left (normal case)
        }
    }
}