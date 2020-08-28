using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数学
{
    //https://leetcode-cn.com/problems/count-primes/

    class _0204计数质数
    {
        public int CountPrimes(int n)
        {

            int result = 0;
            int sqrtN = (int)Math.Sqrt(n);

            bool[] b = new bool[n]; //合数标记

            for (int i = 2; i < sqrtN; i++)
            {
                if (b[i] == false)
                {
                    //是质数 将其倍数标记为合数
                    for (int j = i * i; j < n; j+=i)
                    {

                    }
                }
            }
            
        }
    }
}
