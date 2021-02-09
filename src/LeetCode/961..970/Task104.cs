using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode._961._970
{
    public class Task961
    {
        [Fact]
        public void Run()
        {
            var array = new int[] {5, 1, 5, 2, 5, 3, 5, 4};
            var repeated = RepeatedNTimes(array);
            Assert.Equal(5, repeated);
        }

        public int RepeatedNTimes(int[] A)
        {
            HashSet<int> hash = new HashSet<int>();
        
            for (int i = 0; i < A.Length; i++)
            {
                if (hash.Contains(A[i])) return A[i];
                hash.Add(A[i]);
            }
            return -1;
        }
    }
}