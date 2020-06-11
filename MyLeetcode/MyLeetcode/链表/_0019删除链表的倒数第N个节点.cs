using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/

    class _0019删除链表的倒数第N个节点
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //p1先走n步
            ListNode p1 = head;
            for (int i = 0; i < n; i++)
            {
                p1 = p1.next;
            }

            if (p1 == null)
            {
                //删除头节点的情况
                return head.next;
            }

            //然后两个指针一起走
            ListNode p2 = head;
            while (p1.next != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            //p1走到了头，此时p2刚好在倒数第n-1个节点上
            p2.next = p2.next.next;
            return head;
        }


    }
}
