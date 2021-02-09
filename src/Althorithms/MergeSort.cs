using Common;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Althorithms
{
    //O(n*logn)
    public class MergeSort
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        public MergeSort(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Theory]
        [InlineData(new[]{5,4,3,2,1})]
        public void Run(int[] array)
        {
            Sort(array, 0, array.Length - 1);

            array.OutputInConsole(_testOutputHelper);
        }

        private void Sort(int[] arr, int left, int right)
        {
            if (left == right) return;

            if (left < right)
            {
                int mid = (left + right) / 2;

                Sort(arr, left, mid);
                Sort(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        private void Merge(int[] arr, int l, int mid, int r)
        {
            int n1 = mid - l + 1;
            int n2 = r - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                L[i] = arr[l + i];
            }
            
            for (int j = 0; j < n2; j++)
            {
                R[j] = arr[mid + 1 + j];
            }

            int k = 0, p = 0;
            int t = l;

            while (k < n1 && p < n2)
            {
                if (L[k] <= R[p])
                {
                    arr[t] = L[k];
                    k++;
                }
                else
                {
                    arr[t] = R[p];
                    p++;
                }

                t++;
            }

            while (k < n1)
            {
                arr[t] = L[k];
                t++;
                k++;
            }

            while (p < n2)
            {
                arr[t] = R[p];
                t++;
                p++;
            }
        }
    }
}