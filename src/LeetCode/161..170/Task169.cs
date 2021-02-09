using System;
using Xunit;
namespace LeetCode._161._170
{
    public class Task169
    {
        [Theory]
        [InlineData(new int[]{1,2,1}, 1)]
        [InlineData(new int[]{1,2,2,2}, 2)]
        [InlineData(new int[]{1}, 1)]
        public void Run(int[] numbers, int expected)
        {
            var actual = MajorityElement(numbers);
             Assert.Equal(expected, actual);
        }

        public int MajorityElement(int[] nums)
        {
            //n(logn)
            Array.Sort(nums);
        
            int length = nums.Length;
            int count = 1;
            int temp = nums[0];
            for (int i = 1; i < length; i++)
            {
                if (temp == nums[i])
                {
                    count++;
                }
                else
                {
                    count = 1;
                    temp = nums[i];
                }
            
                if (count > length / 2)
                {
                    return nums[i];
                }
            
            }
        
            return temp;
        }
    }
}