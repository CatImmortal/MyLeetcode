using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.位运算
{
    //https://leetcode-cn.com/problems/number-of-1-bits/

    class _0191位1的个数
    {
        public int HammingWeight(uint n)
        {
            int ans = 0;

            int mask = 1;  //位掩码

            for (int i = 0; i < 32; i++)
            {
  
                if ((n & mask) != 0)
                {
                    ans++;
                }
                mask <<= 1;
            }

            return ans;
        }

        public int HammingWeight2(uint n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum++;
                n &= (n - 1);  //将n 按位与 n-1 总是将n二进制最后一个1变为0
            }
            return sum;
        }
    }
}
