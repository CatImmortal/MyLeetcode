using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.动态规划
{
    //https://leetcode-cn.com/problems/longest-increasing-subsequence/

    class _0300最长递增子序列
    {
        public int LengthOfLIS(int[] nums)
        {
            //动态规划

            if (nums.Length < 2)
            {
                return nums.Length;
            }

            //dp[i] 表示从 nums[0...i]，以nums[i]结尾的「上升子序列」的长度
            int[] dp = new int[nums.Length];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                //从nums[i]之前的所有数中找出所有小于nums[i]的数，取其中子序列最长的将其长度+1来作为dp[i]
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);  //这里+1 是要算上nums[i]接上去的长度
                    }
                }
            }

            //从dp数组中找出最长的子序列长度
            int res = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                res = Math.Max(res, dp[i]);
            }

            return res;
        }

        //public int LengthOfLIS2(int[] nums)
        //{
        //    if (nums.Length < 2)
        //    {
        //        return nums.Length;
        //    }

        //    //// tail[i]表示长度为 i + 1 的上升子序列的末尾最小是几
        //    int[] tail = new int[nums.Length];

        //    tail[0] = 0;

        //    // end 表示有序数组 tail 的最后一个已经赋值元素的索引
        //    int end = 0;

        //    for (int i = 1; i < nums.Length; i++)
        //    {
        //        if (nums[i] > tail[end])
        //        {
        //            // 【逻辑 1】比 tail 数组实际有效的末尾的那个元素还大
        //            // 直接添加在那个元素的后面，所以 end 先加 1
        //            end++;
        //            tail[end] = nums[i];
        //        }
        //        else
        //        {
        //            // 使用二分查找法，在有序数组 tail 中
        //            // 找到第 1 个大于等于 nums[i] 的元素，尝试让那个元素更小
        //            int left = 0;
        //            int right = end;
        //            while (left < right)
        //            {
        //                // 选左中位数不是偶然，而是有原因的，原因请见 LeetCode 第 35 题题解
        //                int mid = left + ((right - left) >> 1);
        //                if (tail[mid] < nums[i])
        //                {
        //                    // 中位数肯定不是要找的数，把它写在分支的前面
        //                    left = mid + 1;
        //                }
        //                else
        //                {
        //                    right = mid;
        //                }
        //            }

        //            // 走到这里是因为 【逻辑 1】 的反面，因此一定能找到第 1 个大于等于 nums[i] 的元素
        //            // 因此，无需再单独判断
        //            tail[left] = nums[i];
        //        }
        //    }

        //    end++;
        //    return end;
        //}
    }
}
