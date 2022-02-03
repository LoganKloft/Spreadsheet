// <copyright file="Distinct.cs" company="Logan Kloft 11728076">
// Copyright (c) Logan Kloft 11728076. All rights reserved.
// </copyright>

namespace HW2_WinForms.HashSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains three different methods for calculating the unique integer values of a list.
    /// </summary>
    public class Distinct
    {
        /// <summary>
        /// Uses a HashSet to determine the distinct values in a list.
        /// </summary>
        /// <param name="list"> Maximum and Minimum Size: 10,000. Upper Bound of Elements: 20,000. Lower Bound of Elements: 0. </param>
        /// <returns> An integer that represents the number of destinct integer values in a list. </returns>
        public static int CalculateDistinctByHashSet(List<int> list)
        {
            // exceptional case
            if (list.Count != 10000)
            {
                throw new System.ArgumentOutOfRangeException("List does not contain 10,000 elements", "list");
            }

            // Stores distinct values from list
            HashSet<int> distinctListValues = new HashSet<int>();

            // add all values to distinctListValues
            foreach (int element in list)
            {
                // exceptional case
                if (element < 0 || element > 20000)
                {
                    throw new System.ArgumentOutOfRangeException("List element found to be outside of range [0, 20,000]", "list");
                }

                distinctListValues.Add(element);
            }

            return distinctListValues.Count;
        }

        /// <summary>
        /// Does not edit list or use auxillary memory in order to calculate the distinct integer elements in list.
        /// </summary>
        /// <param name="list"> Maximum and Minimum Size: 10,000. Upper Bound of Elements: 20,000. Lower Bound of Elements: 0. </param>
        /// <returns> An integer that represents the number of destinct integer values in a list. </returns>
        public static int CalculateDistinctInConstantMemory(List<int> list)
        {
            // exceptional case
            if (list.Count != 10000)
            {
                throw new System.ArgumentOutOfRangeException("List does not contain 10,000 elements", "list");
            }

            int result = 0;

            // calculates the number of distinct values in list
            // will look at all elements from index 0-(i-1), if list[i] doesn't appear
            // in that range, then list[i] is a new distinct element.
            for (int i = 0; i < list.Count; i++)
            {
                int element = list[i];

                // exceptional case
                if (element < 0 || element > 20000)
                {
                    throw new System.ArgumentOutOfRangeException("List element found to be outside of range [0, 20,000]", "list");
                }

                bool isDistinct = true;

                // looking for pre-existing element
                for (int j = i - 1; j >= 0; j--)
                {
                    if (list[j] == element)
                    {
                        isDistinct = false;
                        break;
                    }
                }

                // no pre-existing element matching the new element value was found
                if (isDistinct)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
