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

            ListNode n1 = new ListNode(2);
            ListNode n2 = new ListNode(1);
            ListNode n3 = new ListNode(5);
            n1.next = n2;
            n2.next = n3;

            p.NextLargerNodes(n1);
        }


        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public int[] NextLargerNodes(ListNode head)
        {
            Stack<int> stack = new Stack<int>();
            List<int> data = new List<int>();
            List<int> res = new List<int>();

            int index = 0;
            ListNode cur = head;
            while (cur !=  null)
            {
                res.Add(0);
                data.Add(cur.val);

                while (stack.Count > 0 && cur.val > data[stack.Peek()])
                {
                    //如果当前节点的值大于栈顶索引处节点的值
                    //就更新res对应索引处的值
                    res[stack.Pop()] = cur.val;
                }

                stack.Push(index);  //将下标存进栈里
                index++;
                cur = cur.next;
            }

            return res.ToArray();
        }

    }






}
