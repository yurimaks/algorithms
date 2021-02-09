using Common;
using Xunit;
using Xunit.Abstractions;

namespace Althorithms
{
    public class BubbleSort
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        public BubbleSort(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Theory]
        [InlineData(new[]{5,4,3,2,1})]
        public void Run(int[] array)
        {
            int l = array.Length;
            for (int i = 0; i <  l - 1; i++)
            {
                for (int j = 0; j < l - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            array.OutputInConsole(_testOutputHelper);
        }
    }
}