using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.字符串
{
    //https://leetcode-cn.com/problems/implement-strstr/
    class _0028实现strStr
    {
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(haystack) && string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(haystack))
            {
                return -1;
            }

            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    if (Check(haystack,i,needle))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private bool Check(string s,int startIndex,string target)
        {
            if (s.Length - startIndex < target.Length)
            {
                //长度不足
                return false;
            }

            for (int i = startIndex,j = 0; i < s.Length && j < target.Length; i++,j++)
            {
                if (s[i] != target[j])
                {
                    return false;
                }
            }

            

            return true;
        }
    }
}
