using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数学
{
    //https://leetcode-cn.com/problems/missing-number/

    class _0268缺失数字
    {
        public int MissingNumber(int[] nums)
        {
            //先求1到n的和
            int sum1 = nums.Length * (nums.Length + 1) / 2;

            //然后求数组和
            int sum2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum2 += nums[i];
            }

            //两者之差就是缺失的数字
            return sum1 - sum2;



        }
    }
}
