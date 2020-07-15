using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/swap-nodes-in-pairs/

    class _0024两两交换链表中的节点
    {

        public ListNode SwapPairs(ListNode head)
        {
            ListNode vtHead = new ListNode(-1);
            vtHead.next = head;

            ListNode prev = vtHead;
            ListNode cur = head;

            while (cur != null && cur.next != null)
            {
                ListNode node1 = cur;
                ListNode node2 = cur.next;

                //交换两个节点
                prev.next = node2;
                node1.next = node2.next;
                node2.next = node1;

                //移动到下下个节点
                prev = node1;
                cur = node1.next;
            }

            return vtHead.next;
        }
    }
}
