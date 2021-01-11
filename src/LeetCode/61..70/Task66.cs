using System.Text;
using Xunit;

namespace LeetCode._61._70
{
    public class Task66
    {
        [Theory]
        [InlineData(new[] {1,2,3}, new[] {1,2,4})]
        [InlineData(new[] {9,9,9}, new[] {1,0,0,0})]
        [InlineData(new[] {0}, new[] {1})]
        [InlineData(new[] {9}, new[] {1,0})]
        public void Run(int[] input, int[] b)
        {
            var actual = PlusOne(input);
            Assert.Equal(b, actual);
        }

        public int[] PlusOne(int[] digits)
        {
            for(int i=digits.Length-1; i>=0; i--)
            {
                if(digits[i]==9) 
                    digits[i]=0;
                else
                {
                    digits[i]++;
                    return digits;
                }
            }
        
            int[] result = new int[digits.Length+1];
            result[0] = 1;
            return result;
        }

        //My solution
        //Doesn't work for arrays more the 11 digits int.Max
        //digit array can contains up to 100 elements - no type handle this number
        public int[] PlusOne_v1(int[] digits)
        {
            int r = digits.Length - 1;
            int lastDigit = digits[r];
            int number = lastDigit;
            
            //from array to number
            r -= 1;
            int i = 1;
            while(r >= 0)
            {
                lastDigit = digits[r];
                if (i > 0) number += (10 * i) * lastDigit; 
                i *= 10;
                r--;
            }
        
            bool needOneMoreSpace = (number + 1)%10 == 0;
            int[] result;
            if (needOneMoreSpace)
            {
                result = new int[digits.Length + 1];
            }
            else
            {
                result = new int[digits.Length];
            }
        
            //from number to array
            number += 1;
            r = result.Length - 1;
            while(r >= 0)
            {
                lastDigit = number % 10;            
                result[r] = lastDigit;                
                number /= 10;
                r--;
            }
        

            return result;                
        }
    }
}