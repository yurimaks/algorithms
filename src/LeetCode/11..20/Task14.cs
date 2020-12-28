using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Write a function to find the longest common prefix string amongst an array of strings.
    /// If there is no common prefix, return an empty string "".
    /// </summary>
    public class Task14
    {
        [Theory]
        [InlineData(new[] {"ffa", "ffb", "ffc"}, "ff")]
        [InlineData(new[] {"abba", "abba", "abba"}, "abba")]
        [InlineData(new[] {"flower", "flow", "flight"}, "fl")]
        [InlineData(new[] {"dog","racecar","car"}, "")]
        public void Run(string[] input, string expected)
        {
            var actual = LongestCommonPrefix_2(input);
            Assert.Equal(expected, actual);
        }

        public string LongestCommonPrefix_2(string[] strs)
        {
            if (strs.Length == 0 || string.IsNullOrEmpty(strs[0])) return string.Empty;

            var prefix = strs[0];
            for (var i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0) {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (prefix == "") return "";
                }
            }

            return prefix;
        }
        
        //My solution
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0 || string.IsNullOrEmpty(strs[0])) return string.Empty;

            var commonPrefixTemp = strs[0][0];
            var charList = new List<char>();

            int i = 0, j = 0;

            while (true)
            {
                if (i < strs.Length && j < strs[i].Length)
                {
                    var inputChar = strs[i][j];

                    if (!commonPrefixTemp.Equals(inputChar))
                    {
                        if (i > 0) break;
                        commonPrefixTemp = inputChar;
                    }

                    if (i == strs.Length - 1)
                    {
                        charList.Add(commonPrefixTemp);
                        commonPrefixTemp = Char.MinValue;
                    }

                    i++;
                }

                if (i >= strs.Length)
                {
                    j++;
                    i = 0;
                }
                else if (j >= strs[i].Length) break;
            }

            var sb = new StringBuilder();
            foreach (var ch in charList) sb.Append(ch); 
            return sb.ToString();
        }
    }
}