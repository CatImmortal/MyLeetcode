using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.字符串
{
    //https://leetcode-cn.com/problems/valid-palindrome/

    class _0125验证回文串
    {
        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                //分别在左边和右边找到需要对比的字符
                while (left < right && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                if (left < right)
                {
                    //进行对比
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }

                    left++;
                    right--;
                }

            }

            return true;
        }
    }
}
