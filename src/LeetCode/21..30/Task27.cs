using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public class Task27
    {
        [Theory]
        [InlineData(new[] {0,1,2,2,3,0,4,2}, 2, 5)]
        [InlineData(new[] {3,2,2,3}, 2, 2)]
        [InlineData(new[] {3,2,2,3}, 3, 2)]
        [InlineData(new[] {0,1,2,3,4,5,6,7,8,9,10}, 12, 11)]
        [InlineData(new int[0], 12, 0)]
        [InlineData(new[] {0,1,2,3,4,5,6,7,8,9,10}, 10, 10)]
        [InlineData(new[] {0,1,2,3,4,5,6,7,8,9,10}, 0, 10)]
        [InlineData(new[] {3,3,3,3,3,2}, 3, 1)]
        [InlineData(new[] {3}, 3, 0)]
        [InlineData(new[] {1,0,0,0,0,1}, 0, 2)]
        [InlineData(new[] {1,0,0,0,0,1}, 1, 4)]
        public void Run(int[]nums, int val, int expected)
        {
            var actual = RemoveElement(nums, val);
            Assert.Equal(expected, actual);
        }

        public int RemoveElement(int[] nums, int val)
        {
            int i = 0, j = 0;
            while (j < nums.Length)
            {
                /*
                 224 ms	30.7 MB
if (nums[j] == val)
{
    nums[i] = nums[j];
}
else
{
    nums[i] = nums[j];
    
    i++;
}
j++; 
                 */
                
                //228 ms	30.8 MB
                nums[i] = nums[j];
                if (nums[j] != val) i++;
                j++;
            }

            return i;
        }
    }
}