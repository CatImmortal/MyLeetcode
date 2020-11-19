using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.贪心算法
{
    //https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/

    class _0122买卖股票的最佳时机2
    {
        private int ans = 0;

        public int MaxProfit(int[] prices)
        {
            //暴力搜索出所有解
            if (prices.Length < 2)
            {
                return 0;
            }

            Dfs(prices, 0, prices.Length, false, ans);

            return ans;

        }

        /// <summary>
        /// 暴力搜索
        /// </summary>
        /// <param name="index">当前是第几天，从0开始</param>
        /// <param name="state">是否持有股票</param>
        /// <param name="profit">当前收益</param>
        private void Dfs(int[] prices, int index, int len, bool state, int profit)
        {


            if (index == len)
            {
                ans = Math.Max(ans, profit);
                return;
            }

            //不操作
            Dfs(prices, index + 1, len, state, profit);

            if (state == false)
            {
                //未持有股票 尝试买入
                Dfs(prices, index + 1, len, true, profit - prices[index]);
            }
            else
            {
                //持有股票 尝试卖出
                Dfs(prices, index + 1, len, false, profit + prices[index]);
            }
        }

        public int MaxProfit2(int[] prices)
        {
            //贪心算法

            int ans = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                int sum = prices[i + 1] - prices[i];
                if (sum > 0)
                {
                    ans += sum;
                }
            }

            return ans;
        }


        public int MaxProfit3(int[] prices) {
            //动态规划
            if (prices.Length < 2)
            {
                return 0;
            }

            // cash：持有现金
            // hold：持有股票
            // 状态转移：cash → hold → cash → hold → cash → hold → cash

            int cash = 0;
            int hold = -prices[0];

            int preCash = cash;
            int preHold = hold;
            for (int i = 1; i < prices.Length; i++)
            {
                //第i天最大持有现金=max(昨天持有现金,昨天持有股票今天卖出股票)
                cash = Math.Max(preCash, preHold + prices[i]);

                //第i天最大持有股票=max(昨天持有股票,昨天持有现金今天买入股票)
                hold = Math.Max(preHold, preCash - prices[i]);

                preCash = cash;
                preHold = hold;
            }
            return cash;
        }
    }
}
