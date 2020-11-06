using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.字符串
{
    class _0334递增的三元子序列
    {
        //https://leetcode-cn.com/problems/increasing-triplet-subsequence/

        public bool IncreasingTriplet(int[] nums)
        {
            if (nums == null || nums.Length < 3)
            {
                return false;
            }

            //保存两个较小数字
            int small = int.MaxValue;
            int mid = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];


                if (num <= small)
                {
                    small = num;
                }
                else if (num <= mid)
                {
                    mid = num;
                }
                else
                {
                    //找到一个比small和mid都大的数 返回true
                    return true;
                }
            }

            return false;
        }
    }
}
