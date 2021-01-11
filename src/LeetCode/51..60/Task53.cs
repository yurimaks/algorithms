using System;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode._51._60
{
    public class Task53
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Task53(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Theory]
        [InlineData(new[] {-2,1,-3,4,-1,2,1,-5,4}, 6)]
        [InlineData(new[] {-5,-2,6,-2,-3,1,5,-6}, 7)]
        [InlineData(new[] {-2}, -2)]
        [InlineData(new[] {-1,-2}, -1)]
        [InlineData(new[] {-1,0,-2}, 0)]
        public void Run(int[] input, int expected_sum)
        {
            var actual = MaxSubArray_Kadane(input);
            Assert.Equal(expected_sum, actual);
        }

        #region DivideAndConquer

        
        public int MaxSubArray_DivideAndConquer(int[] nums)
        {
            if (nums.Length == 0) return 0;
            
            return MaxSubArraySum(nums, 0, nums.Length - 1);
        }

        private int MaxSubArraySum(int[] nums, int l, int r)
        {
            if (l == r) return nums[l];

            int mid = (l + r) / 2;
            /* Return maximum of following three possible cases: 
                a) Maximum subarray sum in left half 
                b) Maximum subarray sum in right half 
                c) Maximum subarray sum such that the  
                subarray crosses the midpoint 
            */
            return Math.Max(Math.Max(
                    MaxSubArraySum(nums, l, mid), 
                    MaxSubArraySum(nums, mid + 1, r)),
                MaxCrossingSum(nums, l, mid, r));
        }

        private int MaxCrossingSum(int[] nums, int left, int mid, int right)
        {
            int sum = 0; 
            int left_sum = int.MinValue; 
            for (int i = mid; i >= left; i--) 
            { 
                sum += nums[i];
                left_sum = Math.Max(left_sum, sum);
            }

            sum = 0;
            int right_sum = Int32.MinValue;
            for (int r = mid + 1; r <= right; r++)
            {
                sum += nums[r];
                right_sum = Math.Max(sum, right_sum);
            }

            return Math.Max(left_sum + right_sum, Math.Max(left_sum, right_sum));
        }
        

        #endregion

        //O(n)
        public int MaxSubArray_Kadane(int[] nums)
        {
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                max_ending_here += nums[i];
                if (max_so_far < max_ending_here)
                {
                    max_so_far = max_ending_here;
                }
            
                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                }
            }
        
            return max_so_far;  
        }
        
        //O^2
        public int MaxSubArray_naive(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int max = nums[0];
            for (int i=0; i <= nums.Length - 1; i++)
            {
                int totalSum = nums[i];
                max = Math.Max(totalSum, max);
                for (int j = i + 1; j < nums.Length; j++)
                {
                    totalSum += nums[j];
                    max = Math.Max(totalSum, max);
                }
            }

            return max;
        }
    }
}