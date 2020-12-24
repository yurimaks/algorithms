using System;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Given a 32-bit signed integer, reverse digits of an integer.
    /// Note:
    /// Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: [−231,  231 − 1].
    /// For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
    /// </summary>
    public class Task7_Reverse_Integer
    {
        [Theory]
        [InlineData(123, 321)]
        [InlineData(120, 21)]
        [InlineData(0, 0)]
        [InlineData(9, 9)]
        [InlineData(1002, 2001)]
        [InlineData(1534236469, 0)]
        public void Run(int value, int expected)
        {
            var actual = Reverse(value);
            Assert.Equal(expected, actual);
        }
        
        public int Reverse(int input)
        {
            long reversedNum = 0;
            
            while (input != 0)
            {
                var lastDigit = input % 10;
                reversedNum = reversedNum * 10 + lastDigit;
                input /= 10;
            }

            if (reversedNum < int.MinValue || reversedNum > int.MaxValue) return 0;
            return (int)reversedNum;
        }
    }
}