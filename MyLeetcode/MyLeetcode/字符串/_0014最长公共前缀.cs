using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.字符串
{
    //https://leetcode-cn.com/problems/longest-common-prefix/

    class _0014最长公共前缀
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            if (strs.Length == 1)
            {
                return strs[0];
            }

            int length = strs[0].Length;  //第一个字符串的长度
            int count = strs.Length;  //所有字符串数量

            for (int i = 0; i < length; i++)
            {
                char c = strs[0][i];  //第一个字符串的第i个字符

                for (int j = 1; j < count; j++)
                {
                    //逐个和后续字符串的第i个字符比对
                    if (i == strs[j].Length || strs[j][i] != c)
                    {
                        //后续字符串长度不足 或者 字符不同
                        //返回公共前缀
                        return strs[0].Substring(0, i);
                    }
                }
            }

            //第一个字符串是最短字符串 且同时是最长公共前缀
            //直接返回
            return strs[0];



        }

    }
}
