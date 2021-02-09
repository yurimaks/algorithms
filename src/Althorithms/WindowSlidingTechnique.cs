using System;
using System.Collections.Generic;
using Xunit;

namespace Althorithms
{
    //https://www.geeksforgeeks.org/window-sliding-technique/
    public class WindowSlidingTechnique
    {
        [Theory]
        [InlineData(new int[]{100, 200, 300, 400}, 2, 700)]
        [InlineData(new int[]{1, 4, 2, 10, 23, 3, 1, 0, 20}, 4, 39)]
        public void Run(int[] array, int k, int expected)
        {
            var actual = MaxSumOfConsecutiveNumbers(array, k);
            Assert.Equal(expected, actual);
        }

        private int MaxSumOfConsecutiveNumbers(int[] array, int k)
        {

            int totalSum = int.MinValue;
            int currentSum = 0;

            //sum of first k elements
            for (int i = 0; i < k; i++)
            {
                currentSum += array[i];
            }

            for (int i = k; i < array.Length; i++)
            {
                currentSum += array[i] - array[i - k];
                totalSum = Math.Max(totalSum, currentSum); 
            }

            return totalSum;
        }
        
        private List<int[]> SpitArrayOnPairs(int[] array, int k)
        {
            var list = new List<int[]>();
            for (int i = 0; i < array.Length; i = i + k)
            {
                int[] pair = new int[k];

                for (int j = 0; j < k; j++)
                {
                    if (i + j > array.Length - 1) break;
                    pair[j] = array[i + j];
                }
                list.Add(pair);
            }

            return list;
        }
        
    }
}