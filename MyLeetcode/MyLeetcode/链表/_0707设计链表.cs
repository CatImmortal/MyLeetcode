using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/design-linked-list/

    public class MyLinkedList
    {
        private class Node
        {
            public int value;
            public Node next;

            public Node()
            {

            }

            public Node(int value)
            {
                this.value = value;
            }
        }

        private Node head;

        private int count;

        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            head = null;
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
            Node oldHead = head;
            head = new Node(val);
            head.next = oldHead;
            count++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            Node cur = head;
            while (cur.next != null)
            {
                cur = cur.next;
            }
            cur.next = new Node(val);
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
            for (int i = 0; i < index - 1; i++)
            {
                cur = cur.next;
            }

            Node next = cur.next;
            Node node = new Node(val);
            cur.next = node;
            node.next = next;

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
                head = head.next;
                count--;
                return;
            }

            Node cur = head;
            for (int i = 0; i < index - 1; i++)
            {
                cur = cur.next;
            }
            cur.next = cur.next?.next;
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
