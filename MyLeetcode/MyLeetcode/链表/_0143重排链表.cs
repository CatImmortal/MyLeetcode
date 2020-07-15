using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/reorder-list/

    class _0143重排链表
    {


        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return;
            }


            ListNode p1 = head;
            ListNode p2 = head;
            while (p2 != null && p2.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;
            }

            //把后半部分扔进栈里
            ListNode mid = p1;
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode cur = mid;
            while (cur != null)
            {
                stack.Push(cur);
                ListNode next = cur.next;
                cur.next = null;  //断开后半部分各个节点之间的连接
                cur = next;
            }

            //将后半部分倒着取出
            cur = head;

            while (stack.Count > 0)
            {
                ListNode node = stack.Pop();
                if (cur.next != node)
                {
                    node.next = cur.next;
                }

                if (cur != node)
                {
                    cur.next = node;
                }
                cur = node.next;
            }
        }

        public void ReorderList2(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return;
            }

            ListNode p1 = head;
            ListNode p2 = head;
            ListNode prev = null;
            while (p2 != null)
            {
                prev = p1;
                p1 = p1.next;
                p2 = p2.next?.next;
            }

            prev.next = null;  //断开前半部分和后半部分的连接

            ListNode mid = ReverseList(p1);  //反转后半部分

            while (mid != null)  //后半部分一定和前半部分节点数相等或更少
            {
                ListNode headNext = head.next;
                ListNode midNext = mid.next;


                mid.next = head.next;
                head.next = mid;

                head = headNext;
                mid = midNext;

            }


        }

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
    }
}
