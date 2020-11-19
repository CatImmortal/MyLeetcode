using System;

namespace MyLeetcode.贪心算法
{
    //https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/

    class _0121买卖股票的最佳时机
    {
        public int MaxProfit(int[] prices)
        {
            //暴力双层循环

            int ans = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    if (prices[i] < prices[j])
                    {
                        ans = Math.Max(ans, prices[j] - prices[i]);
                    }
                }
            }
            return ans;
        }

        public int MaxProfit2(int[] prices)
        {
            //贪心算法

            int min = int.MaxValue;
            int ans = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    //更新最低价格
                    min = prices[i];
                }
                else if (prices[i] - min > ans)
                {
                    //计算在此之前的最低点购买股票
                    //然后在今天卖出，会有多少收益
                    ans = prices[i] - min;
                }
            }

            return ans;
        }

        public int MaxProfit3(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }

            //动态规划

            //创建两个数组，一个记录每次卖出的最大收益，一个记录每次买入最大收益

            //卖出
            int[] sell = new int[prices.Length];

            //买入
            int[] buy = new int[prices.Length];

            //sell[i]表示到第i天为止的最大卖出收益
            //buy[i]表示到第i天为止的最大买入收益

            sell[0] = 0;
            buy[0] = -prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                //第i天卖出最大收益 = max(第i-1天卖出收益，第i-1天买入收益+当天股价)
                //即昨天卖出的最大收益vs昨天买入今天卖出的最大收益
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);

                //第i天买入收益 = max(第i-1天买入收益，-当天股价)
                //即昨天买入的最大收益vs今天买入的最大收益
                buy[i] = Math.Max(buy[i - 1], -prices[i]);
            }

            return Math.Max(sell[prices.Length - 1], buy[prices.Length - 1]);
        }

        public int MaxProfit4(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }

            //动态规划

            //到第i天为止卖出的最大收益
            int sell = 0;

            //到第i天为止买入的最大收益
            int buy = -prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                //到第i天为止卖出最大收益 = max(第i-1天卖出收益，第i-1天买入收益+当天股价)
                //即到昨天为止卖出的最大收益vs昨天买入今天卖出的最大收益
                sell = Math.Max(sell, buy + prices[i]);

                //到第i天为止买入最大收益 = max(第i-1天买入收益，-当天股价)
                //即到昨天为止买入的最大收益vs今天买入的最大收益
                buy = Math.Max(buy, -prices[i]);
            }

            return Math.Max(sell,buy);
        }
    }
}
