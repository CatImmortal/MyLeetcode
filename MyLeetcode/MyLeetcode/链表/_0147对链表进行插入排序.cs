using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/insertion-sort-list/

    class _0147对链表进行插入排序
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            InsertionSortListHelper(head);
            return head;
        }

        private void InsertionSortListHelper(ListNode head)
        {
            if (head.next == null)
            {
                return;
            }

            //对后续部分递归的插入排序
            InsertionSortListHelper(head.next);

            ListNode cur = head;
            while (cur.next != null)
            {
                //cur的值比next的值大 就交换
                if (cur.val > cur.next.val)
                {
                    int temp = cur.val;
                    cur.val = cur.next.val;
                    cur.next.val = temp;
                }

                cur = cur.next;
            }
        }

        public ListNode InsertionSortList2(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            ListNode prev = head;
            ListNode cur = head.next;

            while (cur != null)
            {
                if (cur.val < prev.val)
                {
                    //cur的值小于prev的值 就从头开始比对
                    ListNode temp = dummy;
                    while (temp.next.val < cur.val)
                    {
                        temp = temp.next;
                    }
                    //从头开始比对找到第一个值大于cur的节点temp.next 
                    //把cur插入到temp.next前边,即成为新的temp.next
                    prev.next = cur.next;
                    cur.next = temp.next;
                    temp.next = cur;
                    cur = prev.next;
                }
                else
                {
                    //移动双指针
                    prev = prev.next;
                    cur = cur.next;
                }

               
            }

            return dummy.next;
        }
    }
}
