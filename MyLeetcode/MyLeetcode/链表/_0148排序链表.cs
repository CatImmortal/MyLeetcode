using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/sort-list/

    class _0148排序链表
    {

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            int len = ListNodeLength(head);

            ListNode dummy = new ListNode(-1);
            dummy.next = head;

            for (int i = 1; i < len; i *= 2)
            {
                ListNode tail = dummy;  //上一次完成合并后的链表的尾部
                ListNode cur = dummy.next;

                while (cur != null)
                {
                    ListNode left = cur;
                    ListNode right = Split(left, i);// left->@->@ right->@->@->@...
                    cur = Split(right, i);  // left->@->@ right->@->@  cur->@->...
                    ListNode mergedHead = MergeTwoLists(left, right);  
                    tail.next = mergedHead;//将tail与这次合并后的链表的头节点连接
                    while (tail.next != null)
                    {
                        //最后保持tail为这次合并后链表的尾部
                        tail = tail.next;
                    }
                }
            }

            return dummy.next;
        }

        /// <summary>
        /// 获取链表的长度
        /// </summary>
        private int ListNodeLength(ListNode head)
        {
            int length = 0;
            ListNode curr = head;

            while (curr != null)
            {
                length++;
                curr = curr.next;
            }

            return length;
        }

        /// <summary>
        /// 将head链表的前step个节点与后续节点分割开 返回分割后后续部分的链表头
        /// </summary>
        private ListNode Split(ListNode head, int step)
        {
            if (head == null) return null;
            ListNode cur = head;
            for (int i = 1; cur.next != null && i < step; i++)
            {
                cur = cur.next;
            }

            ListNode newHead = cur.next;
            cur.next = null;
            return newHead;
        }

        private ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead;
            while (l1 != null && l2 != null)
            {
                //两条链表谁的当前元素值小就让prev的next指向谁
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }

            // 合并后 l1 和 l2 最多只有一个还未被合并完，我们直接将链表末尾指向未合并完的链表即可
            prev.next = l1 == null ? l2 : l1;

            return prehead.next;
        }
    }
}
