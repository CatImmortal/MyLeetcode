using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/next-greater-node-in-linked-list/

    class _1019链表中的下一个更大节点
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        public int[] NextLargerNodes(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return new int[1];
            }

            ListNode cur = head;
            int count = 0;

            while (cur != null)
            {
                count++;
                cur = cur.next;
            }

            int[] result = new int[count];

            cur = head;
            count = 0;
            while (cur.next != null)
            {
                result[count] = 0;  //默认为0
                ListNode cur2 = cur.next;

                while (cur2 != null)
                {

                    if (cur2.val > cur.val)
                    {
                        //找到了第一个大于cur.val的值
                        result[count] = cur2.val;
                        break;
                    }
                    cur2 = cur2.next;
                }

                count++;
                cur = cur.next;
            }

            return result;


        }

        public int[] NextLargerNodes2(ListNode head)
        {
            //单调栈解法

            Stack<int> stack = new Stack<int>();  //栈中保存的index是暂时没有下一个更大节点的元素的索引
            List<int> data = new List<int>();
            List<int> res = new List<int>();

            int index = 0;
            ListNode cur = head;
            while (cur != null)
            {
                res.Add(0);
                data.Add(cur.val);

                while (stack.Count > 0 && cur.val > data[stack.Peek()])
                {
                    //如果当前节点的值大于栈顶索引处节点的值
                    //就更新res对应索引处的值
                    //然后出栈栈顶索引 继续比较
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
