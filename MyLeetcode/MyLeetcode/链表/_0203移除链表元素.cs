using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/remove-linked-list-elements/

    class _0203移除链表元素
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

        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }

            //移除头节点的情况
            while (head != null && head.val == val)
            {
                head = head.next;
            }

            ListNode cur = head;
            while (cur != null && cur.next != null)
            {
                if (cur.next.val == val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }

            return head;
        }
    }
}
