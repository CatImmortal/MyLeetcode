using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.动态规划
{
    //https://leetcode-cn.com/problems/unique-paths/

    class _0062不同路径
    {
        public int UniquePaths(int m, int n)
        {
            //dp[i,j]表示从左上角走到i,j位置的路径数量
            //dp[i,j] = dp[i-1,j]+dp[i,j-1] 到达某个位置的路径数量=到左边一格的位置数量+到上边一格的位置数量
            int[,] dp = new int[m, n];

            //把最左边和最上边格子的值设为1
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int j = 0; j < n; j++)
            {
                dp[0, j] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }

    }
}
