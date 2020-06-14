using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/merge-k-sorted-lists/

    class _0023合并k个排序链表
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }



        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            if (lists.Length == 1)
            {
                return lists[0];
            }

            ListNode list = lists[0];
            for (int i = 1; i < lists.Length; i++)
            {
                list = MergeTwoLists(list, lists[i]);
            }
            return list;
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
