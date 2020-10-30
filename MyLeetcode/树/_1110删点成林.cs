using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/delete-nodes-and-return-forest/

    class _1110删点成林
    {
        private HashSet<int> deleteSet;
        
        private List<TreeNode> ans = new List<TreeNode>();

        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            if (root == null )
            {
                return ans;
            }

            if ( to_delete == null ||to_delete.Length == 0)
            {
                ans.Add(root);
                return ans;
            }

            deleteSet = new HashSet<int>(to_delete);

            if (!deleteSet.Contains(root.val))
            {
                ans.Add(root);
            }

            TreeNode dummyRoot = new TreeNode(-1);
            dummyRoot.right = root;
            PreOrder(dummyRoot);

            

            return ans;
           
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }


            TreeNode left = root.left;
            TreeNode right = root.right;

            if (root.left != null && deleteSet.Contains(root.left.val))
            {
                //左子节点需要删除
                root.left = null;

                //尝试将左子节点的左右子节点加入ans中
                if (left.left!=null && !deleteSet.Contains(left.left.val))
                {
                    ans.Add(left.left);
                }
                if (left.right != null && !deleteSet.Contains(left.right.val))
                {
                    ans.Add(left.right);
                }
            }

            if (root.right != null && deleteSet.Contains(root.right.val))
            {
                //右子节点需要删除
                root.right = null;

                //尝试将右子节点的左右子节点加入ans中
                if (right.left != null && !deleteSet.Contains(right.left.val))
                {
                    ans.Add(right.left);
                }
                if (right.right != null && !deleteSet.Contains(right.right.val))
                {
                    ans.Add(right.right);
                }
            }

            PreOrder(left);
            PreOrder(right);
        }

        public IList<TreeNode> DelNodes2(TreeNode root, int[] to_delete)
        {
            deleteSet = new HashSet<int>(to_delete);
            PostOrder(root, false);
            return ans;
        }

        private bool PostOrder(TreeNode root,bool parentExist)
        {
            if (root == null)
            {
                return false;
            }

            bool needDelete = deleteSet.Contains(root.val);

            if (PostOrder(root.left,!needDelete))
            {
                //左子节点需要删除
                root.left = null;
            }

            if (PostOrder(root.right,!needDelete))
            {
                //右子节点需要删除
                root.right = null;
            }

            if (!needDelete && !parentExist)
            {
                //自身不需要删除 并且父节点不存在 就加入ans
                ans.Add(root);
            }

            return needDelete;
        }
    }
}
