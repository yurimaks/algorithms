using Xunit;

namespace Althorithms
{
    public static class BinarySearch
    {
        public static int? FindIndexBS(this int[] numbers, int left, int right, int value)
        {
            if (left > right) return null;
            var mid = left + (right - left) / 2;
            if (value == numbers[mid]) return mid;
            if (value < numbers[mid])  return FindIndexBS(numbers, left, mid - 1, value);
            
            return FindIndexBS(numbers, mid + 1, right, value);
        }
        
    }
}