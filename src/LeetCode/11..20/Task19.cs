using Common;
using Xunit;

namespace LeetCode
{
    
    public class Task19
    {
        [Fact]
        public void Run()
        {
            var input = new[] {0, 1, 2, 3, 4, 5, 6}.MakeLinkedList();
            var listNode = RemoveNthFromEnd(input, 3).MakeArrayFromLinkedList();
            Assert.Equal(listNode, new[]{0,1,2,3,5,6});
        }
        
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {        
            if (head == null) return null;

            var slow = head;
            var fast = head;

            while (n >= 1 && fast.next != null)
            {
                fast = fast.next;
                n--;
            }

            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            if (slow == head && n > 0)
            {
                head = head.next;
            }
            else
            {
                slow.next = slow.next?.next;
            }
        
            return head;                        
        }
    }
}