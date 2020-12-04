using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.二分查找
{
    //https://leetcode-cn.com/problems/search-in-rotated-sorted-array/

    class _0033搜索旋转排序数组
    {
        public int Search(int[] nums, int target)
        {
            //复制新数组 排序后进行二分查找

            if (nums.Length == 1)
            {
                if (nums[0] == target)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }

            int[] newNums = new int[nums.Length];

            Array.Copy(nums, newNums, nums.Length);

            Array.Sort(newNums);

            int index = BinarySearch(newNums, target);

            if (index == -1)
            {
                return -1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];

                if (num == newNums[index])
                {
                    return i;
                }
            }

            return -1;
        }

        private int BinarySearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);

                if (nums[mid] > target)
                {
                    // 下一轮搜索区间是 [left, mid - 1]
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    // 下一轮搜索区间是 [mid + 1, right]
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }


            return -1;
        }

        public int Search2(int[] nums, int target)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return -1;
            }
            if (n == 1)
            {
                return nums[0] == target ? 0 : -1;
            }

            int left = 0;
            int right = n - 1;

            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[0] <= nums[mid])
                {
                    //mid左侧部分有序

                    if (nums[0] <= target && target < nums[mid])
                    {
                        //target在left..mid-1里 收缩右边界
                        right = mid - 1;
                    }
                    else
                    {
                        //target在mid+1..n-1里 收缩左边界
                        left = mid + 1;
                    }
                }
                else
                {
                    //mid右侧部分有序

                    if (nums[mid] < target && target <= nums[n - 1])
                    {
                        //target在mid+1..n-1里 收缩左边界
                        left = mid + 1;
                    }
                    else
                    {
                        //target在left..mid-1里 收缩右边界
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }
    }
}
