using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/

    class _0236二叉树的最近公共祖先
    {

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            // LowestCommonAncestor的返回值如果不为null（p和q都不存在root下）
            //那么返回值是p和q其中至少一个的公共祖先（或者是其本身）

            TreeNode leftNode = LowestCommonAncestor(root.left, p, q);
            TreeNode rightNode = LowestCommonAncestor(root.right, p, q);

            if (leftNode != null && rightNode != null)
            {
                //p和q分别在左子树和右子树中 root是它俩的公共祖先
                return root;
            }

            if (leftNode != null)
            {
                //p和q都在左子树 leftNode是它俩的公共祖先
                return leftNode;
            }

            if (rightNode != null)
            {
                //p和q都在右子树 rightNode是它俩的公共祖先
                return rightNode;
            }

            return null;
        }
    }
}
