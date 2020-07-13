using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/longest-univalue-path/

    class _0687最长同值路径
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        int ans = 0;

        public int LongestUnivaluePath(TreeNode root)
        {
            ArrowLength(root);
            return ans;
        }

        private int ArrowLength(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            //左箭头长度
            int left = ArrowLength(root.left);

            //右箭头长度
            int right = ArrowLength(root.right);

            int arrowLeft = 0;
            int arrowRight = 0;
            if (root.left != null && root.left.val == root.val)
            {
                //根节点值等于左子节点值 左箭头长度+1
                arrowLeft = left + 1;
            }

            if (root.right != null && root.right.val == root.val)
            {
                //根节点值等于右子节点值 右箭头长度+1
                arrowRight = right + 1;
            }

            ans = Math.Max(ans, arrowLeft + arrowRight);

            return Math.Max(arrowLeft, arrowRight);




        }
    }
}
