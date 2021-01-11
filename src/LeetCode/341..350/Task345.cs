using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode._341._350
{
    public class Task345
    {

        
        [Theory]
        [InlineData("hello", "holle")]
        [InlineData("leetcode", "leotcede")]
        [InlineData("", "")]
        public void Run(string s, string expected)
        {
            var actual = ReverseVowels(s);

            Assert.Equal(expected, actual);
        }
        
        public string ReverseVowels(string s)
        {
            int i = 0, j = s.Length - 1;

            StringBuilder sb = new StringBuilder(s);

            while (i <= j)
            {
                if (!IsVowels(s[i]))
                {
                    sb[i] = s[i];
                    i++;
                    continue;
                }
                
                if (!IsVowels(s[j]))
                {
                    sb[j] = s[j];
                    j--;
                    continue;
                }

                sb[i] = s[j];
                sb[j] = s[i];

                i++;
                j--;
            }

            return sb.ToString();
        }

        HashSet<char> _vowels = new HashSet<char>(new []
        {
            'a',
            'A',
            'o',
            'O',
            'u',
            'U',
            'e',
            'E',
            'i',
            'I'
        });
        
        private bool IsVowels(char c)
        {
            return _vowels.Contains(c);
        }
    }
}