using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/minimum-absolute-difference-in-bst/

    class _0530二叉搜索树的最小绝对差
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        private int min = int.MaxValue;

        /// <summary>
        /// 前一次操作过的节点
        /// </summary>
        private TreeNode pre = null;

        public int GetMinimumDifference(TreeNode root)
        {
            InOrder(root);
            return min;
        }

        private void InOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left);

            if (pre != null)
            {
                //计算根节点与pre节点的差的绝对值
                int num = Math.Abs(root.val - pre.val);
                min = Math.Min(min, num);
            }

            pre = root;

            InOrder(root.right);
        }

    }
}
