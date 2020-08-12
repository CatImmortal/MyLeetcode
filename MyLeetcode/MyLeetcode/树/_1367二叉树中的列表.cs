using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/linked-list-in-binary-tree/

    class _1367二叉树中的列表
    {
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (root == null)
            {
                return false;
            }

            return PreOrder(root, head) || IsSubPath(head, root.left) || IsSubPath(head, root.right);

        }

        private bool PreOrder(TreeNode root, ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            if (root == null)
            {
                return false;
            }

            if (root.val != head.val)
            {
                return false;
            }

            return PreOrder(root.left, head.next) || PreOrder(root.right, head.next);
        }
    }

}
