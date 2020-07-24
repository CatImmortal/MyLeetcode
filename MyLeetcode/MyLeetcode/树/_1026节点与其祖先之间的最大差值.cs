using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/maximum-difference-between-node-and-ancestor/

    class _1026节点与其祖先之间的最大差值
    {
        private int ans = 0;

        public int MaxAncestorDiff(TreeNode root)
        {
            //在遍历每条路径时保存当前路径的最小值和最大值
            //到达叶子节点后更新最小值最大值的最大差值ans
            PreOrder(root, root.val, root.val);

            return ans;
        }

        private void PreOrder(TreeNode root,int min,int max)
        {
            if (root == null)
            {
                return;
            }

            //更新此条路径的最小值和最大值
            min = Math.Min(min, root.val);
            max = Math.Max(max, root.val);


            //到达路径尽头 更新ans
            if (root.left == null && root.right == null)
            {
                int num = Math.Abs(max - min);
                ans = Math.Max(ans, num);
            }

            PreOrder(root.left, min, max);
            PreOrder(root.right, min, max);
        }

   
    }
}
