using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/

    class _0104二叉树的最大深度
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftMaxDepth = MaxDepth(root.left);  //左子树最大深度
            int rightMaxDepth = MaxDepth(root.right);  //右子树最大深度
            int maxDepth = Math.Max(leftMaxDepth, rightMaxDepth) + 1;  //根节点最大深度
            return maxDepth;
        }
    }
}
