﻿using System;
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

            ListNode p1 = dummyHead;
            bool isMove = true;
            while (p1 != null && p1.next != null)
            {
                ListNode p2 = p1.next;
                int sum = 0;
                while (p2 != null)
                {
                    sum += p2.val;
                    if (sum == 0)
                    {
                        p1.next = p2.next;
                        isMove = false;
                        break;
                    }
                    else
                    {
                        p2 = p2.next;
                    }
                }

                if (isMove)
                {
                    p1 = p1.next;
                }
                else
                {
                    isMove = true;
                }
                
            }

            return dummyHead.next;
            

        }


    }






}
