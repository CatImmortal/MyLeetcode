using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode
{

    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            ListNode n1 = new ListNode(1);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(2);
            ListNode n4 = new ListNode(3);
            ListNode n5 = new ListNode(4);
            ListNode n6 = new ListNode(4);
            ListNode n7 = new ListNode(5);
            n1.next = n2;
            n2.next = n3;
            //n3.next = n4;
            //n4.next = n5;
            //n5.next = n6;
            //n6.next = n7;



        }


        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            ListNode dummyHead = new ListNode(-1);
            dummyHead.next = head;
            ListNode cur = dummyHead;
            while (cur.next != null && cur.next.next!= null)
            {
                //连续两个节点总和为0 就删掉
                if (cur.next.val + cur.next.next.val == 0)
                {
                    cur.next = cur.next.next.next;
                }
                else
                {
                    //否则后移指针
                    cur = cur.next;
                }
            }
            return dummyHead.next;
        }


    }






}
