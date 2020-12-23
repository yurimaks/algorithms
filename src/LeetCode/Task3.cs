using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Given a string s, find the length of the longest substring without repeating characters.
    /// </summary>
    public class Task3_LongestSubstringWithoutRepeatingCharacters
    {
        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("dvdf", 3)]
        [InlineData("pwwkew", 3)]
        public void Run(string s, int number)
        {
            Assert.Equal(number, LengthOfLongestSubstring_2(s));
        }

        //Sliding Window
        //Approach in array/string
        //[i,j) (left-closed, right-open). A sliding window is a window "slides" its two boundaries to the certain direction.
        private static int LengthOfLongestSubstring_2(string s)
        {
            int n = s.Length;
            HashSet<char> set = new HashSet<char>();
            int ans = 0, start = 0, end = 0;
            while (start < n && end < n)
            {
                // try to extend the range [i, j]
                if (!set.Contains(s[end]))
                {
                    set.Add(s[end++]);
                    ans = Math.Max(ans, end - start);
                }
                else
                {
                    set.Remove(s[start++]);
                }
            }
            return ans;
        }

        private static int LengthOfLongestSubstring_3(string s)
        {
            int n = s.Length, ans = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>(); // current index of character
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++) {
                if (dict.ContainsKey(s[j])) {
                    i = Math.Max(dict[s[j]], i);
                }
                ans = Math.Max(ans, j - i + 1);
                dict.Add(s[j], j + 1);
            }
            return ans;
        }

        //My first attempt.
        //This is a correct intention but wrong realization
        private static int LengthOfLongestSubstring_1(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var dict = new Dictionary<char, int>();
            var intervals_start = -1;
            var intervals_end = -1;
            var interval = 0;
            for (var i = 0; i < s.Length; i++)
            {
                int diff;
                if (dict.ContainsKey(s[i]))
                {
                    diff = intervals_end - intervals_start + 1;
            
                    if (diff > interval)
                    {
                        interval = diff;
                    }
            
                    intervals_start++;
                    dict[s[i]]++;
                    dict.Remove(s[i]);
                }

                dict.Add(s[i], 1);
                if (intervals_start < 0)
                {
                    intervals_start = i;
                }
                intervals_end = i;

                diff = intervals_end - intervals_start + 1;
          
                if (diff > interval)
                {
                    interval = diff;
                }
            }
            return interval;
        }
    }
}