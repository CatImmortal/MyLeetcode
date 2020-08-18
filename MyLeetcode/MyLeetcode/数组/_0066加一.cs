using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/plus-one/

    class _0066加一
    {
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i]++;
                digits[i] %= 10;

               
                if (digits[i] != 0)
                {
                    //没触发进位 直接返回
                    return digits;
                }
            }

            //多出一位
            int[] ans = new int[digits.Length + 1];
            ans[0] = 1;
            return ans;
        }
    }
}
