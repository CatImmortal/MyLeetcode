using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.链表
{
    //https://leetcode-cn.com/problems/delete-node-in-a-linked-list/

    class _0273删除链表中的节点
    {

        public void DeleteNode(ListNode node)
        {
            //将下一个节点的值替换过来 然后删除下一个节点即可
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
