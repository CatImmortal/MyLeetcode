using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.动态规划
{
    //https://leetcode-cn.com/problems/climbing-stairs/

    class _0070爬楼梯
    {
        public int ClimbStairs(int n)
        {
            if (n == 1 || n == 2)
            {
                return n;
            }

            int num1 = 1;
            int num2 = 2;
            int num3 = 0;
            for (int i = 3; i <= n; i++)
            {
                num3 = num1 + num2;
                num1 = num2;
                num2 = num3;
            }
            return num3;
        }
    }
}
