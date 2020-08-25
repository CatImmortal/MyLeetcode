using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.字符串
{
    //https://leetcode-cn.com/problems/string-to-integer-atoi/

    class _0008字符串转换整数atoi
    {
        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int len = str.Length;

            int index = 0;
            int sign = 1;
            int ans = 0;

            //1.移除空格
            while (index < len && str[index] == ' ')
            {
                index++;
            }

            if (index == len)
            {
                //全是空格的情况
                return 0;
            }

            //2.处理正负符号
            if (str[index] == '+' || str[index] == '-')
            {
                sign = str[index] == '+' ? 1 : -1;
                index++;
            }

            //3.转换数字 避免溢出
            while (index < len)
            {
                int digit = str[index] - '0';
                if (digit < 0 || digit > 9)
                {
                    //不是数字的情况 直接打断循环
                    break;
                }

                if (ans > (int.MaxValue - digit) / 10)
                {
                    //溢出了
                    return sign == 1 ? int.MaxValue : int.MinValue;
                }

                //计算ans
                ans = ans * 10 + digit;
                index++;
            }

            return ans * sign;
            
        }
    }
}
