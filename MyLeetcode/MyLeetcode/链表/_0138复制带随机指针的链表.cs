using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/copy-list-with-random-pointer/

    class _0138复制带随机指针的链表
    {

        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return head;
            }

            Node vtHead = new Node(0);
            Node p1 = vtHead;
            Node p2 = head;

            //先进行一次深拷贝
            while (p2 != null)
            {
                Node newNode = new Node(p2.val);
                p1.next = newNode;
                p1 = p1.next;
                p2 = p2.next;
            }

            //处理random指针
            p1 = vtHead.next;
            p2 = head;
            while (p2 != null)
            {
                if (p2.random != null)
                {
                    //根据对应的p2节点random信息
                    //处理p1节点的random
                    Node randomNode = GetNodeByNode(p2.random, head, vtHead.next);
                    p1.random = randomNode;
                }

                p1 = p1.next;
                p2 = p2.next;

            }

            return vtHead.next;
        }

        /// <summary>
        /// 根据节点获取另一个链表中的节点
        /// </summary>
        private Node GetNodeByNode(Node node, Node head1, Node head2)
        {
            Node p1 = head1;
            Node p2 = head2;

            while (p1 != null)
            {
                if (p1 == node)
                {
                    return p2;
                }

                p1 = p1.next;
                p2 = p2.next;
            }

            return null;
        }

        public Node CopyRandomList2(Node head)
        {
            if (head == null)
            {
                return null;
            }

            //深拷贝的节点放在原来被拷贝的节点后面
            Node cur = head;
            while (cur != null)
            {
                Node newNode = new Node(cur.val);
                newNode.next = cur.next;
                cur.next = newNode;
                cur = newNode.next;
            }

            //根据旧节点的random来处理新节点的random
            cur = head;
            while (cur != null)
            {
                if (cur.random != null)
                {
                    cur.next.random = cur.random.next;
                }

                cur = cur.next.next;
            }

            //拆开新旧链表
            cur = head;
            Node newHead = head.next;

            while (cur.next != null)
            {
                Node next = cur.next;

                cur.next = cur.next.next;  //断开新旧链表节点间的引用

                cur = next;
            }

            return newHead;
        }
    }
}
