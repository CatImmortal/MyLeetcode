using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/first-unique-character-in-a-string/

    class _0387字符串中的第一个唯一字符
    {
        public int FirstUniqChar(string s)
        {
            //统计所有字符出现次数
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 1);
                }
                else
                {
                    dict[c] += 1;
                }
            }

            //再遍历一遍字符串 查询每个字符的出现次数
            for (int i = 0; i < s.Length; i++)
            {
                if (dict[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1;



        }
    }
}
