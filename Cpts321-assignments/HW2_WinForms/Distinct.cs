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
            if (list.Count != 10000)
            {
                throw new System.ArgumentOutOfRangeException("List does not contain 10,000 elements", "list");
            }

            HashSet<int> distinctListValues = new HashSet<int>();
            foreach (int element in list)
            {
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
            return 0;
        }
    }
}
