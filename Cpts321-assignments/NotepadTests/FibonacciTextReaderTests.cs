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
        /// Tests the first generated Fibonacci number string.
        /// </summary>
        [Test]
        public void ReadLineTest1()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(5);

            string actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual("1. 0", actual); // First fibonacci number (edge case)
        }

        /// <summary>
        /// Tests to make sure the base case for generating the second fibonacci number works.
        /// </summary>
        [Test]
        public void ReadLineTest2()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(5);
            string actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual("2. 1", actual); // Second fibonacci number (edge case)
        }

        /// <summary>
        /// Tests the last generated fibonacci number.
        /// </summary>
        [Test]
        public void ReadLineTest3()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(5);
            string actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual("5. 3", actual); // Last fibonacci number (edge case)
        }

        /// <summary>
        /// Tests the normal case of a fibonacci that is after the second and before the last.
        /// </summary>
        [Test]
        public void ReadLineTest4()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(5);
            string actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual("3. 1", actual); // Third fibonacci number (normal case)
        }

        /// <summary>
        /// Tests to make sure null is returned after reading all fibonacci numbers.
        /// </summary>
        [Test]
        public void ReadLineTest5()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(5);
            string actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual(null, actual); // No fibonacci numbers left (normal case)
        }

        /// <summary>
        /// Tests to make sure null continues to return after calling ReadLine more than the maximum lines + 1.
        /// </summary>
        [Test]
        public void ReadLineTest6()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(5);
            string actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual(null, actual); // Second call after fibonacci numbers left should still return null (normal case)
        }

        /// <summary>
        /// Tests to make sure null is returned when object is initialized with 0.
        /// </summary>
        [Test]
        public void ReadLineTest7()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(0);
            string actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual(null, actual); // Should return null when constructor has input of 0 (edge case)
        }

        /// <summary>
        /// Tests to make sure null is returned when object is initialized with negative number.
        /// </summary>
        [Test]
        public void ReadLineTest8()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(-4);
            string actual = testFibonacciTextReader.ReadLine();
            Assert.AreEqual(null, actual); // Should return null when constructor has input of negative number (edge case)
        }

        /// <summary>
        /// Tests ReadLine when object is intialized with maximum value, would take too long to run so should make a cutoff value.
        /// </summary>
        [Test]
        public void ReadLineTest9()
        {
            Notepad.FibonacciTextReader testFibonacciTextReader = new Notepad.FibonacciTextReader(2147483647);
            while (testFibonacciTextReader.ReadLine() != null)
            {
            }

            Assert.Pass(); // (exceptional case) - should be handled by maxLine setter.
        }
    }
}