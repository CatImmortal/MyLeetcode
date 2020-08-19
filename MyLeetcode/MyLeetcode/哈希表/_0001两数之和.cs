using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/two-sum/

    class _0001两数之和
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //在字典中查询是否存在另一个数
                if (!dict.ContainsKey(target - nums[i]))
                {
                    if (!dict.ContainsKey(nums[i]))
                    {
                        dict.Add(nums[i], i);
                    }
                    
                }
                else
                {
                    return new int[] { dict[target - nums[i]], i };
                }
            }

            return new int[0];
        }
    }
}
