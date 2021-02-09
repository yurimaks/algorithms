using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CTCI
{
    public class IsUniqueCharacters
    {
        [Theory]
        [InlineData("aa", false)]
        [InlineData("ab", true)]
        [InlineData("acvftag", false)]
        public void Run(string input, bool expected)
        {
            var actual = IsUnique_v1(input);
            Assert.Equal(expected, actual);
        }

        private bool IsUnique_v1(string input)
        {
            if (input.Length > 128) return false;
            int i = 0, n = input.Length;
            var setChar = new bool[128];
            while (i < n)
            {
                if (setChar[input[i]]) return false;
                setChar[input[i]] = true;
                i++;
            }

            return true;
        }

        private bool IsUnique(string input)
        {
            if (input.Length > 128) return false; //We assume only ASCII chars can be in the input
            var hash = new HashSet<char>();
            int i = 0, n = input.Length;
            
            while (i < n)
            {
                if (hash.Contains(input[i])) return false;
                hash.Add(input[i]);
                i++;
            }

            return true;
        }
    }
}