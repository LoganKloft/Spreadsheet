// <copyright file="DistinctTests.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace HW2_WinForms.HashSet.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Class for testing the three implementations of calculating the number of distinct.
    /// </summary>
    public class DistinctTests
    {
        /// <summary>
        /// Contains the tests for the first implementation of calculating the distinct elements of a list.
        /// </summary>
        [Test]
        public void TestCalculateDistinctByHashSet()
        {
            // Tests based off: https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
            // Arrange
            List<int> testList = new List<int>();
            for (int i = 1; i <= 10000; i++)
            {
                testList.Add(i);
            }

            // Act
            int actual = Distinct.CalculateDistinctByHashSet(testList);

            // Assert
            Assert.AreEqual(10000, actual); // No duplicate values in list (normal case)

            testList.Clear();
            for (int i = 1; i <= 5000; i++)
            {
                testList.Add(i);
            }

            for (int i = 5000; i >= 1; i--)
            {
                testList.Add(i);
            }

            actual = Distinct.CalculateDistinctByHashSet(testList);

            // Duplicate values in list (normal case)
            Assert.AreEqual(5000, actual);

            testList.Clear();
            for (int i = 1; i <= 10000; i++)
            {
                testList.Add(0);
            }

            actual = Distinct.CalculateDistinctByHashSet(testList);

            // All values are 0's - minimum operating parameter (edge/boundary case)
            Assert.AreEqual(1, actual);

            testList.Clear();
            for (int i = 1; i <= 10000; i++)
            {
                testList.Add(20000);
            }

            actual = Distinct.CalculateDistinctByHashSet(testList);

            // All values are 20,000's - maximum operating parameter (edge/boundary case)
            Assert.AreEqual(1, actual);

            testList.Clear();
            for (int i = 2; i <= 10001; i++)
            {
                testList.Add(2 * i);
            }

            // Action - can be called later https://docs.microsoft.com/en-us/dotnet/api/system.action?view=net-6.0
            // System.Action a = () => HashSet.Distinct(testList); // from link on line 56, creates parameterless lambda,
                                                                   // System.Action needs a parameterless function, ignores return type
            // Did not work out - still using a lamda with no parameters though

            // integer above 20,000 in list (exceptional/overflow case)
            Assert.Throws<System.ArgumentOutOfRangeException>(() => Distinct.CalculateDistinctByHashSet(testList)); // from class example

            testList.Clear();
            for (int i = 5000; i >= -4999; i--)
            {
                testList.Add(i);
            }

            // integer below 0 in list (exceptional/overflow case)
            Assert.Throws<System.ArgumentOutOfRangeException>(() => Distinct.CalculateDistinctByHashSet(testList));

            testList.Clear();
            for (int i = 1; i <= 5000; i++)
            {
                testList.Add(i);
            }

            // list is shorter than 10,000 elements (exceptional/overflow case)
            Assert.Throws<System.ArgumentOutOfRangeException>(() => Distinct.CalculateDistinctByHashSet(testList));

            testList.Clear();
            for (int i = 1; i <= 10001; i++)
            {
                testList.Add(i);
            }

            // list is longer than 10,000 elements (exceptional/overflow case)
            Assert.Throws<System.ArgumentOutOfRangeException>(() => Distinct.CalculateDistinctByHashSet(testList));

            // ArgumentExceptions https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception?view=net-6.0
        }
    }
}