using Xunit;

namespace LeetCode._981._990
{
    public class Task985
    {
        [Fact]
        public void Run()
        {
            var array = new int[] {1, 2, 3, 4};
            var queries = new[] {new[] {1, 0}, new[] {-3, 1}, new[] {-4, 0}, new[] {2, 3}};
            var a = SumEvenAfterQueries(array, queries);
            
            Assert.Equal(new[]{8,6,2,4}, a);
        }

        
        public int[] SumEvenAfterQueries(int[] A, int[][] queries)
        {
            if (A.Length == 0 || queries.Length == 0) return A;
                
            int evenSum = 0;
            for (int j = 0; j < A.Length; j++)
            {
                if (A[j] % 2 == 0)
                {
                    evenSum += A[j];
                }
            }

            int[] result = new int[queries.Length];
        
            for (int i = 0; i < queries.Length; i++)
            {
                int val = queries[i][0];
                int index = queries[i][1];
                        
                if (index > A.Length - 1) 
                {
                    continue;
                }
            
                if (A[index] % 2 == 0)
                {
                    if ((A[index] + val) % 2 == 0)
                    {
                        evenSum += val;
                    }
                    else
                    {
                        evenSum -= A[index];
                    }
                }
                else
                {
                    if ((A[index] + val) % 2 == 0)
                    {
                        evenSum += (A[index] + val);
                    }             
                }
                A[index] = A[index] + val;            
                result[i] = evenSum;
            }
        
            return result;
        }
        
    }
    
    
}