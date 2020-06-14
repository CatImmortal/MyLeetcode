using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/reverse-linked-list-ii/

    class _0092反转链表2
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            int counter = 0;
            ListNode cur = head;
            ListNode prev = null;
            ListNode startPrev = null;  //翻转开始前的翻转部分头节点的前一个节点
            ListNode endNext = null;  //翻转开始前的翻转部分尾节点的后一个节点
            ListNode newHead = null;  //翻转后的新头节点
            ListNode newTail = null;  //翻转后的新尾节点
            while (cur != null)
            {
                ListNode oldNext = cur.next;
                counter++;



                //在范围内了，需要翻转
                if (counter >= m && counter <= n)
                {
                    //翻转开始
                    if (counter == m)
                    {
                        startPrev = prev;
                        newTail = cur;
                    }

                    cur.next = prev;  //next指向前一个节点 实现链表翻转

                    //翻转结束
                    if (counter == n)
                    {
                        endNext = oldNext;
                        newHead = cur;

                        //处理指针关系 
                        if (startPrev != null)
                        {
                            startPrev.next = newHead;  //翻转后的新头节点的前一个节点是翻转前的头节点的前一个头节点
                        }

                        newTail.next = endNext;  //翻转后的尾节点的next会指向翻转前的尾节点的next
                    }
                }

                prev = cur;
                cur = oldNext;
            }

            if (m > 1)
            {
                return head;
            }

            return newHead;  //从第一个节点开始翻转的话，要返回翻转后的新头节点
        }
    }
}
