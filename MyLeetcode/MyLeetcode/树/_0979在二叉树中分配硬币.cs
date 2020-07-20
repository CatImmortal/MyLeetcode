using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/distribute-coins-in-binary-tree/

    class _0979在二叉树中分配硬币
    {
        private int ans = 0;

        public int DistributeCoins(TreeNode root)
        {
            PostOrder(root);
            return ans;
        }

        /// <summary>
        /// 返回使当前节点的金币数为1的，需要拿走的金币数目
        /// </summary>
        private int PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftNum = PostOrder(root.left);
            ans += Math.Abs(leftNum);

            int rightNum = PostOrder(root.right);
            ans += Math.Abs(rightNum);

            int rootNum = root.val - 1;

            return rootNum + leftNum + rightNum;
        }

    }
}
