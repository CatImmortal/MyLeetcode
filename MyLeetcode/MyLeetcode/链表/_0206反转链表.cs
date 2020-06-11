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
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

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
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode node = ReverseList2(head.next);

            //让next节点的next指向自己 这里不能是node.next，因为此时node表示新的头节点
            head.next.next = head;

            //将自己的next置空，这样会让原本头节点的next为null
            head.next = null;

            //最后返回新的头节点
            return node;

        }
    }

}
