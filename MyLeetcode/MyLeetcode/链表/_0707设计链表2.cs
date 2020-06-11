using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/design-linked-list/


    public class MyLinkedList2
    {
        private class Node
        {
            public int value;
            public Node next;
            public Node prev;

            public Node()
            {

            }

            public Node(int value)
            {
                this.value = value;
            }
        }

        private Node head;
        private Node tail;

        private int count;

        /** Initialize your data structure here. */
        public MyLinkedList2()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index < 0 || index >= count)
            {
                return -1;
            }

            Node cur = head;
            for (int i = 0; i < index; i++)
            {
                cur = cur.next;
            }
            return cur.value;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            Node newHead = new Node(val);

            newHead.next = head;

            if (head != null)
            {
                head.prev = newHead;
            }
            else
            {
                tail = newHead;
            }


            head = newHead;

            count++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            if (count == 0)
            {
                AddAtHead(val);
                return;
            }

            Node newTail = new Node(val);

            tail.next = newTail;
            newTail.prev = tail;

            tail = newTail;

            count++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index > count)
            {
                return;
            }

            if (index <= 0)
            {
                AddAtHead(val);
                return;
            }

            if (index == count)
            {
                AddAtTail(val);
                return;
            }


            Node cur = head;
            for (int i = 0; i < index; i++)
            {
                cur = cur.next;
            }

            Node newNode = new Node(val);
            Node prev = cur.prev;

            cur.prev = newNode;

            newNode.prev = prev;
            newNode.next = cur;

            prev.next = newNode;

            count++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                return;
            }

            if (index == 0)
            {
                //删除头节点
                head = head.next;

                if (head != null)
                {
                    head.prev = null;
                }
                else
                {
                    tail = null;
                }

                count--;



                return;
            }

            if (index == count - 1)
            {
                //删除尾节点
                tail = tail.prev;
                tail.next = null;

                count--;
                return;
            }

            Node cur = head;
            for (int i = 0; i < index; i++)
            {
                cur = cur.next;
            }

            Node prev = cur.prev;
            Node next = cur.next;

            prev.next = next;
            next.prev = prev;



            count--;
        }
    }

    /**
     * Your MyLinkedList object will be instantiated and called as such:
     * MyLinkedList obj = new MyLinkedList();
     * int param_1 = obj.Get(index);
     * obj.AddAtHead(val);
     * obj.AddAtTail(val);
     * obj.AddAtIndex(index,val);
     * obj.DeleteAtIndex(index);
     */
}
