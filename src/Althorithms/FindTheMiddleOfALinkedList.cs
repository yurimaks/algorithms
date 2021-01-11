using Common;
using Xunit;

namespace Althorithms
{
    /// <summary>
    /// https://afteracademy.com/blog/what-is-the-two-pointer-technique
    /// </summary>
    public class FindTheMiddleLinkedList
    {
        [Theory]
        [InlineData(new[]{0,1,2,3,4,5,6,7,8,9,10}, 5)]
        [InlineData(new[]{0,1,2}, 1)]
        [InlineData(new[]{1}, 1)]
        [InlineData(new[]{0,1,2,3,4,5,6}, 3)]
        public void Run(int[] array, int expected)
        {
            ListNode ln = array.MakeLinkedList();
            var actual = FindTheMiddleOfALinkedList(ln);
            Assert.Equal(expected, actual);
        }

        private int FindTheMiddleOfALinkedList(ListNode ln)
        {
            ListNode fast = ln;
            ListNode slow = ln;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow.val;
        }
    }
}