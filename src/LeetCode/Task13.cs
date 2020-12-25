using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public class Task13
    {
        Dictionary<char, int> roman = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        ///Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        /// 13. Roman to Integer
        /// Symbol       Value
        /// I             1
        /// V             5
        /// X             10
        /// L             50
        /// C             100
        /// D             500
        /// M             1000
        /// I can be placed before V (5) and X (10) to make 4 and 9.
        /// X can be placed before L (50) and C (100) to make 40 and 90.
        /// C can be placed before D (500) and M (1000) to make 400 and 900.
        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void Run(string romanNumber, int expectedInteger)
        {
            var actual = RomanToInt(romanNumber);
            Assert.Equal(expectedInteger, actual);
        }

        //My solution
        public int RomanToInt(string s)
        {
            var n = 0;
            var result = 0;

            while (n < s.Length)
            {
                var doSubtract = false;
                if (s[n] == 'I')
                {
                    doSubtract = DoSubtract(s, n, 'V', 'X');
                }
                else if (s[n] == 'X')
                {
                    doSubtract = DoSubtract(s, n, 'L', 'C');
                }
                else if (s[n] == 'C')
                {
                    doSubtract = DoSubtract(s, n, 'D', 'M');
                }


                result += doSubtract ? -1 * roman[s[n]] : roman[s[n]];
                n++;
            }

            return result;
        }

        private static bool DoSubtract(string s, int n, char roman1, char roman2)
        {
            return n + 1 < s.Length && (s[n + 1] == roman1 || s[n + 1] == roman2);
        }

        //Brute force internet solution
        public int RomanToInt_2(string s)
        {
            int sum = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == 'I')
                {
                    sum += 1;
                }

                if (s[i] == 'V')
                {
                    sum += 5;
                    if (i > 0 && s[i - 1] == 'I')
                    {
                        sum -= 1;
                        i -= 1;
                    }
                }

                if (s[i] == 'X')
                {
                    sum += 10;
                    if (i > 0 && s[i - 1] == 'I')
                    {
                        sum -= 1;
                        i -= 1;
                    }
                }

                if (s[i] == 'L')
                {
                    sum += 50;
                    if (i > 0 && s[i - 1] == 'X')
                    {
                        sum -= 10;
                        i -= 1;
                    }
                }

                if (s[i] == 'C')
                {
                    sum += 100;
                    if (i > 0 && s[i - 1] == 'X')
                    {
                        sum -= 10;
                        i -= 1;
                    }
                }

                if (s[i] == 'D')
                {
                    sum += 500;
                    if (i > 0 && s[i - 1] == 'C')
                    {
                        sum -= 100;
                        i -= 1;
                    }
                }


                if (s[i] == 'M')
                {
                    sum += 1000;
                    if (i > 0 && s[i - 1] == 'C')
                    {
                        sum -= 100;
                        i -= 1;
                    }
                }
            }

            return sum;
        }
    }
}