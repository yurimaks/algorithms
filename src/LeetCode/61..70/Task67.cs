using System.Text;
using Xunit;

namespace LeetCode._61._70
{
    public class Task67
    {
        [Theory]
        [InlineData("101", "11", "1000")]
        [InlineData("11", "101", "1000")]
        [InlineData("1000", "1001", "10001")]
        [InlineData("0", "0", "0")]
        [InlineData("1", "0", "1")]
        [InlineData("10", "0", "10")]
        public void Run(string a, string b, string expected)
        {
            var actual = AddBinary(a, b);
            Assert.Equal(expected, actual);
        }

        public string AddBinary(string a, string b)
        {
            int i_a = a.Length - 1;
            int i_b = b.Length - 1;
            char temp = '0'; 
            StringBuilder sb = new StringBuilder();
            while (i_a >= 0 || i_b >= 0)
            {
                char left = i_a >= 0 ? a[i_a] : '0';
                char right = i_b >= 0 ? b[i_b] : '0';
                
                if (left == '0' && left == right)
                {
                    if (temp == '1')
                    {
                        sb.Insert(0, '1');
                        temp = '0';
                    }
                    else
                    {
                        sb.Insert(0, '0');
                    }
                    
                }
                else if (left == '1' && left == right)
                {
                    sb.Insert(0, temp == '1' ? '1' : '0');
                    temp = '1';
                }
                else if (left != right)
                {
                    sb.Insert(0, temp == '1' ? '0' : '1');
                }

                i_a--;
                i_b--;
            }
            
            if (temp == '1') sb.Insert(0, '1');

            return sb.ToString();
        }
    }
}