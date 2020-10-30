using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/intersection-of-two-linked-lists/

    class _160相交链表
    {

    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null)
        {
            return null;
        }

        //双指针分别指向两个链表头部
        ListNode pA = headA;
        ListNode pB = headB;

        while (pA != pB)
        {
            if (pA == null)
            {
                //走到头了就放到另一个链表头部
                pA = headB;
            }
            else
            {
                //否则继续往下走
                pA = pA.next;
            }

            if (pB == null)
            {
                pB = headA;
            }
            else
            {
                pB = pB.next;
            }
        }

        //双指针相等时，要么是在相交结点处，要么两个都为null，不想交

        return pA;

    }
    }
}
