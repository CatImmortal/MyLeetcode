using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/intersection-of-two-arrays/

    class _0349两个数组的交集
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> set = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>();
            List<int> ans = new List<int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                if (set.Contains(nums2[i]) && !set2.Contains(nums2[i]))
                {
                    set2.Add(nums2[i]);
                    ans.Add(nums2[i]);
                }
            }

            return ans.ToArray();
        }
    }
}
