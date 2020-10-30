using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/contains-duplicate/

    class _0217存在重复元素
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    return true;
                }

                set.Add(nums[i]);
            }

            return false;
        }
    }
}
