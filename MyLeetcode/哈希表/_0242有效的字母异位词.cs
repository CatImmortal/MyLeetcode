using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/valid-anagram/

    class _0242有效的字母异位词
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

           
            //统计两个字符串中字符出现次数
            Dictionary<char, int> dict1 = new Dictionary<char, int>();
            Dictionary<char, int> dict2 = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c1 = s[i];
                char c2 = t[i];

                if (!dict1.ContainsKey(c1))
                {
                    dict1.Add(c1, 1);
                }
                else
                {
                    dict1[c1] += 1;
                }

                if (!dict2.ContainsKey(c2))
                {
                    dict2.Add(c2, 1);
                }
                else
                {
                    dict2[c2] += 1;
                }
            }

            //相同字符出现次数查询
            foreach (KeyValuePair<char, int> item in dict1)
            {
                //有不同的字符
                if (!dict2.ContainsKey(item.Key))
                {
                    return false;
                }

                //相同字符出现次数不一致
                if (item.Value != dict2[item.Key])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
