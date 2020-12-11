using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.动态规划
{
    //https://leetcode-cn.com/problems/longest-palindromic-substring/

    class _0005最长回文子串
    {
        public string LongestPalindrome(string s)
        {
            //双层循环暴力解法

            if (s.Length < 2)
            {
                return s;
            }

            int maxLen = 1;  //当前最长回文子串的长度
            int begin = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    //子串长度
                    int subStrLen = j - i + 1;

                    if (subStrLen > maxLen && ValidPalindromic(s,i,j))
                    {
                        maxLen = subStrLen;
                        begin = i;
                    }
                }
            }

            return s.Substring(begin, maxLen);
        }

        /// <summary>
        /// 验证字符串left到right的部分是否回文
        /// </summary>
        private bool ValidPalindromic(string s,int left, int right)
        {
            while (left < right)
            {
                if (s[left]!= s[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }

        public string LongestPalindrome2(string s)
        {
            //动态规划解法

            if (s.Length < 2 )
            {
                return s;
            }

            int maxLen = 1; //当前最长回文子串的长度
            int begin = 0;

            bool[,] dp = new bool[s.Length, s.Length];  //dp[i,j]表示i到j位置的字符串是否为回文串

            for (int i = 0; i < s.Length; i++)
            {
                dp[i, i] = true;
            }

            for (int j = 1; j < s.Length; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    if (s[i] != s[j])
                    {
                        //子串首尾不相等
                        dp[i, j] = false;
                    }

                    else
                    {
                        //子串首尾相等
                        if (j - i < 3)
                        {
                            //并且只有2个或3个字符
                            dp[i, j] = true;
                        }
                        else
                        {
                            //字符数4个以上 根据其去除首尾后的部分是否为回文决定
                            dp[i, j] = dp[i + 1, j - 1];
                        }
                    }

                    int subStrLen = j - i + 1;
                    if (dp[i,j] && subStrLen > maxLen)
                    {
                        maxLen = subStrLen;
                        begin = i;
                    }


                }
            }

            return s.Substring(begin, maxLen);


        }

        public string LongestPalindrome3(string s)
        {
            //中心扩散法
            if (s.Length < 2)
            {
                return s;
            }

            int maxLen = 1;

            string res = s.Substring(0, 1);

            for (int i = 0; i < s.Length - 1; i++)
            {
                string oddStr = CenterSpread(s, i, i);
                string evenStr = CenterSpread(s, i, i + 1);
                string maxLenStr = oddStr.Length > evenStr.Length ? oddStr : evenStr;
                if (maxLenStr.Length > maxLen)
                {
                    maxLen = maxLenStr.Length;
                    res = maxLenStr;
                }
            }

            return res;
        }

        /// <summary>
        /// 返回以left与right为回文中心时的最长回文串
        /// </summary>
        private string CenterSpread(string s,int left,int right)
        {
            // left = right 的时候，此时回文中心是一个字符，回文串的长度是奇数
            // right = left + 1 的时候，此时回文中心是一个空隙，回文串的长度是偶数

            int i = left;
            int j = right;
            while (i >= 0 && j < s.Length)
            {
                if (s[i] != s[j])
                {
                    break;  
                }


                i--;
                j++;
            }
            //取 去除i和j后的字符串部分 作为返回值
            return s.Substring(i + 1,(j - 1) - (i + 1) + 1);
        }
    }
}
