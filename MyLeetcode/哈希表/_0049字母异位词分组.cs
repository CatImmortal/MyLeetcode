using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/group-anagrams/

    class _0049字母异位词分组
    {


        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> res = new List<IList<string>>();

            if (strs.Length == 0)
            {
                return res;
            }

            //key=字母异位词排序后的字符串 value=字母异位词
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] chars = strs[i].ToCharArray();
                Array.Sort(chars);  //排序字符 然后查询字典
                string temp = new string(chars);

                if (!dict.ContainsKey(temp))
                {
                    List<string> list = new List<string>();
                    dict.Add(temp, list);
                    res.Add(list);
                }

                dict[temp].Add(strs[i]);
            }

            return res;
        }

        //ASCII码解法
        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            List<IList<string>> res = new List<IList<string>>();

            if (strs.Length == 0)
            {
                return res;
            }

            //key=ASCII码乘积+ASCII码和 value=字母异位词
            Dictionary<uint, List<string>> dict = new Dictionary<uint, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                string str = strs[i];

                //计算key
                uint t = 1;
                uint y = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    char c = str[j];

                    t *= c;
                    y += c;
                }
                uint key = t + y;

                if (!dict.ContainsKey(key))
                {
                    List<string> list = new List<string>();
                    dict.Add(key, list);

                    //收集到res里
                    res.Add(list);
                }

                dict[key].Add(str);
            }

            return res;
        }
    }
}
