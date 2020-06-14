using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    class _1290二进制链表转整数
    {
        //https://leetcode-cn.com/problems/convert-binary-number-in-a-linked-list-to-integer/

        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public int GetDecimalValue(ListNode head)
        {
            head = ReverseList(head);
            ListNode cur = head;
            int sum = 0;
            int power = 0;
            while (cur != null)
            {
                sum += cur.val * ((int)Math.Pow(2, power));

                power++;
                cur = cur.next;
            }
            return sum;
        }

        private ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;

        }
    }
}
