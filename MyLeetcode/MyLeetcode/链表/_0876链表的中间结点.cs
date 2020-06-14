using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    class _0876链表的中间结点
    {
        //https://leetcode-cn.com/problems/middle-of-the-linked-list/

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode MiddleNode(ListNode head)
        {
            ListNode p1 = head;
            ListNode p2 = head;
            while (p2 != null && p2.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;
            }

            return p1;
        }

    }
}
