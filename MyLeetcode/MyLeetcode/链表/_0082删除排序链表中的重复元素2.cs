using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/

    class _0082删除排序链表中的重复元素2
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode dummyHead = new ListNode(-1);
            dummyHead.next = head;

            ListNode cur = dummyHead;
            while (cur.next != null && cur.next.next != null)
            {
                //出现重复节点
                if (cur.next.val == cur.next.next.val)
                {
                    //寻找下一个不重复的节点
                    ListNode cur2 = cur.next.next.next;
                    while (cur2 != null)
                    {
                        if (cur.next.val != cur2.val)
                        {
                            break;
                        }

                        cur2 = cur2.next;
                    }

                    //后面全是重复节点
                    cur.next = cur2;
                }
                else
                {
                    cur = cur.next;
                }
            }


            return dummyHead.next;
        }
    }
}
