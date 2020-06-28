using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/univalued-binary-tree/

    class _0965单值二叉树
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }



        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            if (root.left != null && root.val != root.left.val)
            {
                return false;
            }

            if (root.right != null && root.val != root.right.val)
            {
                return false;
            }

            bool leftUnival = IsUnivalTree(root.left);
            bool rightUnival = IsUnivalTree(root.right);
            return leftUnival && rightUnival;
        }
    }
}
