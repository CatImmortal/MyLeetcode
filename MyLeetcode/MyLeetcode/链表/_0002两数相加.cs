using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/add-two-numbers/

    class _0002两数相加
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode vtHead = new ListNode();  //虚拟头节点
            ListNode cur = vtHead;

            while (l1 != null || l2 != null)
            {
                int num1 = 0;
                int num2 = 0;
                if (l1 != null)
                {
                    num1 = l1.val;
                }

                if (l2 != null)
                {
                    num2 = l2.val;
                }

                //当前位与进位1相加 得的当前位的和
                int sum = num1 + num2;

                if (sum >= 10)
                {
                    //进位1
                    if (l1.next == null)
                    {
                        l1.next = new ListNode(1);
                    }
                    else
                    {
                        l1.next.val += 1;
                    }

                    sum %= 10;
                }


                ListNode newNode = new ListNode(sum);
                cur.next = newNode;
                cur = cur.next;
                l1 = l1?.next;
                l2 = l2?.next;
            }

            return vtHead.next;
        }
    }
}
