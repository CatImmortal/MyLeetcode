using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/symmetric-tree/

    class _0101对称二叉树
    {

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                //没有根节点 对称
                return true;
            }

            if (root.left == null && root.right == null)
            {
                //只有根节点 对称
                return true;
            }

            if (root.left == null || root.right == null)
            {
                //根节点只有左子树或只有右子树 不对称
                return false;
            }

            //对比左右子树是否镜像相等
            return MirrorEqualsTree(root.left, root.right);

        }


        /// <summary>
        /// 两棵二叉树是否镜像相等
        /// </summary>
        private bool MirrorEqualsTree(TreeNode leftRoot, TreeNode rightRoot)
        {
            if (leftRoot == null && rightRoot == null)
            {
                return true;
            }

            if (leftRoot == null || rightRoot == null)
            {
                return false;
            }

            //根节点是否相等
            //leftRoot的左子树和rightRoot的右子树是否相等
            //leftRoot的右子树和rightRoot的左子树是否相等
            return leftRoot.val == rightRoot.val && MirrorEqualsTree(leftRoot.left, rightRoot.right) && MirrorEqualsTree(leftRoot.right, rightRoot.left);
        }
    }
}
