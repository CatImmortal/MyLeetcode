using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.哈希表
{
    //https://leetcode-cn.com/problems/4sum-ii/

    class _0454四数相加2
    {
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            //我们可以将四个数组分成两部分，A 和 B 为一组，C 和 D 为另外一组。


            Dictionary<int, int> countAB = new Dictionary<int, int>();

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    //把所有A[i] + B[j]的出现次数记录下

                    int sum = A[i] + B[j];

                    if (countAB.ContainsKey(sum))
                    {
                        countAB[sum]++;
                    }
                    else
                    {
                        countAB.Add(sum, 1);
                    }

                }
            }

            int ans = 0;

            for (int i = 0; i < C.Length; i++)
            {
                for (int j = 0; j < D.Length; j++)
                {
                    int sum = C[i] + D[j];
                    //如果有-(C[i] + D[j])在字典中 意味着能相加为0 就计入解答中
                    if (countAB.ContainsKey(-sum))
                    {
                        ans += countAB[-sum];
                    }
                }
            }

            return ans;
        }
    }
}
