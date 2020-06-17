using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/add-two-numbers/

    class _0002两数相加
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p1 = l1;
            ListNode p2 = l2;
            ListNode cur = dummyHead;

            int carry = 0;  //进位
            while (p1 != null || p2 != null)
            {
                int x = 0;
                int y = 0;
                if (p1 != null)
                {
                    x = p1.val;
                }
                if (p2 != null)
                {
                    y = p2.val;
                }
                int sum = carry + x + y;
                carry = sum / 10;

                cur.next = new ListNode(sum % 10);
                cur = cur.next;

                //其中一个链表已经遍历完了 就会为null 此时仍然需要遍历剩下那个
                if (p1 != null)
                {
                    p1 = p1.next;
                }
                if (p2 != null)
                {
                    p2 = p2.next;
                }
            }

            if (carry > 0)
            {
                cur.next = new ListNode(carry);
            }

            return dummyHead.next;
        }
    }
}
