using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/reverse-linked-list/

    class _0206反转链表
    {

        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }


            ListNode curHead = head;
            ListNode cur = head;

            while (cur.next != null)
            {
                ListNode next = cur.next;
                ListNode nextNext = next.next;

                //将节点逐个移动到头节点
                next.next = curHead;  //下一节点的下一节点指向当前头节点
                curHead = next;  //更新当前头节点
                cur.next = nextNext;  //为当前节点重新指定下一节点
            }

            return curHead;

        }

        public ListNode ReverseList2(ListNode head)
        {
            if (head.next == null)
            {
                return head;    
            }

            ListNode newHead = ReverseList2(head.next);

            //让翻转后新链表的尾节点的.next指向自己
            head.next.next = head;

            //把自己的next置空
            head.next = null;

            return newHead;

        }

        public ListNode ReverseList3(ListNode head)
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
