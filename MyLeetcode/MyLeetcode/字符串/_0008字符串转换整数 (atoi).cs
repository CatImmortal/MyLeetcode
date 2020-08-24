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
            if (string.IsNullOrEmpty(str)|| string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            //找到第一个非空字符
            int helper = 1;
            int i = 0;
            for (i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c != ' ')
                {
                    if (c == '-')
                    {
                        //是负数
                        helper = -1;

                        //下标后移一位
                        i++;
                    }
                    else if (c < '0' || c > '9')
                    {
                        //不是数字
                        return 0;
                    }


                    break;
                }
            }

            //最后一位是-的情况
            if (i == str.Length)
            {
                return 0;
            }

            int ans = 0;

            for (; i < str.Length; i++)
            {
                char c = str[i];
                if (c < '0' || c > '9')
                {
                    //忽略掉有效整数部分后续的多余字符
                    break;
                }

                if (ans > (int.MaxValue - (c - '0')) / 10  )
                {

                }




                //溢出检查
                if (helper == -1)
                {
                    if (temp * -1 < int.MinValue)
                    {
                        return int.MinValue;
                    }
                }
                else
                {
                    if (temp > int.MaxValue)
                    {
                        return int.MaxValue;
                    }
                }

                ans = (int)temp;
            }

            return ans * helper;

            
        }
    }
}
