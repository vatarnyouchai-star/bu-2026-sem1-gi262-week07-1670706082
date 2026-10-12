
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int LCT01_SequentialSearch1DArray()
        {
            int[] array = { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public int[] LCT02_SequentialSearch2DArray()
        {
            int[,] array =
            {
                { 34, 21, 56 },
                { 12, 78, 90 },
                { 11, 23, 45 }
            };

            int target = 23;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { -1, -1 };
        }

        public int LCT03_BinarySearch()
        {
            int[] array = { 11, 12, 21, 23, 34, 45, 56, 78, 90 };
            int target = 23;

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                {
                    return mid;
                }
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        #endregion

        #region Assignment

        public int[] AS01_FindFirstAndLastElementOfArray(
            int[] array, int target)
        {
            if (array == null || array.Length == 0)
            {
                return new int[] { -1 };
            }

            int first = -1;
            int last = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    if (first == -1)
                    {
                        first = i;
                    }

                    last = i;
                }
            }

            if (first == -1)
            {
                return new int[] { -1 };
            }

            return new int[] { first, last };
        }

        public int AS02_FindMaxLessThan(int[] array, int target)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            int maxValue = 0;
            bool found = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < target)
                {
                    if (!found || array[i] > maxValue)
                    {
                        maxValue = array[i];
                        found = true;
                    }
                }
            }

            if (found)
            {
                return maxValue;
            }

            return -1;
        }

        public int[] AS03_FindRange(int[] array, int min, int max)
        {
            List<int> result = new List<int>();

            if (array == null || min > max)
            {
                return result.ToArray();
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }

        #endregion

        #region Extra

        public int[] EX01_FindTargetEnemies(int[] enemyHPs, int mana)
        {
            List<int> result = new List<int>();

            if (enemyHPs == null || enemyHPs.Length == 0 || mana < 0)
            {
                return result.ToArray();
            }

            int[] sortedHPs = (int[])enemyHPs.Clone();
            Array.Sort(sortedHPs);

            int totalMana = 0;

            for (int i = 0; i < sortedHPs.Length; i++)
            {
                if (sortedHPs[i] < 0)
                {
                    continue;
                }

                if (sortedHPs[i] <= mana - totalMana)
                {
                    totalMana += sortedHPs[i];
                    result.Add(sortedHPs[i]);
                }
                else
                {
                    break;
                }
            }

            return result.ToArray();
        }

        #endregion
    }
}