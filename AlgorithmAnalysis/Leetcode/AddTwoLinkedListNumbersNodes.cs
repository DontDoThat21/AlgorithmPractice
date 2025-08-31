using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Algorithms.Leetcode
{
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

    public static class AddTwoLinkedListNumbersNodes
    {
        /// <summary>
        /// Adds two non-negative integers represented by two singly-linked lists and returns the sum as a linked list.
        /// Each list stores digits in reverse order (least significant digit first), and each node contains a single digit.
        /// </summary>
        /// <param name="l1">Head of the first number's list; digits are in reverse order.</param>
        /// <param name="l2">Head of the second number's list; digits are in reverse order.</param>
        /// <returns>Head of a new linked list representing the sum, with digits in reverse order.</returns>
        /// <remarks>
        /// - Handles lists of different lengths and a final carry.
        /// - Time complexity: O(max(m, n)); Space complexity: O(max(m, n)) for the output list.
        /// - Example: (2 -> 4 -> 3) + (5 -> 6 -> 4) = (7 -> 0 -> 8).
        /// </remarks>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1;
            ListNode q = l2;
            ListNode curr = dummyHead;
            int carry = 0;

            // Iterate while there are digits to process or a remaining carry.
            while (p != null || q != null || carry != 0)
            {
                int x = p != null ? p.val : 0; // current digit from l1
                int y = q != null ? q.val : 0; // current digit from l2
                int sum = x + y + carry;         // sum of digits plus carry over value to next index

                carry = sum / 10;                // compute next carry over
                curr.next = new ListNode(sum % 10); // create node for current digit
                curr = curr.next;

                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }

            return dummyHead.next;
        }
    }
}
