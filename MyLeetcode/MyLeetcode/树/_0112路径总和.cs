using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/path-sum/

    class _0112路径总和
    {

        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.left == null && root.right == null && sum == root.val)
            {
                //处理叶子节点
                return true;
            }

            bool left = HasPathSum(root.left, sum - root.val);
            bool right = HasPathSum(root.right, sum - root.val);

            return left || right;
        }

    }
}
