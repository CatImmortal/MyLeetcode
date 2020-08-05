using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/check-completeness-of-a-binary-tree/

    class _0958二叉树的完全性检验
    {
        public bool IsCompleteTree(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (root != null)
            {
                stack.Push(root);
            }


            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                if (node.left == null && node.right != null)
                {
                    //有右子节点但没有左子节点 返回false
                    return false;
                }

                //pop root后先push right，再push left，以实现前序遍历

                if (node.right != null)
                {
                    stack.Push(node.right);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                }

            }

            return true;


        }
    }
}
