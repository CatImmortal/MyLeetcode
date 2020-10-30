using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/invert-binary-tree/

    class _0226翻转二叉树
    {

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            //交换左右子树
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            //然后翻转左右子树
            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }
    }
}
