namespace LeetCode
{
    public static class Helpers
    {
        public static ListNode MakeLinkedList(this int[] array)
        {
            if (array.Length <= 0) return null;
            ListNode l = new ListNode(array[0]);
            ListNode tail = l;
            for (int i = 1; i < array.Length; i++)
            {
                tail.next = new ListNode(array[i]);
                tail = tail.next;
            }

            return l;
        } 
    }
    
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}