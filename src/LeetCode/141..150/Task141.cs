using Common;
using Xunit;

namespace LeetCode._141._150
{
    public class Task141
    {
        [Fact]
        public void Run()
        {
            var list1 = new int[] {1, 2, 3, 4}.MakeLinkedList();
            list1.next.next = list1;

            Assert.True(HasCycle(list1));
        }
        
        public bool HasCycle(ListNode head) {
        
            if (head?.next == null) return false;

            var slow = head;
            var fast = head;
        
            while (fast?.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            
                if (slow == fast) return true;            
            }
        
            return false;
        }
        
    }
}