using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.位运算
{
    //https://leetcode-cn.com/problems/reverse-bits/

    class _0190颠倒二进制位
    {
        public uint reverseBits(uint n)
        {
            uint ans = 0;
            int power = 31;
            while (n != 0)
            {
                //取n当前最后一位，然后左移power位
                uint result = (n & 1) << power;

                //与ans组合
                ans |= result;  

                //右移n
                n >>= 1;

                //改变power
                power--;
            }

            return ans;
        }
    }
}
