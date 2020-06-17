using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/linked-list-components/

    class _0817链表组件
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public int NumComponents(ListNode head, int[] G)
        {
            HashSet<int> set = new HashSet<int>(G);

            int num = 0;
            ListNode cur = head;

            while (cur != null)
            {
                //当前节点在g里 但是next为null或者next不在g里 就增加num
                if (set.Contains(cur.val) && (cur.next == null || !set.Contains(cur.next.val)))
                {
                    num++;
                }

                cur = cur.next;
            }

            return num;
        }
    }
}
