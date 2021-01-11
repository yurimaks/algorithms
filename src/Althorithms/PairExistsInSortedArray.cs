using Xunit;

namespace Althorithms
{
    /// <summary>
    /// Two-pointer approach - one and end
    /// Slow-fast runners - diff pace
    /// </summary>
    public class PairExistsInSortedArrayAlg
    {
        [Theory]
        [InlineData(new[]{0, 1,2,3,4,5,6,7,8,9,10}, 1, true)]
        [InlineData(new[]{0, 1,2,3,4,5,6,7,8,9,10}, 4, true)]
        [InlineData(new[]{0, 1,2,3,4,5,6,7,8,9,10}, 9, true)]
        [InlineData(new[]{0, 1,2,3,4,5,6,7,8,9,10}, 8, true)]
        [InlineData(new[]{0, 1,2,3,4,5,6,7,8,9,10}, 19, true)]
        [InlineData(new[]{0, 1,2,3,4,5,6,7,8,9,10}, 20, false)]
        public void Run(int[] array, int target, bool expected)
        {
            var actual = PairExistsInSortedArray_TwoPointers(array, target);
            Assert.Equal(expected, actual);
        }
        
        //O(n)
        public bool PairExistsInSortedArray_TwoPointers(int[] array, int target)
        {
            int i = 0, j = array.Length - 1;
            while (i < j)
            {
                int sum = array[i] + array[j];
                if (sum == target) return true;

                if (sum < target) i++;
                if (sum > target) j--;
            }

            return false;
        }

        public bool PairExistsInSortedArray_BruteForce(int[] array, int target)
        {
            int l = array.Length;
            for (int i = 0; i < l - 1; i++)
            {
                for (int j = 1; j < l; j++)
                {
                    if (array[i] + array[j] == target) return true;
                }
            }

            return false;
        }
    }
}