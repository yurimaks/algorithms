using Xunit;

namespace LeetCode._121._131
{
    public class Task125
    {
        [Theory]
        [InlineData("abba", true)]
        [InlineData("aba", true)]
        [InlineData("abbbbb", false)]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData(".,", true)]
        [InlineData(".,a", true)]
        [InlineData(".,aba  ", true)]
        [InlineData("race a car", false)]
        [InlineData("0P", false)]
        [InlineData("Ud L?dPze8Z6?INK:2:V9jwp.;.;?nO?!9XqKiesU:7Y ;,82c:6w!YMn,\",? ,`!;E:b!lF!8,5kAtx;`qoH,aK?8K:gGT2Q!C826:ODM;qJs'sJq;MDO:628C!Q2TGg:K8?Ka,Hoq`;xtAk5,8!Fl!b:E;!`, ?,\",nMY!w6:c28,; Y7:UseiKqX9!'On';.;.pwj9V:2:KNI?6Z8ezPd?L dU", true)]
        public void Run(string input, bool isValid)
        {
            var isPalindrome = IsPalindrome(input);
            Assert.Equal(isValid, isPalindrome);
        }
        
        public bool IsPalindrome(string s)
        {
            s = s.ToLower();

            int l = 0, r = s.Length - 1;
            while (l <= r)
            {
                if (!IsValidChar(s[l]))
                {
                    l++;
                    continue;
                }
                
                if (!IsValidChar(s[r]))
                {
                    r--;
                    continue;
                }

                if (s[l] == s[r])
                {
                    r--;
                    l++;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidChar(char inputChar)
        {
            return inputChar >= 48 && inputChar <= 57 || inputChar >= 97 && inputChar <= 122;
        }
    }
}