using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Implement strStr().
    /// Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
    /// </summary>
    public class Task28
    {
        [Theory]
        [InlineData("hello", "ll", 2)]
        [InlineData("hello", "", 0)]
        [InlineData("hello", "he", 0)]
        [InlineData("hello", "el", 1)]
        [InlineData("hello", "asdasd", -1)]
        [InlineData("aaaaa", "bba", -1)]
        [InlineData("", "", 0)]
        [InlineData("a", "a", 0)]
        [InlineData("aaa", "aaaa", -1)]
        [InlineData("mississippi", "issip", 4)]
        [InlineData("teachmeJake", "Jake", 7)]
        [InlineData("abcxabcdadxabcdabcdabcy", "abcdabcy", 1)]
        public void Run(string haystack, string needle, int expected)
        {
            var actual = Implement_strStr_KMP_Knuth_Morris_Pratt(haystack, needle);
            Assert.Equal(expected, actual);
        }

        //Knuth–Morris–Pratt algorithm
        /*
            Search substring in string
            O(n+m)
            needle used to built a partial match table - PMT
            partial match length - number of matches
            to skip use next: partial match length - needle[partial_match_length - 1] 
            skip from the start of last match

         1.  partial match table - table: needle - abababca  -  0 | 0 | 1 | 2 | 3 | 4 | 0 | 1 |  length of the longest match of prefix and suffix
             
             bacbababaabcbab
              |
              abababca

            partial 1
            1 - table[1 - 1] = 0 - nothing to skip
         2.bacbababaabcbab
             ?
             abababca
             
           bacbababaabcbab
              ?
              abababca
              
            bacbababaabcbab
                |||||s
                abababca
            partial = 5
            5 - table[5 - 1] = 5 - table[4] = 5 - 3 = 2 - skip 2 chars from the haystack from last char matched
            
            bacbababaabcbab
                xx|||s
                  abababca
            partial = 3
            3 - table[3 - 1] = 3 - table[2] = 3 - 1 = 2 - skip 2 chars from the haystack from last char matched
            bacbababaabcbab
                xxxx|s
                    abababca > length - no match
        */
        private int Implement_strStr_KMP_Knuth_Morris_Pratt(string haystack, string needle)
        {
            if (haystack==null || needle==null) return 0;
 
            int h = haystack.Length;
            int n = needle.Length;
 
            if (n > h) return -1;
            if (n == 0) return 0;
 
            int[] partialMatchTable = BuildPartialMatchTable(needle);
            int i = 0;
 
            while (i <= h - n)
            {
                int success = 1;
                for (int j = 0; j < n; j++) 
                {
                    if (needle[0] != haystack[i])
                    {
                        success = 0;
                        i++;
                        break;
                    } 
                    else if (needle[j] != haystack[i + j])
                    {
                        success = 0;
                        i = i + j - partialMatchTable[j - 1];
                        break;
                    }
                }
                if (success == 1) return i;
            }
 
            return -1;
        }
        
        //Build KMP partial match table for pattern string - needle
        //lengths of longest prefixes and suffixes for each substring of needle
        //Partial match table or KMP array
        public int[] BuildPartialMatchTable(string needle)
        {
            int[] partialMatchTable = new int[needle.Length];
            partialMatchTable[0] = 0;

            for (int i = 1; i < needle.Length; i++)
            {
                int index = partialMatchTable[i - 1];
                while (index > 0 && needle[index] != needle[i])
                {
                    index = partialMatchTable[index - 1];
                }

                if (needle[index] == needle[i])
                {
                    partialMatchTable[i] = partialMatchTable[i - 1] + 1;
                }
                else
                {
                    partialMatchTable[i] = 0;
                }
            }

            return partialMatchTable;
        }
        
        //My solution O(n*m)
        private int Implement_strStr_BruteForce_Without_Substring(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle) ||                           // if needed is empty return 0. Empty strings are always considered to be a substring of any other string. Just like an empty set is a subset of any set
                (haystack.Length == needle.Length && haystack == needle)) // if the strings are equal
                return 0;
            if (haystack.Length < needle.Length) return -1; //If needle is more than haystack

            int i, j;
            int n = needle.Length;
            int m = haystack.Length;

            for (i = 0; i <= m - n; i++)
            {
                for (j = 0; j < n; j++) // iterating the full needle string
                {
                    if (haystack[i + j] != needle[j]) break; // i+j explains why we are checking h-n+1 above, we are already moving ahead by adding both the index and hence covering all the chars of haystack. Also, we're/We have "breaking/added a break" since we were not able to find the string as there was a mismatch in the chars of needle[j] and haystack[i+j]
                    if (j == n - 1) return i; // We are already at the last index and needle[j] == haystack[i+j]. So returned the i index, that means where our string matching begin at the first place.
                }
            }

            return -1; // return -1 if not able to find any match.
        }

        //My solution second one (O(n*m))
        private int Implement_strStr_BruteForce_With_Substring(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle) ||                           // if needed is empty return 0. Empty strings are always considered to be a substring of any other string. Just like an empty set is a subset of any set
                (haystack.Length == needle.Length && haystack == needle)) // if the strings are equal
                return 0;
            if (haystack.Length < needle.Length) return -1; //If needle is more than haystack

            for (int i = 0; i <= haystack.Length - needle.Length; i++)  //search needed as a substring in haystack   (do not iterate over the length of haystack)
            {
                if (haystack.Substring(i, needle.Length) == needle) return i;
            }

            return -1;
        }
       
        //My solution wrong for mississippi -> issip
        private int Implement_strStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0;

            int i = 0, j = 0, o = -1;
            int n = needle.Length;
            int m = haystack.Length;
            if (m < n) return o;

            while(i < n && j < m)
            {
                if (haystack[j] == needle[i])
                {
                    i++;
                    if (o == -1) o = j;
                }
                else if (j > 0)
                {
                    i = 0;
                    o = -1;
                }

                j++;
            }

            return o;
        }
    }
}