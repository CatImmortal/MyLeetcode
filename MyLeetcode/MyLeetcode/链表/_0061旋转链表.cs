using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/rotate-list/

    class _0061旋转链表
    {

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            //先计算链表长度
            int count = 0;
            ListNode cur = head;
            while (cur != null)
            {
                count++;
                cur = cur.next;
            }

            //取模得到实际右移次数
            int num = k % count;

            ListNode newHead = head;
            for (int i = 0; i < num; i++)
            {
                //不断执行右移一步的操作
                newHead = RotateRightOne(newHead);
            }
            return newHead;
        }

        /// <summary>
        /// 链表向右移动一步
        /// </summary>
        public ListNode RotateRightOne(ListNode head)
        {
            ListNode p1 = head;

            //首先取到尾节点前一个节点
            while (p1.next.next != null)
            {
                p1 = p1.next;
            }

            ListNode tail = p1.next;
            p1.next = null;  //尾节点前一个节点作为新的尾节点
            tail.next = head;  //尾节点放到头部
            return tail;
        }

        public ListNode RotateRight2(ListNode head, int k)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode cur = head;
            int count = 1;
            while (cur.next != null)
            {
                cur = cur.next;
                count++;
            }

            ListNode oldTail = cur;
            oldTail.next = head;  //使链表闭环

            //找到新的尾节点
            //新的尾节点在是第count - k个节点
            cur = head;
            for (int i = 1; i < count - (k % count); i++)
            {
                cur = cur.next;
            }
            ListNode newTail = cur;

            //新的头节点是新的尾节点的next
            ListNode newHead = newTail.next;

            //断开环
            newTail.next = null;

            return newHead;
        }
    }
}
