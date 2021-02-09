using Xunit;

namespace Althorithms
{
    public class ArrayRotation
    {
        [Fact]
        public void Run()
        {
            var a = rotLeft(new int[] {1, 2, 3}, 1);
            
            
            var b = rotRight_opt(new int[] {1, 2, 3}, 1);
            
        }
        
        
        private static int[] rotLeft(int[] a, int d) {

            while(a.Length != 0 && d > 0)
            {
                int temp = a[0];
                int i;
                for (i = 0; i < a.Length - 1; i++)
                {
                    a[i] = a[i + 1];
                }
                a[i] = temp;
                d--;
            }
            return a;
        }
        
        private static int[] rotLeft_opt(int[] a, int d)
        {
            if (a.Length == 0 || d == 0) return a;

            int[] temp = new int[d];
            for (int j = 0; j < d; j++)
            {
                temp[j] = a[j];
            }

            int i;
            for (i = 0; i < a.Length - d; i++)
            {
                a[i] = a[i + d];
            }

            for (int j = 0; j < d; j++)
            {
                a[i] = temp[j];
                i++;
            }

            return a;
        }
        
        private static int[] rotRight_opt(int[] a, int d)
        {
            if (a.Length == 0 || d == 0) return a;

            int[] temp = new int[d];
            for (int j = 0; j < d; j++)
            {
                temp[j] = a[a.Length - d + j];
            }

            int i;
            for (i = a.Length - d; i > 0; i--)
            {
                a[i] = a[i - d];
            }

            for (int j = 0; j < d; j++)
            {
                a[i] = temp[j];
                i++;
            }

            return a;
        }
        
    }
    
    
}