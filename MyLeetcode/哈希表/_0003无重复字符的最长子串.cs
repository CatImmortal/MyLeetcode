using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/

    class _0003无重复字符的最长子串
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            //字符和索引的字典映射
            Dictionary<char, int> dict = new Dictionary<char, int>();

            int left = 0;
            int right = 0;
            int ans = 0;
            while (right < s.Length)
            {
                char c = s[right];

                if (!dict.ContainsKey(c))
                {
                    //不在字典里
                    dict.Add(c, right);
                    right++;
                }
                else
                {
                    //在字典里 代表有重复 计算长度
                    ans = Math.Max(ans, right - left);

                    //重设left和right位置
                    left = dict[c] + 1;  //left新位置为重复字符第一次出现的位置+1
                    right = left;

                    //清空字典
                    dict.Clear();
                }

            }

            //right到字符串尾部了 还要再计算一次length
            ans = Math.Max(ans, right - left);

            return ans;
        }
    }
}
