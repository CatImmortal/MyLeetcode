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

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
            {
                return false;
            }


            //检查s是否和t相同
            //或者s的左子树或右子树中是否有和t相同的子树
            return IsSameTree(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
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
