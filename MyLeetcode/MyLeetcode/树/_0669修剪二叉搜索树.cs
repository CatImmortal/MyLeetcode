using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/trim-a-binary-search-tree/

    class _0669修剪二叉搜索树
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val > R)
            {
                //根节点值比右边界大 返回修剪后的左子树
                return TrimBST(root.left, L, R);
            }

            if (root.val < L)
            {
                //根节点值比左边界大 返回修剪后的右子树
                return TrimBST(root.right, L, R);
            }

            //否则两边都修剪
            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);
            return root;
        }
    }
}
