using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace Althorithms
{
    public class MakeAnagramTask
    {
        [Theory]
        //[InlineData("dzasdaseedce", "cghhyyj")]
        //[InlineData("cghhyyj", "abc")]
        [InlineData("fsqoiaidfaukvngpsugszsnseskicpejjvytviya", "ksmfgsxamduovigbasjchnoskolfwjhgetnmnkmcphqmpwnrrwtymjtwxget")]
        [InlineData("fcrxzwscanmligyxyvym", "jxwtrhvujlmrpdoqbisbwhmgpmeoke")]
        public void Run(string a, string b)
        {
           var i =  MakeAnagram(a, b);
        }

        public int MakeAnagram(string a, string b)
        {
            if (a.Length > b.Length)
            {
                var uninue = b.Intersect(a).ToList();
                return (a.Length - uninue.Count) + (b.Length - uninue.Count);
            }
            if (a.Length <= b.Length)
            {
                var uninue1 = a.Intersect(b).ToList();
                return (a.Length - uninue1.Count) + (b.Length - uninue1.Count);
            }

            return -1;
        }
        
        public int makeAnagram_1(string a, string b) {

            int[] count1 = new int[26];
            int[] count2 = new int[26];
        
            CountFrequency(a, count1);
            CountFrequency(b, count2);
        
            int result = 0;
            for(int i = 0; i < 26; i++)
            {
                result += Math.Abs(count1[i] - count2[i]);
            }
            return result;        
        }
    
        private static void CountFrequency(string input, int[] count)
        {
            for (int i=0; i < input.Length - 1; i++)
            {
                count[input[i] - 'a']++;
            }
        }
    }
}