using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.动态规划
{
    //https://leetcode-cn.com/problems/house-robber/

    class _0198打家劫舍
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int len = nums.Length;
            if (len == 1)
            {
                return nums[0];
            }

            //到前两个房间为止的最高可偷窃金额
            int first = nums[0];
            int second = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < len; i++)
            {
                int temp = second;



                //当前房屋最高可偷窃金额=max(0 .. i - 2最高金额 + 当前房屋金额,0 .. i-1最高金额)
                //就是选择 i-2房屋最高可偷窃金额 + 当前房屋金额 还是选择i- 1房屋最高可偷窃金额
                second = Math.Max(first + nums[i], second);

                first = temp;
            }

            return second;
        }
    }
}
