using Common;
using Xunit;

namespace LeetCode
{
    //Merge k Sorted Lists , Hard
    public class Task23
    {
        [Theory]
        [InlineData(new[]{1, 1}, new[]{0,1,2}, new[]{0,1,2,3,4,5,6})]
        public void Run(int[] array1, int[] array2, int[] array3)
        {
            var mergedArray = new[] {0, 0, 1, 1, 1, 1, 2, 2, 3, 4, 5, 6}.MakeLinkedList();
            var a1 = array1.MakeLinkedList();
            var a2 = array2.MakeLinkedList();
            var a3 = array3.MakeLinkedList();

            var mergedLinedList = MergeKLists(new[] {a1, a2, a3});
            Assert.Equal(mergedArray.MakeArrayFromLinkedList(), mergedLinedList.MakeArrayFromLinkedList());
        }
        
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;
        
            return DivideAndConquer(lists, 0, lists.Length - 1);
        }
        
        private static ListNode DivideAndConquer(ListNode[] array, int l, int r)
        {
            if (l == r) return array[l];
        
            int mid = l + (r - l) / 2;
        
            ListNode left = DivideAndConquer(array, l, mid);
            ListNode right = DivideAndConquer(array, mid + 1, r);
        
            return MergeLists(left, right);            
        }
    
        private static ListNode MergeLists(ListNode leftNode, ListNode rightNode)
        {
            ListNode pointerLeft = leftNode;
            ListNode pointerRight = rightNode;
        
            ListNode mergedListDummyHead = new ListNode(-1);
            ListNode tail = mergedListDummyHead;
        
            while (pointerLeft != null && pointerRight != null)
            {           
            
                if (pointerLeft.val < pointerRight.val)
                {
                    tail.next = pointerLeft;
                    pointerLeft = pointerLeft.next;
                }
                else
                {
                    tail.next = pointerRight;
                    pointerRight = pointerRight.next;
                }
            
                tail = tail.next;            
            }
        
            //If lists have different length -> just add left nodes
            if (pointerLeft != null)
            {
                tail.next = pointerLeft;
            }
        
            if (pointerRight != null)
            {
                tail.next = pointerRight;
            }
        
            return mergedListDummyHead.next;
        }        
    }
}