using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/validate-binary-search-tree/

    class _0098验证二叉搜索树
    {
       

        public bool IsValidBST(TreeNode root)
        {
            return PreOrder(root, null,null);
        }

        private bool PreOrder(TreeNode root,int? min,int? max)
        {
            if (root == null)
            {
                return true;
            }

            if (min.HasValue && root.val <= min.Value)
            {
                return false;
            }

            if (max.HasValue && root.val >= max.Value)
            {
                return false;
            }

            return PreOrder(root.left, min, root.val) && PreOrder(root.right, root.val, max);
        }

        //----------------------------
        private long prev = long.MinValue;
        public bool IsValidBST2(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            if (!IsValidBST2(root.left))
            {
                return false;
            }

            if (root.val <= prev)
            {
                return false;
            }

            prev = root.val;

            return IsValidBST2(root.right);
        }
    }
}
