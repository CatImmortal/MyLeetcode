using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/

    class _0026删除排序数组中的重复项
    {
        public int RemoveDuplicates(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i=j)
            {
                for (j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        nums[j] = int.MinValue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != int.MinValue)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }

            return index;
        }

        public int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                //j和i位置的元素不相同时
                //把j位置元素放到i+1处
                //然后自增i(自增后i处元素为新的待比对元素)
                if (nums[j] != nums[i])
                {
                    
                    nums[i + 1] = nums[j];
                    i++;
                }
            }

            return i + 1;
        }
    }
}
