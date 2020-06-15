using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    class _0725分隔链表
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode[] SplitListToParts(ListNode root, int k)
        {
            if (root == null)
            {
                return new ListNode[k];
            }

            ListNode[] dummyHeads = new ListNode[k];
            for (int i = 0; i < k; i++)
            {
                dummyHeads[i] = new ListNode(-1);
            }

            int length = 0;
            ListNode cur = root;
            while (cur != null)
            {
                length++;
                cur = cur.next;
            }

            int count = length / k;  //平分下来的数量
            int mod = length % k;  //多出来的部分
            cur = root;

            for (int i = 0; i < k; i++)
            {
                ListNode tail = dummyHeads[i];
                for (int j = 0; j < count && cur != null; j++)
                {
                    tail.next = cur;
                    tail = cur;
                    cur = cur.next;
                }

                //多出来的部分优先加到前面的链表上
                if (mod > 0)
                {
                    tail.next = cur;
                    tail = cur;
                    cur = cur.next;
                    mod--;
                }

                //切断链表
                tail.next = null;
            }

            for (int i = 0; i < k; i++)
            {
                dummyHeads[i] = dummyHeads[i].next;
            }

            return dummyHeads;

        }
    }
}
