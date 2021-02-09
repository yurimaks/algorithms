using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode._761._770
{
    public class Task763
    {
        [Fact]
        public void Run()
        {
            string a = "ababcbacadefegdehijhklij";


           // var result = PartitionLabels(a);
            
            var result_brutteForce = PartitionLabels_BruteForce(a);
            
        }

        private List<int> PartitionLabels_BruteForce(string s)
        {
            List<int> result = new List<int>();
            Dictionary<char, int> lastEnds = new Dictionary<char, int>();

            int i = 0; 
            int j = s.Length - 1;

            while (i < s.Length && j >= i)
            {
                if (lastEnds.ContainsKey(s[i]))
                {
                    i++;
                    continue;
                }

                if (s[i] == s[j])
                {
                    lastEnds[s[i]] = j;
                    i++;
                    j = s.Length - 1;
                    continue;
                }
                j--;
            }


            int left = 0;
            int right = 0;
            for (int k = 0; k < s.Length; k++)
            {
                right = Math.Max(right, lastEnds[s[k]]);
                
                if (right == k)
                {
                    result.Add(right - left + 1);
                    left = k + 1;
                }
            }
            
            
            return result;
        }
        
        public List<int> PartitionLabels(string s)
        {
            int[] endIndex = new int[26];
            
            for (int i = 0; i < s.Length; i++)
            {
                int arrayIndex = s[i] - 'a';
                if (i > endIndex[arrayIndex])
                {
                    endIndex[arrayIndex] = i;
                }
            }
            
            List<int> segments = new List<int>();

            int segmentStart = -1;
            int segmentEnd = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int arrayIndex = s[i] - 'a';

                int end = endIndex[arrayIndex];
                if (end > segmentEnd)
                {
                    segmentEnd = end;
                }
                
                if (i == segmentEnd)
                {
                    int l = segmentEnd - segmentStart;
                    segments.Add(l);

                    segmentStart = segmentEnd;
                }
            }
            
            return segments;
        }
    }
}