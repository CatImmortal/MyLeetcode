using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-preorder-traversal/

    class _0144二叉树的前序遍历
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        private List<int> result = new List<int>();

        public IList<int> PreorderTraversal(TreeNode root)
        {

            Preorder(root);
            return result;
        }

        private void Preorder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            result.Add(root.val);
            Preorder(root.left);
            Preorder(root.right);
        }

        
        public IList<int> PreorderTraversal2(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (root != null)
            {
                stack.Push(root);
            }


            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                result.Add(node.val);

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

            return result;


        }
    }
}
