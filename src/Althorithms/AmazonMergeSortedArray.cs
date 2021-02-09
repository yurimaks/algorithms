using Xunit;

namespace Althorithms
{
    public class AmazonMergeSortedArray
    {
        [Fact]
        public void Run()
        {
            var array1 = new[] {1, 3, 5, 7};
            var array2 = new[] {2, 5, 6, 8, 11, 14};

            var mergedArray = MergeArrays_Updated(array1, array2);
            Assert.Equal(new int[]{1,2,3,5,5,6,7,8,11,14}, mergedArray);
        }

        private static int[] MergeArrays_Updated(int[] array1, int[] array2)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int length = array1.Length + array2.Length;
            int[] result = new int[length];

            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] <= array2[j])
                    result[k++] = array1[i++];
                else
                    result[k++] = array2[j++];
            }

            while (i < array1.Length)
            {
                result[k++] = array1[i++];
            }
            
            while (j < array2.Length)
            {
                result[k++] = array2[j++];
            }

            return result;
        }

        private static int[] MergeArrays(int[] array1, int[] array2)
        {
            int length = array1.Length + array2.Length;
            int[] result = new int[length];

            int i = 0;
            int j = 0;
            int k = 0;
            while (k < length)
            {
                if (i < array1.Length && j < array2.Length && array1[i] <= array2[j])
                {
                    result[k] = array1[i];
                    i++;
                }
                else if (i < array1.Length && j < array2.Length && array1[i] >= array2[j])
                {
                    result[k] = array2[j];
                    j++;
                }
                else if (i >= array1.Length && j < array2.Length)
                {
                    result[k] = array2[j];
                    j++;
                }
                else if (j >= array2.Length && i < array1.Length)
                {
                    result[k] = array1[i];
                    i++;
                }
                
                k++;
            }

            return result;
        }
        
    }
}