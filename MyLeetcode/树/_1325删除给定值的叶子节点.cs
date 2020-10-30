using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/delete-leaves-with-a-given-value/

    class _1325删除给定值的叶子节点
    {
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (root == null)
            {
                return null;
            }

            //从左右子树删除
            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);

            if (root.val == target && root.left == null && root.right == null)
            {
                //是给定值的叶子节点 删除
                return null;
            }

            return root;
        }
    }
}
