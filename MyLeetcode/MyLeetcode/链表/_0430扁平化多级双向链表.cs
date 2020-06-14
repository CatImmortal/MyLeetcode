using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/flatten-a-multilevel-doubly-linked-list/

    class _0430扁平化多级双向链表
    {
        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;

            public Node(int val)
            {
                this.val = val;
            }
        }

        public Node Flatten(Node head)
        {
            if (head == null)
            {
                return head;
            }

            FlattenHelper(head);
            return head;
        }

        /// <summary>
        /// 扁平化头节点对应的链表后返回该链表尾结点
        /// </summary>
        private Node FlattenHelper(Node head)
        {
            Node cur = head;
            Node prev = null;  //方便返回尾节点
            while (cur != null)
            {
                Node oldNext = cur.next;

                if (cur.child != null)
                {
                    Node tail = FlattenHelper(cur.child);
                    cur.next = cur.child;  //让next指向child
                    cur.child.prev = cur;
                    cur.child = null;
                    tail.next = oldNext;  //让child对应链表的尾节点的next指向原来的next
                    if (oldNext != null)
                    {
                        oldNext.prev = tail;
                    }

                }

                prev = cur;
                cur = cur.next;
            }



            return prev;
        }
    }
}
