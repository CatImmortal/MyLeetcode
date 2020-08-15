using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/search-insert-position/

    class _0035搜索插入位置
    {
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int left = 0;
            int right = nums.Length - 1;
            int middle = 0;
            while (left <= right)
            {
                double temp = (left + right) / 2.0;
                middle = (int)Math.Ceiling(temp);
                if (nums[middle] == target)
                {
                    return middle;
                }

                if (nums[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            //没找到目标值 计算其插入位置
            if (nums[middle] > target)
            {
                return middle;
            }
            else
            {
                return middle + 1;
            }
        }
    }
}
