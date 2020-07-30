using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/delete-nodes-and-return-forest/

    class _1110删点成林
    {
        private HashSet<int> set;
        private List<TreeNode> ans = new List<TreeNode>();

        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            set = new HashSet<int>(to_delete);
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



            if (root.left != null && set.Contains(root.left.val))
            {
                //左子节点需要删除
            }

            if (root.right != null && set.Contains(root.right.val))
            {
                //右子节点需要删除
            }

            PreOrder(root.left);
            PreOrder(root.right);
        }
    }
}
