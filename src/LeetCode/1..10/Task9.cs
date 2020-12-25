using Xunit;

namespace LeetCode
{
    public class Task9_Palindrome_Number
    {
        [Theory]
        [InlineData(221122)]
        [InlineData(212)]
        [InlineData(11)]
        public void Run(int value)
        {
            var actual = PalindromeNumber(value);
            Assert.True(actual);
        }

        public bool PalindromeNumber(int value)
        {
            if (value < 0) return false;

            int input = value;
            long reversedNum = 0;
            
            while (value != 0)
            {
                var lastDigit = value % 10;
                reversedNum = reversedNum * 10 + lastDigit;
                value /= 10;
            }

            if (reversedNum < int.MinValue || reversedNum > int.MaxValue) return false;
            if (reversedNum == input) return true;

            return false;
        }
    }
}