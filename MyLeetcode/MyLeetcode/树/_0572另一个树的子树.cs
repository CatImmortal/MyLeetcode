using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/subtree-of-another-tree/

    class _0572另一个树的子树
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
            {
                return false;
            }

            //检查s是否和t相同
            if (IsSameTree(s, t))
            {
                return true;
            }

            //递归到s的左子树和右子树
            return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        private bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            //p和q的值是否相等
            //p和q的左子树是否相等
            //p和q的右子树是否相等
            //以上都满足就是相同的树
            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
