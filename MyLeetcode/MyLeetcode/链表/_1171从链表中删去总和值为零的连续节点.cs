using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list/

    class _1171从链表中删去总和值为零的连续节点
    {
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


        public ListNode RemoveZeroSumSublists2(ListNode head)
        {
            ListNode dummyNode = new ListNode(0);
            dummyNode.next = head;

            //前缀和
            Dictionary<int, ListNode> prefixSumDic = new Dictionary<int, ListNode>();

            ListNode cur = dummyNode;
            int sum = 0;
            while (cur != null)
            {
                //建立前缀和与节点的映射
                //如果同一前缀和出现多次，就映射到最后一次出现的那个节点
                sum += cur.val;
                prefixSumDic[sum] = cur;
                cur = cur.next;
            }

            cur = dummyNode;
            sum = 0;
            while (cur != null)
            {
                //如果当前前缀和映射的节点不是cur节点，那么这一步会直接删除cur.next到当前前缀和映射的节点的所有节点
                sum += cur.val;
                cur.next = prefixSumDic[sum].next;  
                cur = cur.next;
            }

            return dummyNode.next;
        }
    }
}
