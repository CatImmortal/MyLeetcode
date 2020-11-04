using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/longest-palindrome/

    class _0409最长回文串
    {
        public int LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            //字符与其出现次数
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 0);
                }

                dict[c] = dict[c] + 1;
            }

            int ans = 0;

            foreach (KeyValuePair<char, int> item in dict)
            {
                ans += item.Value / 2 * 2;

                if (item.Value%2==1 && ans %2==0)
                {
                    //value为奇数 ans为偶数时 为ans+1
                    //意味着设置了一个回文中心
                    ans++; 
                }
            }




            return ans;
        }
    }
}
