using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    class _0445两数相加2
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> stack1 = new Stack<int>();
            ListNode cur = l1;
            while (cur != null)
            {
                stack1.Push(cur.val);
                cur = cur.next;
            }

            Stack<int> stack2 = new Stack<int>();
            cur = l2;
            while (cur != null)
            {
                stack2.Push(cur.val);
                cur = cur.next;
            }

            int carry = 0;  //进位
            ListNode head = null;
            while (stack1.Count != 0 || stack2.Count != 0 || carry != 0)
            {
                int a = 0;
                if (stack1.Count > 0)
                {
                    a = stack1.Pop();
                }
                int b = 0;
                if (stack2.Count > 0)
                {
                    b = stack2.Pop();
                }

                int sum = a + b + carry;
                carry = sum / 10;  //计算进位
                sum %= 10;  //进位后的值
                ListNode node = new ListNode(sum);
                node.next = head;
                head = node;
            }

            return head;
        }
    }
}
