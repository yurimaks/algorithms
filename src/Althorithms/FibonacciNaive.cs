using System;
using Xunit;
using Xunit.Abstractions;

namespace Althorithms
{
    public class FibonacciNaive
    {
        private readonly ITestOutputHelper _testOutput;
        public FibonacciNaive(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            
        }
        
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(20)]
        public void Fibonacci(int n)
        {
            int res = 0;
            if (n > 0) res = Fib(n);
            else res = NegFib(n);
            _testOutput.WriteLine(res.ToString());
        }

        public int Fib(int n)
        {
            if (n <= 0) return 0;
            else if (n == 1) return 1;
            else return Fib(n - 1) + Fib(n - 2);
        }

        public int NegFib(int n)
        {
            if (n == 0) return 0;
            else if (n == 1) return 1;
            else return NegFib(n + 2) - NegFib(n + 1);
        }
    }
}