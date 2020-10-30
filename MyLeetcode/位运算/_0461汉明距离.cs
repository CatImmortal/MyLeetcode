using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.位运算
{
    //https://leetcode-cn.com/problems/hamming-distance/

    class _0461汉明距离
    {
        public int HammingDistance(int x, int y)
        {
            int ans = 0;
            int mask = 1;  //位掩码
            for (int i = 0; i < 32; i++)
            {
                if ((x & mask) != (y & mask))
                {
                    ans++;
                }
                mask <<= 1;
            }

            return ans;
        }

        public int HammingDistance2(int x, int y)
        {
            int ans = 0;

            //只有不同的位才会被异或为1
            //异或后统计1的位数
            int n = x ^ y;

            if (n != 0)
            {
                while (n != 0)
                {
                    ans++;
                    n &= (n - 1);  //将n 按位与 n-1 总是将n最后一个1变为0
                }
            }

            return ans;
        }
    }
}
