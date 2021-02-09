using Common;
using Xunit;

namespace LeetCode._81._90
{
    public class Task83
    {
        [Fact]
        public void Run()
        {
            var list = new int[] { 1,2,3,4,4,5,6 }.MakeLinkedList();
            var array = DeleteDuplicates(list).MakeArrayFromLinkedList();
            Assert.Equal(new[]{1,2,3,4,5,6}, array);
        }
        
        public ListNode DeleteDuplicates(ListNode head) {
                
            if (head == null) return null;
            
            var slow_tail = head;
            var fast = head;
        
            while(fast.next != null)
            {
                if (fast.val != fast.next.val)
                {
                    slow_tail.next = fast.next;   
                    slow_tail = slow_tail.next;
                }
                fast = fast.next;
            }
        
            slow_tail.next = null;
            return head;
        } 
        
    }
}