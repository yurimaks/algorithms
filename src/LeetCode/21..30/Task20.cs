using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    /// An input string is valid if:
    /// Open brackets must be closed by the same type of brackets.
    /// Open brackets must be closed in the correct order.
    /// </summary>
    public class Task20
    {
        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("([)]", false)]
        [InlineData("{[]}", true)]
        public void Run(string input, bool expected)
        {
            var isValid = IsValidParentheses(input);
            Assert.Equal(expected, isValid);
        }

        public bool IsValidParentheses(string input)
        {
            Stack<char> charsSet = new Stack<char>(input.Length);
            
            foreach (var t in input)
            {
                if (t == '{' || t == '(' || t == '[')
                {
                    charsSet.Push(t);
                } 
                else if (t == '}' || t == ')' || t == ']')
                {
                    if (charsSet.Count > 0)
                    {
                        char el = charsSet.Pop();
                        if (t == '}' && el != '{' ||
                            t == ')' && el != '(' ||
                            t == ']' && el != '[') return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return charsSet.Count == 0;
        }
        
    }
}