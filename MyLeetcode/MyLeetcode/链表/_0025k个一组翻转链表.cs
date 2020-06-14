using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/reverse-nodes-in-k-group/

    class _0025k个一组翻转链表
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 1)
            {
                return head;
            }

            int counter = 0;

            ListNode cur = head;
            ListNode curHead = head;  //下次需要翻转的部分的头节点
            ListNode curTail = null;  //下次需要翻转的部分的尾节点
            ListNode prevTail = null;  //前一次翻转后的新尾节点
            ListNode returnHead = head;
            while (cur != null)
            {
                counter++;
                ListNode oldNext = cur.next;
                if (counter == k)
                {
                    counter = 0;

                    //开始翻转部分链表
                    curTail = cur;
                    ReverseList(oldNext, curHead, curTail);  //翻转后的新尾节点的next会指向oldNext
                    if (returnHead == head)
                    {
                        returnHead = curTail;  //第一次翻转后的新头节点要作为返回值
                    }
                    if (prevTail != null)
                    {
                        prevTail.next = curTail;  ////翻转后的新头节点的前一个节点会是前一次翻转后的新尾节点
                    }
                    prevTail = curHead;  //更新前一次翻转后的尾节点
                    curHead = oldNext;  //更新下次需要翻转的链表的头节点
                }

                cur = oldNext;
            }
            return returnHead;
        }

        /// <summary>
        /// 翻转从head到tail范围的链表，返回翻转后的新头节点
        /// </summary>
        private ListNode ReverseList(ListNode prev, ListNode head, ListNode tail)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode curr = head;
            while (prev != tail)
            {
                ListNode oldNext = curr.next;
                curr.next = prev;
                prev = curr;
                curr = oldNext;
            }

            return prev;

        }
    }
}
