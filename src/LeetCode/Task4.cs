using System;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
    /// Follow up: The overall run time complexity should be O(log (m+n)).
    /// </summary>
    public class Task4_FindMedianSortedArrays
    {
        [Theory]
        [InlineData(new[] { 1, 3 }, new [] { 2 }, 2D)]
        [InlineData(new[] { 1, 3, 5, 7 }, new [] { 4 }, 4D)]
        [InlineData(new[] { 1, 3, 8, 9, 15 }, new [] { 7, 11, 19, 21, 25 }, 10D)]
        public void Run(int[] nums1, int[] nums2, double expectedResult)
        {
            var actualResult = FindMedianSortedArrays(nums1, nums2);
            Assert.Equal(expectedResult, actualResult);
        }

        private double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //if input1 length is greater than switch them so that input1 is smaller than in
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }

            int x = nums1.Length;
            int y = nums2.Length;

            int low = 0;
            int high = x;
            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (x + y + 1) / 2 - partitionX;
                
                //if partitionX is 0 it means nothing is there of left side. USE -INF for maxLeftX
                //if partitionX is length of input then there is nothing on right side. Use +INF for minRightX
                int maxLeftX = (partitionX == 0) ? Int32.MinValue : nums1[partitionX - 1];
                int minRightX = (partitionX == x) ? Int32.MaxValue : nums1[partitionX];

                int maxLeftY = (partitionY == 0) ? Int32.MinValue : nums2[partitionY - 1];
                int minRightY = (partitionY == y) ? Int32.MaxValue : nums2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    //We have partitioned array at correct place
                    //Now get max of left elements and min of right elements to get the median in case of even length combined array size
                    //or get max of left for odd length combined array size

                    if ((x + y) % 2 == 0)
                    {
                        return ((double) Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                    }
                    else
                    {
                        return (double) Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY) //we are too far on right side of partitionX. Go on left side.
                {
                    high = partitionX - 1;
                }
                else //We are too far of left side for partitionX. Go on right side
                {
                    low = partitionX + 1;
                }
            }

            //Only we can come here is if input arrays were not sorted. Throw in that scenario.
            throw new ArgumentException();
        }
    }
}