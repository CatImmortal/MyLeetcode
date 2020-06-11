using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    class _0234回文链表
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            ListNode firstHalfEnd = EndOfFirstHalf(head);  //链表前半部分的尾节点
            ListNode secondHalfStart = ReverseList(firstHalfEnd.next);  //链表后半部分反转后的头结点

            ListNode p1 = head;
            ListNode p2 = secondHalfStart;
            bool result = true;

            //逐个比对前半部分和反转过的后半部分
            while (result && p2 != null)
            {
                if (p1.val != p2.val)
                {
                    //有不同的 不是回文
                    result = false;
                }
                p1 = p1.next;
                p2 = p2.next;
            }

            //把后半部分反转回来
            firstHalfEnd.next = ReverseList(secondHalfStart);

            return result;
        }

        /// <summary>
        /// 反转链表
        /// </summary>
        private ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;
        }

        /// <summary>
        /// 找到链表前半部分的尾节点
        /// </summary>
        private ListNode EndOfFirstHalf(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
