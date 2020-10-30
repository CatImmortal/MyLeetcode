using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.动态规划
{
    //https://leetcode-cn.com/problems/maximum-subarray/

    class _0053最大子序和
    {
        public int MaxSubArray(int[] nums)
        {
            //动态规划
            int pre = 0;
            int maxAns = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];

                //对比加入pre和单独成一段谁比较大
                pre = Math.Max(pre + num, num);

                //与答案对比
                maxAns = Math.Max(maxAns, pre);

            }

            return maxAns;
        }
    }
}
