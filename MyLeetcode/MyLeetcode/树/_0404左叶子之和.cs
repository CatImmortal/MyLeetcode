using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{//https://leetcode-cn.com/problems/sum-of-left-leaves/

    class _0404左叶子之和
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        private int ans = 0;

        public int SumOfLeftLeaves(TreeNode root)
        {
            PreOrder(root);
            return ans;
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            if (root.left != null && root.left.left == null && root.left.right == null)
            {
                ans += root.left.val;
            }

            PreOrder(root.left);
            PreOrder(root.right);
        }
    }
}
