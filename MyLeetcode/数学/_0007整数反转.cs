using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数学
{
    class _0007整数反转
    {
        //https://leetcode-cn.com/problems/reverse-integer/

        public int Reverse(int x)
        {
            int ans = 0;
            int max = int.MaxValue / 10;
            int min = int.MinValue / 10;
            while (x != 0)
            {
                //取x最后一位
                int pop = x % 10;
                //抹掉x最后一位
                x /= 10;

                //提前进行溢出判断
                if (ans > max|| (ans == max/ 10 && pop > 7))
                {
                    return 0;
                }
                if (ans < min || (ans == min && pop < - 8))
                {
                    return 0;
                }

                ans = ans * 10 + pop;
            }

            return ans;
        }
    }
}
