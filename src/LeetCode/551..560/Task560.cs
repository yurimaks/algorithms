using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode._551._560
{
    public class Task560
    {
        [Theory]
        [InlineData(new[] {1,2,3,0,0,0,2,4,0,0,0,6}, 6, 24)]
        //[InlineData(new[] {1,0,1}, 1, 4)]
        public void Run(int[] input, int k, int expected)
        {
            var actual = SubarraySum(input, k);
            Assert.Equal(expected, actual);
        }

        public int SubarraySum(int[] nums, int k)
        {        
            int count = 0, sum = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                        
                if (map.ContainsKey(sum - k))
                {
                    count += map[(sum - k)];
                }
                
                if (map.ContainsKey(sum))
                {
                    map[sum]++;
                }
                else
                {
                    map.Add(sum, 1);    
                }
            }
            return count;        
        }
        
        public int SubarraySum_v1(int[] nums, int k)
        {        
            int count = 0;
            int[] sum = new int[nums.Length + 1];
            sum[0] = 0;
            for (int i = 1; i<= nums.Length; i++)
            {
                sum[i] = sum[i - 1] + nums[i - 1];
            }
                    
            for (int start = 0; start < nums.Length; start++)
            {
                for (int end = start + 1; end <= nums.Length; end++)
                {
                    if (sum[end] - sum[start] == k) count++;                
                }
            }
        
            return count;        
        }
    }
}