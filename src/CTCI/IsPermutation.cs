using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CTCI
{
    public class IsPermutationTask
    {
        [Theory]
        [InlineData("abc", "ab", false)]
        [InlineData("ab", "ba", true)]
        [InlineData("acvftag", "tagacvf", true)]
        public void Run(string input1, string input2, bool expected)
        {
            var actual = IsPermutation(input1, input2);
            Assert.Equal(expected, actual);
        }

        private bool IsPermutation(string input1, string input2)
        {
            if (input1.Length != input2.Length) return false;

            var sorted1 = input1.ToCharArray();
            var sorted2 = input2.ToCharArray();
            
            Array.Sort(sorted1);
            Array.Sort(sorted2);

            return sorted1.SequenceEqual(sorted2);
        }
    }
}