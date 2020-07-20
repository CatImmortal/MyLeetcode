using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/lowest-common-ancestor-of-deepest-leaves/

    class _1123最深叶节点的最近公共祖先
    {
        //如果当前节点是最深叶子节点的最近公共祖先，那么它的左右子树的高度一定是相等的
        //否则高度低的那个子树的叶子节点深度一定比另一个子树的叶子节点的深度小，因此不满足条件
        //所以只需要dfs遍历找到左右子树高度相等的根节点即出答案。

        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            if (root == null)
                return null;
            int ld = GetDepth(root.left);
            int rd = GetDepth(root.right);
            if (ld == rd)
            {
                return root;
            }
            else if (ld > rd)
            {
                return LcaDeepestLeaves(root.left);
            }
            else
            {
                return LcaDeepestLeaves(root.right);
            }

        }

        public int GetDepth(TreeNode node)
        {
            if (node == null)
                return 0;
            int left = GetDepth(node.right);
            int right = GetDepth(node.left);
            return Math.Max(left, right) + 1;
        }
    }
}
