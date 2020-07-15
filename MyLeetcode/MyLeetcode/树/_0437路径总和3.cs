using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode-cn.com/problems/path-sum-iii/

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/path-sum-iii/

    class _0437路径总和3
    {


        public int PathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return 0;
            }

            int result = CountPath(root, sum);
            result += PathSum(root.left, sum);
            result += PathSum(root.right, sum);
            //root路径总数+左子树路径总数+右子树路径总数
            return result;
        }

        /// <summary>
        /// 以root为根节点出发，存在的总和为sum的路径总数
        /// </summary>
        private int CountPath(TreeNode root, int sum)
        {
            if (root == null)
            {
                return 0;
            }

            int result = 0;

            if (root.val == sum)
            {
                result++;
            }

            result += CountPath(root.left, sum - root.val);
            result += CountPath(root.right, sum - root.val);

            return result;
        }
    }
}
