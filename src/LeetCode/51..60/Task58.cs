using Xunit;

namespace LeetCode._51._60
{
    public class Task58
    {
        [Theory]
        [InlineData("asd asd", 3)]
        [InlineData("asd asd asdasda asdasd", 6)]
        [InlineData("hello world", 5)]
        [InlineData("h elloworld", 9)]
        [InlineData("hello", 5)]
        [InlineData("h ", 1)]
        public void Run(string input, int length)
        {
            var actual = LengthOfLastWord(input);
            Assert.Equal(length, actual);
        }

        public int LengthOfLastWord(string s)
        {
            if (s == null) return 0;
            int l = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    if (l > 0)
                    {
                        return l;
                    }
                    continue;
                }

                l++;
            }

            return l;
        }
    }
}