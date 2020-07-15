using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-postorder-traversal/

    class _0145二叉树的后序遍历
    {

        private List<int> result = new List<int>();

        public IList<int> PostorderTraversal(TreeNode root)
        {

            Postorder(root);
            return result;
        }

        private void Postorder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Postorder(root.left);
            Postorder(root.right);
            result.Add(root.val);
        }

        public IList<int> PostorderTraversal2(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (root != null)
            {
                stack.Push(root);
            }

            //前一次遍历到的节点
            TreeNode prev = null;

            while (stack.Count > 0)
            {
                TreeNode node = stack.Peek();

                if (
                    (node.left == null && node.right == null)
                    ||(prev != null &&(prev == node.left || prev == node.right))
                    )
                {
                    //当前节点没有子节点
                    //或者 当前节点的左子节点和右子节点被遍历过了
                    //就遍历当前节点
                    stack.Pop();
                    result.Add(node.val);
                    prev = node;
                }
                else
                {
                    //否则依次将当前节点的右子节点和左子节点入栈
                    //保证左子节点在右子节点前被遍历，右子节点在当前节点前被遍历
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }
                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                }
            }

            return result;

            //总结 非递归前序遍历的变形
            //在遍历当前节点前加个判断 不能直接遍历 要等子节点都被遍历后才可以
        }
    }
}
