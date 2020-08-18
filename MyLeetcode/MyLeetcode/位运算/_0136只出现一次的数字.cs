using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.位运算
{
    //https://leetcode-cn.com/problems/single-number/

    class _0136只出现一次的数字
    {
        public int SingleNumber(int[] nums)
        {
            int ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                //任何数异或自己都得0
                //异或操作满足结合律
                ans ^= nums[i];
            }

            return ans;
        }
    }
}
