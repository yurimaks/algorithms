using Xunit;

namespace Althorithms
{
    public class ReverseNumberAlg
    {
        [Theory]
        [InlineData(-123, -321)]
        [InlineData(123, -21)]
        public void Run(int i, int expected)
        {
            var r = ReverseNumber(i);
            Assert.Equal(expected, r);
        }

        private static int ReverseNumber(int i)
        {
            if (i == 0) return 0;

            bool isNegative = false;
            if (i < 0)
            {
                isNegative = true;
                i = i * -1;
            }
            
            int lastDigit = 0;
            int reversedInt = 0;
            while (i >= 1)
            {
                lastDigit = i % 10;
                reversedInt = reversedInt * 10 + lastDigit;
                i /= 10;
            }

            if (isNegative)
            {
                reversedInt = reversedInt * -1;
            }

            return reversedInt;
        }
    }
}