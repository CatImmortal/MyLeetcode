using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/linked-list-cycle/

    class _0141环形链表
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

        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            ListNode p1 = head;
            ListNode p2 = head;
            while (p2.next != null && p2.next.next != null)
            {
                //双指针分别以步长1和步长2前进，如果相遇了就说明有环
                p1 = p1.next;
                p2 = p2.next.next;
                if (p1 == p2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
