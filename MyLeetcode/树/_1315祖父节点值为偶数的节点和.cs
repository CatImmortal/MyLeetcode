using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/sum-of-nodes-with-even-valued-grandparent/

    class _1315祖父节点值为偶数的节点和
    {

        private int ans = 0;

        public int SumEvenGrandparent(TreeNode root)
        {
            PreOrder(root);
            return ans;
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }


            if (root.val % 2 == 0)
            {
                if (root.left != null)
                {
                    if (root.left.left != null)
                    {
                        ans += root.left.left.val;
                    }

                    if (root.left.right != null)
                    {
                        ans += root.left.right.val;
                    }
                }

                if (root.right != null)
                {
                    if (root.right.left != null)
                    {
                        ans += root.right.left.val;
                    }
                    if (root.right.right != null)
                    {
                        ans += root.right.right.val;
                    }
                }

            }

            PreOrder(root.left);
            PreOrder(root.right);
        }
    }
}
