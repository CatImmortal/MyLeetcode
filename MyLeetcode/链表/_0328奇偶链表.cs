using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/odd-even-linked-list/

    class _0328奇偶链表
    {

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return head;
            }

            ListNode headNext = head.next;
            ListNode cur = head;

            int count = 1;
            ListNode temp = null;
            while (cur != null && cur.next != null)
            {
                ListNode next = cur.next;
                cur.next = cur.next.next;
                temp = cur;
                cur = next;
                count++;
            }

            //此时的cur为尾节点
            if (count % 2 == 1)
            {
                //节点个数为奇数时 将尾节点的next指向第2个节点
                cur.next = headNext;
            }
            else
            {
                //节点个数为偶数时 将尾节点的前一个节点(奇数节点)的next指向第2个节点
                temp.next = headNext;
            }


            return head;
        }

        public ListNode OddEvenList2(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode odd = head;  //奇节点链表指针
            ListNode even = head.next;  //偶节点链表指针

            ListNode evenHead = even;  //偶节点链表头指针

            while (even!=null && even.next != null)
            {
                //将奇节点收集到一个链表里
                odd.next = even.next;  //奇节点链表的next就是偶节点的next
                odd = odd.next;  //奇节点指针移动 此时该指针在当前偶节点的next处

                //将偶节点收集到一个链表里
                even.next = odd.next;  //偶节点链表的next就是移动后的奇节点的next
                even = even.next;  //偶节点指针移动  此时该指针在移动后的奇节点的next处
            }

            //最后将奇节点链表尾部和偶节点链表头部连接起来
            odd.next = evenHead;
            return head;
        }
    }
}
