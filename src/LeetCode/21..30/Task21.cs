﻿using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Merge two sorted linked lists and return it as a new sorted list.
    /// The new list should be made by splicing together the nodes of the first two lists.
    /// </summary>
    public class Task21
    {
        [Theory]
        [InlineData(new[] {1, 2, 3}, new[] {1, 3, 4}, new[] {1, 1, 2, 3, 3, 4})]
        [InlineData(new[] {1, 2, 3}, new[] {5, 6, 7}, new[] {1, 5, 2, 6, 3, 7})]
        [InlineData(new int[0], new int[0], new int[0])]
        [InlineData(new int[0], new[] {1}, new int[] {1})]
        public void Run(int[] input1, int[] input2, int[] expected)
        {
            var l1 = input1.MakeLinkedList();
            var l2 = input2.MakeLinkedList();

            var mergedListNode = MergeTwoLists(l1, l2);
            var actual = LinkedListToArray(mergedListNode);
            Assert.Equal(expected, actual);
        }
        
        private ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null) return null;

            ListNode headCommon = new ListNode(-1);

            ListNode current1 = l1;
            ListNode current2 = l2;

            ListNode tail = headCommon;

            while (current1 != null && current2 != null)
            {
                if (current1.val < current2.val)
                {
                    tail.next = current1;
                    current1 = current1.next;
                }
                else
                {
                    tail.next = current2;
                    current2 = current2.next;
                }

                tail = tail.next;
            }

            if (current1 != null)
            {
                tail.next = current1;
            }
            
            if (current2 != null)
            {
                tail.next = current2;
            }
            
            
            
            // while ((current1 != null || current2 != null) && tail.next == null)
            // {
            //     if (current1 != null && current2 != null)
            //     {
            //         if (current1.val <= current2.val)
            //         {
            //             tail.next = new ListNode(current1.val);
            //             tail.next.next = new ListNode(current2.val);
            //             tail = tail.next.next;
            //         }
            //         else if (current1.val > current2.val)
            //         {
            //             tail.next = new ListNode(current2.val);
            //             tail.next.next = new ListNode(current1.val);
            //             tail = tail.next.next;
            //         }
            //     }
            //     else
            //     {
            //         tail.next = current1 != null ? new ListNode(current1.val) : new ListNode(current2.val);
            //         tail = tail.next;
            //     }
            //     
            //     current1 = current1?.next;
            //     current2 = current2?.next;
            // }

            return headCommon.next;
        }


        private static int[] LinkedListToArray(ListNode listNode)
        {
            var ints = new List<int>();
            var p = listNode;
            while (p != null)
            {
                ints.Add(p.val);
                p = p.next;
            }

            return ints.ToArray();
        }
    }
}