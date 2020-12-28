using System;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// You are given two non-empty linked lists representing two non-negative integers.
    /// The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
    /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    /// https://www.geeksforgeeks.org/reverse-a-linked-list/
    /// </summary>
    public class Task2_AddTwoNumbers
    {
        [Fact]
        public void Run()
        {
            var l2 = new ListNode(2);
            var l1 = new ListNode(1, l2);
            var l0 = new ListNode(0, l1);
            //2 -> 1 -> 0

            var l7 = new ListNode(7);
            var l6 = new ListNode(6, l7);
            //7 -> 6
            var res1 = AddTwoNumbers(l0, l6);
            Assert.Equal("6, 8, 2, ", ReadListNode(res1));
        }

        private static int Depth(ListNode listNode)
        {
            var length1 = 0;
            var p1 = listNode;
            while (p1 != null)
            {
                length1++;
                p1 = p1.next;
            }

            return length1;
        }
        
        private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var dummyHead = new ListNode(0);
            var positionL1 = l1;
            var positionL2 = l2;
            var current = dummyHead;
            var memory = 0;

            while (positionL1 != null || positionL2 != null)
            {
                var valueL1 = positionL1?.val ?? 0;
                var valueL2 = positionL2?.val ?? 0;

                var sum = memory + valueL1 + valueL2;
                memory = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;

                positionL1 = positionL1?.next;
                positionL2 = positionL2?.next;
            }

            if (memory > 0)
            {
                current.next = new ListNode(memory);
            }

            return dummyHead.next;
        }

        private static string ReadListNode(ListNode listNode)
        {
            var result = string.Empty;
            var p = listNode;
            while (p != null)
            {
                result += p.val + ", ";
                p = p.next;
            }
            return result;
        }

        private static int Sum(ListNode listNode)
        {
            int i = 0;
            int res = 0;
            ListNode pointer = listNode;
            while (pointer != null)
            {
                i++;
                res = (int) Math.Pow(10, i);

                pointer = pointer.next;
            }

            return res;
        }

        private static Tuple<ListNode, int> Reverse(ListNode listNode)
        {
            int count = 0;

            ListNode next = null;
            ListNode prev = null;
            ListNode current = listNode;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            return new Tuple<ListNode, int>(prev, count);
        }
    }
}