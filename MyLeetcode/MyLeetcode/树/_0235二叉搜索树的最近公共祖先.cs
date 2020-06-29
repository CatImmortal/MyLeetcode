using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

    class _0235二叉搜索树的最近公共祖先
    {

        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                //根节点为null 或者根节点就是p或q中的一个
                return root;
            }

            if ((root.val < p.val && root.val > q.val) || (root.val > p.val && root.val < q.val))
            {
                //根节点值介于p和q之间，但又不是p或者q中的一个
                return root;
            }

            if (root.val > p.val && root.val > q.val)
            {
                //根节点值比p和q都大，往左子树递归查找
                return LowestCommonAncestor(root.left, p, q);
            }

            //根节点值比p和q都小，往右子树递归查找
            return LowestCommonAncestor(root.right, p, q);
        }
    }
}
