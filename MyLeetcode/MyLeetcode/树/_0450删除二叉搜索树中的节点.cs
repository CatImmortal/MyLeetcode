using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/delete-node-in-a-bst/

    class _0450删除二叉搜索树中的节点
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val == key)
            {
                if (root.left == null && root.right == null)
                {
                    //没有左右子树 直接返回null
                    return null;
                }

                if (root.left == null)
                {
                    //没有左子树 返回右子树
                    return root.right;
                }

                if (root.right == null)
                {
                    //没有右子树 返回左子树
                    return root.left;
                }

                //左右子树都有 找到后继节点 删除 然后值替换过来
                int min = GetMin(root.right);
                root.right = DeleteNode(root.right, min);
                root.val = min;
            }
            else if (root.val < key)
            {
                root.right = DeleteNode(root.right, key);
            }
            else if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
            }

            return root;
        }

        private int GetMin(TreeNode root)
        {
            if (root.left == null)
            {
                return root.val;
            }

            return GetMin(root.left);
        }
    }
}
