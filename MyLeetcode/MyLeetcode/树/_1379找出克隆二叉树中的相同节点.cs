using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/find-a-corresponding-node-of-a-binary-tree-in-a-clone-of-that-tree/

    class _1379找出克隆二叉树中的相同节点
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            stack1.Push(original);
            stack2.Push(cloned);

            while (stack1.Count != 0)
            {
                TreeNode node1 = stack1.Pop();
                TreeNode node2 = stack2.Pop();

                if (node1 == target && node2.val == target.val)
                {
                    return node2;
                }

                if (node1.right != null)
                {
                    stack1.Push(node1.right);
                    stack2.Push(node2.right);
                }

                if (node1.left != null)
                {
                    stack1.Push(node1.left);
                    stack2.Push(node2.left);
                }
            }

            return null;
        }
    }
}
