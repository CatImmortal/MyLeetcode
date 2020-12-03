using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.二分查找
{
    class _0162寻找峰值
    {
        //https://leetcode-cn.com/problems/find-peak-element/

        public int FindPeakElement(int[] nums)
        {
            //二分查找
            //在山脉数组上使用二分查找，找出满足 nums[i] < nums[i+1] 的最大 i
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + ((right - left) >> 1);

                if (nums[mid] < nums[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;

        }
    }
}
