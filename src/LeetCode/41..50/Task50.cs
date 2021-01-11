using Xunit;

namespace LeetCode._41._50
{
    public class Task50
    {
        [Theory]
        [InlineData(2.0000, 10, 1024.00000)]
        [InlineData(2.0000, 2, 4.00000)]
        [InlineData(1.0000, -2147483648, 1.00000)]
        public void Run(double x, int n, double expected)
        {
            var actual = MyPow(x, n);
            Assert.Equal(expected, actual);
        }
        
        public double MyPow(double x, int n)
        {
            return MyPowD(x, n);
        }
        
        private static double MyPowD(double x, long n)
        {
            if (n == 0) return 1;
            if (n < 0) return MyPowD(1/x, -n);

            if (n % 2 == 0)
            {
                double v = MyPowD(x, n/2);
                return v * v;
            }
            else
            {
                double v = MyPowD(x, n/2);
                return v * v * x;
            }
        }
    }
}