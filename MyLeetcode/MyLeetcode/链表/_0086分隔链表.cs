using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/partition-list/

    class _0086分隔链表
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode Partition(ListNode head, int x)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode smallDummyHead = new ListNode(-1);  //<x的链表
            ListNode smallCur = smallDummyHead;

            ListNode bigDummyHead = new ListNode(-1);  //>=x的链表
            ListNode bigCur = bigDummyHead;

            ListNode cur = head;
            while (cur != null)
            {
                if (cur.val < x)
                {
                    smallCur.next = cur;
                    smallCur = smallCur.next;
                }
                else if (cur.val >= x)
                {
                    bigCur.next = cur;
                    bigCur = bigCur.next;
                }

                cur = cur.next;
            }

            //将小于x的链表 和 大于等于x的链表连接起来
            smallCur.next = bigDummyHead.next;
            bigCur.next = null;
            return smallDummyHead.next;
        }
    }
}
