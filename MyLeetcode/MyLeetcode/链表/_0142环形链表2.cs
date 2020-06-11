using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/linked-list-cycle-ii

    class _0142环形链表2
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

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode p1 = head;
            ListNode p2 = head;
            bool hasCycle = false;
            while (p2.next != null && p2.next.next != null)
            {
                //双指针分别以步长1和步长2前进，如果相遇了就说明有环
                p1 = p1.next;
                p2 = p2.next.next;
                if (p1 == p2)
                {
                    hasCycle = true;
                    break;
                }
            }

            if (hasCycle)
            {
                //有环 p1放回起点 
                //两个指针重新以步长1开始跑 会和p2再次相遇在入环点
                p1 = head;
                while (p1 != p2)
                {
                    p1 = p1.next;
                    p2 = p2.next;
                }
                return p1;
            }

            return null;
        }
    }
}
