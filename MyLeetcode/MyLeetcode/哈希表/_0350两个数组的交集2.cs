using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/

    class _0350两个数组的交集2
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return Intersect(nums2, nums1);
            }

            //把元素少的数组里的元素出现次数统计进字典
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!dict.ContainsKey(nums1[i]))
                {
                    dict.Add(nums1[i], 1);
                }
                else
                {
                    dict[nums1[i]] += 1;
                }
            }

            List<int> ans = new List<int>();

            //用元素多的那个数组的元素和字典进行对比
            for (int i = 0; i < nums2.Length; i++)
            {
                if (dict.ContainsKey(nums2[i]))
                {
                    ans.Add(nums2[i]);
                    dict[nums2[i]] -= 1;
                    if (dict[nums2[i]] == 0)
                    {
                        dict.Remove(nums2[i]);
                    }
                }
            }

            return ans.ToArray();

          
        }
    }
}
