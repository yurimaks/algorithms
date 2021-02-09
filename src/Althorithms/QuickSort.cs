using Common;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Althorithms
{
    //O(n*logn)
    public class QuickSort
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        public QuickSort(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Theory]
        [InlineData(new[]{5,4,3,2,1})]
        public void Run(int[] array)
        {
            /*
             * Pick a pivot element randomly
             *
             * Walk thought the array making sure that all the elements
             * are smaller before the pivot, and that all elements after are bigger
             * and we do this in place! That is the killer feature. No extra array required
             *
             * Then we repeat the process to the left and right portions over and over again
             * Then eventually our array becomes sorted
             */
            Sort(array, 0, array.Length - 1);
            
            array.OutputInConsole(_testOutputHelper);
        }

        private void Sort(int[] arr, int left, int right)
        {
            if (left >= right) return;
            
            //1. Pick a pivot
            //left + (right-left)/2 
            int pivot = arr[(left + right) / 2];

            //2. Partition the array around the pivot - return the index of the partition
            int index = partition(arr, left, right, pivot);
            
            //3. Sort on the left and the right side
            Sort(arr, left, index - 1);
            Sort(arr, index, right);
        }

        private int partition(int[] arr, int left, int right, int pivot)
        {
            //Move the left and right pointers in towards each other
            while (left <= right)
            {
                //Move left until you find an element bigger than the pivot
                while (arr[left] < pivot)
                {
                    left++;
                }

                //Move right until you fid an element smaller than the pivot
                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;

                    left++;
                    right--;
                }
            }

            //When we get here, everything in this partition will be in the right order
            //Now we need to return next partition point - which for us will be left
            return left;
        }
    }
}