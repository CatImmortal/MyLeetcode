using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/construct-binary-search-tree-from-preorder-traversal/

    class _1008先序遍历构造二叉树
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            TreeNode root = new TreeNode(preorder[0]);

            for (int i = 1; i < preorder.Length; i++)
            {
                Insert(root, preorder[i]);
            }
            return root;
        }

        private void Insert(TreeNode root, int val)
        {
            TreeNode cur = root;
            while (true)
            {
                if (val < cur.val)
                {
                    if (cur.left == null)
                    {
                        cur.left = new TreeNode(val);
                        return;
                    }
                    else
                    {
                        cur = cur.left;
                        continue;
                    }
                }

                if (val > cur.val)
                {
                    if (cur.right == null)
                    {
                        cur.right = new TreeNode(val);
                        return;
                    }
                    else
                    {
                        cur = cur.right;
                        continue;
                    }
                }
            }
        }

    }
}
