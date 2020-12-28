
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    /// </summary>
    public class Task12
    {

        private class Symbol
        {
            public Symbol(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public string Name { get; }
            public int Value { get; }
        }
        
        List<Symbol> roman = new List<Symbol>
        {
            new Symbol("I", 1),
            new Symbol("IV", 4),
            new Symbol("V", 5),
            new Symbol("IX", 9),
            new Symbol("X", 10),
            new Symbol("XL", 40),
            new Symbol("L", 50),
            new Symbol("XC", 90),
            new Symbol("C", 100),
            new Symbol("CD", 400),
            new Symbol("D", 500),
            new Symbol("CM", 900),
            new Symbol("M", 1000)
        };
        
        [Theory]
        [InlineData(1, "I")]
        [InlineData(55, "LV")]
        [InlineData(150, "CL")]
        [InlineData(1992, "MCMXCII")]
        public void Run(int input, string expected)
        {
            var actual = IntToRoman(input);
            Assert.Equal(expected, actual);
        }

        public string IntToRoman(int num)
        {
            StringBuilder sb = new StringBuilder();

            int symbolIteration = 12;
            while (num != 0)
            {
                if (num / roman[symbolIteration].Value < 1)
                {
                    symbolIteration--;
                }
                else
                {
                    sb.Append(roman[symbolIteration].Name);
                    num -= roman[symbolIteration].Value;
                }
            }

            return sb.ToString();
        }

        public string IntToRoman_2(int num)
        {
            StringBuilder sb = new StringBuilder();

            while (num > 0)
            {
                if (num >= 1000)
                {
                    sb.Append("M");
                    num -= 1000;
                }
                else if (num >= 900)
                {
                    sb.Append("CM");
                    num -= 900;
                }
                else if (num >= 500)
                {
                    sb.Append("D");
                    num -= 500;
                }
                else if (num >= 400)
                {
                    sb.Append("CD");
                    num -= 400;
                }
                else if (num >= 100)
                {
                    sb.Append("C");
                    num -= 100;
                }
                else if (num >= 90)
                {
                    sb.Append("XC");
                    num -= 90;
                }
                else if (num >= 50)
                {
                    sb.Append("L");
                    num -= 50;
                }
                else if (num >= 40)
                {
                    sb.Append("XL");
                    num -= 40;
                }
                else if (num >= 10)
                {
                    sb.Append("X");
                    num -= 10;
                }
                else if (num == 9)
                {
                    sb.Append("IX");
                    num -= 9;
                }
                else if (num >= 5)
                {
                    sb.Append("V");
                    num -= 5;
                }
                else if (num == 4)
                {
                    sb.Append("IV");
                    num -= 4;
                }
                else if (num < 4)
                {
                    sb.Append("I");
                    num -= 1;
                }
            }

            return sb.ToString();
        }
    }
}