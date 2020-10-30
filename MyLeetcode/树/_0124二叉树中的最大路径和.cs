using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-maximum-path-sum/

    class _0124二叉树中的最大路径和
    {
        private int ans = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            int sum = PostOrder(root);
            ans = Math.Max(ans, sum);
            return ans;
        }

        private int PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            //获取左右子树中最大路径和 不考虑负数

            int leftMaxPathSum = PostOrder(root.left);
            leftMaxPathSum = Math.Max(0, leftMaxPathSum);

            int rightMaxPathSum = PostOrder(root.right);
            rightMaxPathSum = Math.Max(0, rightMaxPathSum);

            //左右子树中最大路径和+自身节点值就是当前节点的最大路径和
            int sum = root.val + rightMaxPathSum + leftMaxPathSum;

            //更新ans
            ans = Math.Max(ans, sum);

            //返回当前节点可贡献给父节点的最大路径和
            return root.val + Math.Max(leftMaxPathSum, rightMaxPathSum);
        }


    }
}
