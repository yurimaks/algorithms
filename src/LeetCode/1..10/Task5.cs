using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Given a string s, return the longest palindromic substring in s.
    /// </summary>
    public class Task5_LongestPalindromicSubstring
    {
        [Theory]
        [InlineData("b", "b")]
        [InlineData("ac", "c")]
        [InlineData("bb", "bb")]
        [InlineData("bab", "bab")]
        [InlineData("cbaa", "aa")]
        [InlineData("cbbd", "bb")]
        [InlineData("zabba", "abba")]
        [InlineData("3211245", "2112")]
        [InlineData("aacabdkacaa", "aca")]
        [InlineData("acakaca", "acakaca")]
        public void LongestPalindromicSubstring(string s, string expected_s)
        {
            var actual_s = GetLongestPalindromicSubstring_2(s);
            Assert.Equal(expected_s, actual_s);
        }

        private string GetLongestPalindromicSubstring_2(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            if (s.Length == 1) return s[0].ToString();

            int start = 0, end = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var len1 = ExpandAroundCenter(s, i, i);
                var len2 = ExpandAroundCenter(s, i, i + 1);
                var len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            var lastIndex = end + 1;
            return s.Substring(start, lastIndex - start);
        }

        private int ExpandAroundCenter(String s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R]) {
                L--;
                R++;
            }
            return R - L - 1;
        }

        //My first attempt.
        public string GetLongestPalindromicSubstring(string s)
        {
            var length = s.Length;
            int forward_start = 0;
            int backward_start = s.Length - 1;
            List<char> set = new List<char>();
            
            while (forward_start < length && backward_start >= 0 && forward_start != backward_start)
            {
                var forward_char = s[forward_start];
                var backward_char = s[backward_start];

                if (forward_char == backward_char)
                {
                    set.Add(s[forward_start++]);
                    backward_start--;
                }
                else
                {
                    backward_start--;
                }
            }

            if (set.Count == 0) return s[0].ToString();
            
            if (forward_start < length && backward_start >= 0)
            {
                var substring = s.Substring(forward_start);
                var substringPalindromic = GetLongestPalindromicSubstring(substring);
                if (substringPalindromic.Length > set.Count) return substringPalindromic;
            }
            
            var sb = new StringBuilder(set.Count);
            foreach (var v in set)
            {
                sb.Append(v);
            }
            
            return sb.ToString();
        }
    }
}