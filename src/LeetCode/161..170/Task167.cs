using System.Collections.Generic;
using Althorithms;
using Xunit;
namespace LeetCode._161._170
{
    public class Task167
    {
        [Theory]
        [InlineData(new int[5]{1,2,3,4,5}, 4, new[]{1,3})]
        [InlineData(new int[2]{1,2}, 3, new[]{1,2})]
        [InlineData(new int[]{3,24,50,79,88,150,345}, 200, new[]{3,6})]
        [InlineData(new int[]{1,2,3,4,4,9,56,90}, 8, new[]{4,5})]
        [InlineData(new int[]{12,13,23,28,43,44,59,60,61,68,70,86,88,92,124,125,136,168,173,173,180,199,212,221,227,230,277,282,306,314,316,321,325,328,336,337,363,365,368,370,370,371,375,384,387,394,400,404,414,422,422,427,430,435,457,493,506,527,531,538,541,546,568,583,585,587,650,652,677,691,730,737,740,751,755,764,778,783,785,789,794,803,809,815,847,858,863,863,874,887,896,916,920,926,927,930,933,957,981,997}, 542, new[]{24,32})]
        public void Run(int[] numbers, int target, int[] expected)
        {
            var actual = TwoSum_v3_SlowFastPointers(numbers, target);
             Assert.Equal(expected, actual);
        }

        public int[] TwoSum_v4_BruteForce(int[] numbers, int target)
        {
            for (int i=0; i< numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] > target) break;
                    if (numbers[i] + numbers[j] == target) return new int[]{i + 1, j + 1};
                }
            }
        
            return new int[2]; 
        }

        public int[] TwoSum_v3_SlowFastPointers(int[] numbers, int target)
        {
            int slow = 0, fast = 1, length = numbers.Length;
        
            while (slow < length)
            {
                if (fast >= length) 
                {
                    slow++;
                    fast = slow + 1;
                }
		
                if (numbers[slow] + numbers[fast] == target) 
                {
                    break;
                }
                if (numbers[slow] + numbers[fast] > target)
                {
                    slow++;   
                    fast = slow;
                }
        
                fast++;
            
            }
               
            return new int[]{slow + 1, fast + 1};   
        }

        public int[] TwoSum_v2_HashTable(int[] numbers, int target)
        {
            var dict = new Dictionary<int, int>();
        
            for (int i=0; i< numbers.Length; i++)
            {
                var diff = target - numbers[i];
            
                if (dict.ContainsKey(diff))
                {
                    return new int[2]{dict[diff] + 1, i + 1};
                }
            
                dict.Add(numbers[i], i);
            }
        
            return new int[2];        
        }
        
        public int[] TwoSum_v1_BS(int[] numbers, int target)
        {
            for (int i=0; i< numbers.Length; i++)
            {
                var diff = target - numbers[i];
            
                int? value = numbers.FindIndexBS(i + 1, numbers.Length -1, diff);
                if (value.HasValue)
                {
                    return new[]{i + 1, value.Value + 1};
                }
                
            }
        
            return new int[2];        
        }
    }
}