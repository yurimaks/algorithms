using System.Collections.Generic;
using Althorithms;
using Common;
using Xunit;
namespace LeetCode._151._160
{
    public class Task160
    {
        [Fact]
        public void Run()
        {
            ListNode headA = new [] {1,2,3}.MakeLinkedList();

            ListNode headB = headA.next.next;
            
            var actual = GetIntersectionNode(headA, headB);
            Assert.Equal(3, actual.val);
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        
            if (headA == null || headB == null) return null;
        
            if (headA == headB) return headA;
        
            int countA = CountNodes(headA);
            int countB = CountNodes(headB);
        
            var diff =  0;        
            ListNode dummyHeadA = headA;
            ListNode dummyHeadB = headB;

            if (countA < countB)
            {
                diff = countB - countA;
                dummyHeadA = AddDummyHeads(dummyHeadA, diff);
            }
            else if (countA > countB)
            {
                diff = countA - countB;
                dummyHeadB = AddDummyHeads(dummyHeadB, diff);
            }
        
        
            ListNode pointerA = dummyHeadA;
            ListNode pointerB = dummyHeadB;
        
            ListNode target = null;
        
            while (pointerA != null || pointerB != null)
            {
            
                if (pointerA == pointerB)
                {
                    target = pointerA;
                    break;
                }
            
                pointerA = pointerA?.next;
                pointerB = pointerB?.next;            
            }
        
            return target;                
        }
    
        private static int CountNodes(ListNode head)
        {
            if (head == null) return 0;
        
            int count = 1;
            var pointer = head;
            while (pointer?.next != null)
            {
                count++;
                pointer = pointer.next;
            }
            return count;
        }
    
        private static ListNode AddDummyHeads(ListNode h, int diff)
        {
            ListNode dummyHead = h;
            while(diff > 0)
            {
                var dummyNode = new ListNode(-1);
                dummyNode.next = dummyHead;
                dummyHead = dummyNode;            
                diff--;
            }
        
            return dummyHead;
        }
    }
}