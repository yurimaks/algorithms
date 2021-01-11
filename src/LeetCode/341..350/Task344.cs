using System;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode._341._350
{
    public class Task344
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Task344(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(new[]{'a', 'b', 'c'})]
        [InlineData(new[]{'a', 'b', 'c', 'd'})]
        [InlineData(new[]{'a', 'b', 'c', 'e'})]
        [InlineData(new[]{'h', 'e', 'l', 'l'})]
        [InlineData(new[]{'a'})]
        [InlineData(new char[0])]
        public void Run(char[] chars)
        {
            ReverseString_v2(chars);

            foreach (var c in chars)
            {
                _testOutputHelper.WriteLine(c.ToString());
            }
        }
        
        public void ReverseString_v1(char[] s)
        {
            if (s == null || s.Length <= 1) return;
            
            int mid = s.Length / 2;
            for (int i = 0; i < mid; i++)
            {
                char temp = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = temp;
            }
        }
        
        public void ReverseString_v2(char[] s)
        {
            if (s == null || s.Length <= 1) return;

            int i = 0, j = s.Length - 1;
            
            while (i < j)
            {
                char temp = s[i];
                s[i] = s[j];
                s[j] = temp;

                i++;
                j--;
            }
        }
    }
}