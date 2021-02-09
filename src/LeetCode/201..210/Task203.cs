using Common;
using Xunit;

namespace LeetCode._201._210
{
    public class Task203
    {
        [Fact]
        public void Run()
        {
            var list = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}.MakeLinkedList();

            list = RemoveElements(list, 6);
            list = RemoveElements(list, 7);
            var array = list.MakeArrayFromLinkedList();
            Assert.Equal(new[]{1,2,3,4,5,8,9,10}, array);
        }
        
        public ListNode RemoveElements(ListNode head, int val) {
        
            if (head == null) return null;
        
            while (head?.val == val)
            {
                head = head.next;
            }
        
        
            ListNode pointer1 = head;
            ListNode pointer2 = pointer1;
            while (pointer2 != null && pointer2.next != null)
            {
                if (pointer2.next.val == val)
                {
                    pointer2.next = pointer2.next.next;
                }
                else
                {
                    pointer2 = pointer2.next;    
                }
            }
        
            return pointer1;
        }
    }
}