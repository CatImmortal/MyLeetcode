using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-pruning/

    class _0814二叉树剪枝
    {

        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            //剪枝左右子树
            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);

            //没有子节点 并且自身为0 返回null
            if (root.left == null && root.right == null && root.val == 0)
            {
                return null;
            }

            return root;
        }
    }
}
