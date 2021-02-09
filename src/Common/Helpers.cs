using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Common
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
        
        public static int[] MakeArrayFromLinkedList(this ListNode listNode)
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
        
        public static void OutputInConsole(this int[] array, ITestOutputHelper output)
        {
            for (int j = 0; j < array.Length; j++)
            {
               output.WriteLine(array[j].ToString());
            }
        } 
    }
}