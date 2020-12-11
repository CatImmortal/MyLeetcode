using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.动态规划
{
    //https://leetcode-cn.com/problems/coin-change/

    class _0322零钱兑换
    {
        //--------------记忆化搜索，从上到下

        //memo[n] 表示钱币 nn 可以被换取的最少的硬币数，不能换取就为 -1−1
        private int[] memo;

        public int CoinChange(int[] coins, int amount)
        {
            if (coins.Length == 0)
            {
                return -1;
            }

            memo = new int[amount];

            return FindWay(coins, amount);
        }

        private int FindWay(int[] coins, int amount)
        {
            if (amount < 0)
            {
                return -1;
            }

            if (amount == 0)
            {
                return 0;
            }

            //返回已经计算好的值 剪枝
            if (memo[amount - 1] != 0)
            {
                return memo[amount - 1];
            }

            int min = int.MaxValue;

            for (int i = 0; i < coins.Length; i++)
            {
                //计算所有可能的子树
                int result = FindWay(coins, amount - coins[i]);

                if (result >= 0 && result < min)
                {
                    min = result + 1;// 加1，是为了加上得到result结果的那个步骤中，兑换的一个硬币
                }
            }

            if (min == int.MaxValue)
            {
                memo[amount - 1] = -1;
            }
            else
            {
                memo[amount - 1] = min;
            }

            return memo[amount - 1];
        }


        //--------------动态规划，从下到上
        public int CoinChange2(int[] coins, int amount)
        {
            if (coins.Length == 0)
            {
                return -1;
            }

            // memo[n]的值： 表示的凑成总金额为n所需的最少的硬币个数
            int[] memo = new int[amount + 1];
            memo[0] = 0;

            for (int i = 1; i <= amount; i++)
            {
                int min = int.MaxValue;  //记录这一轮能凑足金额的最少硬币个数

                for (int j = 0; j < coins.Length; j++)  //枚举出使用所有硬币面额的情况
                {
                    //i - coins[j]表示金额减去硬币j的面值后剩下的金额
                    if (i - coins[j] >= 0 && memo[i - coins[j]] < min)
                    {
                        min = memo[i - coins[j]] + 1;  //加上1 因为要多算一个硬币j
                    }
                    
                }

                memo[i] = min;
            }

            if (memo[amount] == int.MaxValue)
            {
                //无解
                return -1;
            }

            return memo[amount];
        }
    }
}
