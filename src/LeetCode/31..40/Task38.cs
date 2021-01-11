using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode._31._40
{
    //https://www.geeksforgeeks.org/run-length-encoding/
    public class Task38
    {
        [Theory]
        [InlineData(4, "1211")]
        [InlineData(3, "21")]
        [InlineData(2, "11")]
        [InlineData(1, "1")]
        public void Run(int input, string expected)
        {
            var d = "ioztxbipnnifjlfsfbegmenhntnkhctwfgpiglmxbegdbqovfadyftsvetnrhuxalkhgavujzsgmjkjdeasuhqdcxpihiftqwyplxpmybkgtncknhlyiaplxoisfaorhmntonlriescstjbrpfsylkgedibuyjtrpvmhqztsyxepxmyfifxzdxwsttghcjpudtpbfezwegifschvduwhfgwadkheuiwqnbynmzwuwppkllgvrvsyoxztthnqwprqsurapapjqbwhttyuvsimszdtmzrpdiedvirsztuuvrww";
            var b = System.Text.Encoding.ASCII.GetBytes(d);
            var dd = System.Text.Encoding.ASCII.GetString(b);
            
            string str = "abcdefghij";

            var t = str.Length * sizeof(char);
            
            var actual = CountAndSay(input);
            Assert.Equal(expected, actual);
        }

        public string CountAndSay(int n)
        {
            if (n <= 0) return null;
            string result = "1";

            int i = 1;

            while (i < n)
            {
                StringBuilder sb = new StringBuilder();
                int count = 1;
                for (int j = 1; j < result.Length; j++)
                {
                    if (result[j] == result[j - 1])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(result[j -1]);
                        count = 1;
                    }
                }

                sb.Append(count);
                sb.Append(result[result.Length - 1]);
                result = sb.ToString();
                i++;
            }
            
            return result;
        }

        private void A(int n)
        {
            Stack<int> stack = new Stack<int>();
            int i = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;

                if (lastDigit == 0)
                {
                    lastDigit = lastDigit * (i * 10);
                }

                stack.Push(lastDigit);

                i++;
                n /= 10;
            }

            // 3000000
            //  300000
            //   20000
            //    2000
            //     200
            //      50
            //       1
            //
        }
        
    }
}