using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/search-in-a-binary-search-tree/

    class _0700二叉搜索树中的搜索
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val)
            {
                return root;
            }

            TreeNode cur = root;
            while (cur != null)
            {
                if (cur.val == val)
                {
                    return cur;
                }

                if (val < cur.val)
                {
                    cur = cur.left;
                }
                else
                {
                    cur = cur.right;
                }
            }

            return null;
        }
    }
}
