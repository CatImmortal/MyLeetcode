using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/merge-two-binary-trees/

    class _0617合并二叉树
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return t2;
            }

            if (t2 == null)
            {
                return t1;
            }

            //合并根节点
            t1.val += t2.val;

            //合并左子树和右子树
            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);

            return t1;
        }
    }
}
