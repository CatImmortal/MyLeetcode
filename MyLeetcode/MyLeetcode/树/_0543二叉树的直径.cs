using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/diameter-of-binary-tree/

    class _0543二叉树的直径
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        int maxNodeCount = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            maxNodeCount = 1;  //路径经过的节点数
            PostOrder(root);
            return maxNodeCount - 1;  //-1就是长度了
        }

        private int PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            //获取左右子树深度
            int left = PostOrder(root.left);
            int right = PostOrder(root.right);

            //计算穿过根节点的最长路径经过的节点数
            int nodeCount = left + right + 1;  

            //对比最大的路径穿过节点数
            maxNodeCount = Math.Max(this.maxNodeCount, nodeCount);

            //返回根节点深度
            return Math.Max(left, right) + 1;
        }
    }
}
