using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-inorder-traversal/

    class _0094二叉树的中序遍历
    {
        private List<int> result = new List<int>();

        public IList<int> InorderTraversal(TreeNode root)
        {

            Inorder(root);
            return result;
        }

        private void Inorder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.left);
            result.Add(root.val);
            Inorder(root.right);
        }

        public IList<int> InorderTraversal2(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode node = root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    //不断push left进去 一直push到头
                    stack.Push(node);
                    node = node.left;
                }

                if (stack.Count > 0)
                {
                    //push到头了 取一个出来操作 然后node转移到node.right上
                    node = stack.Pop();
                    result.Add(node.val);
                    node = node.right;
                }
            }

            return result;

        }
    }
}
