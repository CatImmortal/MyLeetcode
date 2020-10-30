using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.字符串
{
    //https://leetcode-cn.com/problems/reverse-string-ii/

    class _0541反转字符串2
    {

        public string ReverseStr(string s, int k)
        {
            char[] chars = s.ToCharArray();
            for (int startIndex = 0; startIndex < chars.Length; startIndex+= k * 2)
            {
                int i = startIndex;
                int j = Math.Min(startIndex + k - 1, chars.Length - 1);

                //翻转i到j区间
                while (i < j)
                {
                    char tmp = chars[i];
                    chars[i] = chars[j];
                    chars[j] = tmp;

                    i++;
                    j--;
                }
            }

            return new string(chars);
        }

    


    }
}
