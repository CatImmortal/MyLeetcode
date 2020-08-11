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
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                if (CheckList(head,node))
                {
                    return true;
                }

                if (node.right != null)
                {
                    stack.Push(node.right);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                }
                
            }

            return false;
            
        }

        /// <summary>
        /// 检查root为根的子树中是否存在一条与head相同的路径
        /// </summary>
        private bool CheckList(ListNode head,TreeNode root)
        {
            if (root == null && head == null)
            {
                return true;
            }

            if (root == null || head == null)
            {
                return false;
            }

            if (root.val != head.val)
            {
                return false;
            }

            return CheckList(head.next, root.left) || CheckList(head.next, root.right);
            
        }
    }
}
