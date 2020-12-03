using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.二分查找
{
    //https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array/

    class _0034在排序数组中查找元素的第一个和最后一个位置
    {

        public int[] SearchRange(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int[] ans = { -1, -1 };

            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);

                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    //命中了
                    int i = mid;
                    while (i - 1 >= 0 && nums[i - 1] == target )
                    {
                        //一直左移 找最左边和target相同的数
                        i--;
                    }

                    ans[0] = i;

                    int j = mid;
                    while (j + 1 < nums.Length && nums[j + 1] == target)
                    {
                        //一直右移 找最右边和target相同的数
                        j++;
                    }

                    ans[1] = j;

                    break;

                }
            }

            return ans;
        }

        public int[] SearchRange2(int[] nums, int target)
        {
            int len = nums.Length;
            if (len == 0)
            {
                return new int[] { -1, -1 };
            }

            int first = BinarySearchFirst(nums, target);
            if (first == -1)
            {
                return new int[] { -1, -1 };
            }

            int last = BinarySearchLast(nums, target);
            return new int[] { first, last };
        }

        private int BinarySearchFirst(int[] nums, int target)
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
                    //不返回 收缩右边界
                    right = mid - 1;
                }
            }

            //小心越界
            if (left >= nums.Length || nums[left] != target)
            {
                return -1;
            }

            return left;
        }

        private int BinarySearchLast(int[] nums, int target)
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
                    //不返回 收缩左边界
                    left = mid + 1;
                }
            }

            //小心越界
            if (right < 0 || nums[right] != target)
            {
                return -1;
            }

            return right;
        }
    }
}
