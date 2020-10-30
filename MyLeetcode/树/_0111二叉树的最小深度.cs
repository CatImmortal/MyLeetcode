using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/minimum-depth-of-binary-tree/

    class _0111二叉树的最小深度
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public int MinDepth(TreeNode root)
        {

            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                return 1;
            }

            int leftMinDepth = int.MaxValue;
            int rightMinDepth = int.MaxValue;

            if (root.left != null)
            {
                leftMinDepth = MinDepth(root.left);  //左子树最小深度
            }

            if (root.right != null)
            {
                rightMinDepth = MinDepth(root.right);  //右子树最小深度
            }


            int minDepth = Math.Min(leftMinDepth, rightMinDepth) + 1;  //根节点最小深度
            return minDepth;
        }


        int ans = int.MaxValue;
        public int MinDepth2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            MinDepth2Helper(root, 1);
            return ans;
        }

        public void MinDepth2Helper(TreeNode root,int depth)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null && depth < ans)
            {
                //是叶子节点 对比最小深度值
                ans = depth;
            }

            MinDepth2Helper(root.left,depth + 1);
            MinDepth2Helper(root.right, depth + 1);
        }
    }
}
