using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// You can return the answer in any order.
    /// </summary>
    public class Task1_TwoSum
    {
        [Theory]
        [InlineData(new[] { 15, 11, 5, 4 }, 26, new[] { 0, 1 })]
        public void Run(int[] nums, int target, int[] expectedResult)
        {
            var actualResult = TwoSum_v2(nums, target);
            Assert.Equal(expectedResult, actualResult);
        }
        
        //Brute force
        //My first attempt.
        private static int[] TwoSum_v1(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    var sum = nums[i] + nums[j];
                    if (sum == target) return new[] {i, j};
                }
            }

            return null;
        }

        //using HashMap
        private static int[] TwoSum_v2(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (dict.ContainsKey(diff))
                {
                    return new[] {dict[diff], i};
                }

                dict.Add(nums[i], i);
            }

            return new int[0];
        }
    }
}