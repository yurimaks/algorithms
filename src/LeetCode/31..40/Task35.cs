using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public class Task35
    {
        [Theory]
        [InlineData(new[] {0,1,2,3,4,5}, 6, 6)]
        [InlineData(new[] {0,1,2,3,4}, 5, 5)]
        [InlineData(new[] {0,2,3,4}, 1, 1)]
        [InlineData(new[] {2,3,4}, 0, 0)]
        [InlineData(new[] {1,3,5,6}, 5, 2)]
        [InlineData(new[] {1,3,6}, 5, 2)]
        [InlineData(new[] {1}, 2, 1)]
        [InlineData(new[] {1}, 1, 0)]
        public void Run(int[]nums, int val, int expected)
        {
            var actual = SearchInsert_Binary(nums, val);
            Assert.Equal(expected, actual);
        }

        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0) return 0;

            int i = 0;
            while(i < nums.Length)
            {
                if (nums[i] == target || nums[i] > target) return i;
                
                i++;
            }
        
            return i;
        }

        public int SearchInsert_Binary(int[] nums, int target)
        {
            int ans = 0, l = 0, r = nums.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == target) return mid;
                if (nums[mid] < target)
                {
                    ans = mid;
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }

            if (nums[ans] >= target) return ans;

            return ans + 1;
        }
    }
}