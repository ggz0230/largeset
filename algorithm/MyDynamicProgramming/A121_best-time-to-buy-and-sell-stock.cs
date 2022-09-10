using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 121. 买卖股票的最佳时机 
    /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock
    /// 动态规划
    /// </summary>
    public class A121_best_time_to_buy_and_sell_stock
    {
        public int MaxProfit(int[] prices)
        {
            int len = prices.Length;
            if (len < 2) return 0;

            // 0：用户手上不持股所能获得的最大利润，特指卖出股票以后的不持股，非指没有进行过任何交易的不持股
            // 1：用户手上持股所能获得的最大利润

            // 注意：因为题目限制只能交易一次，因此状态只可能从 1 到 0，不可能从 0 到 1
            int[,] dp = new int[len, 2];
            dp[0, 0] = 0;
            dp[0, 1] = -prices[0];
            for (int i = 1; i < len; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(-prices[i], dp[i - 1, 1]);
            }
            return dp[len - 1, 0];
        }

        /// <summary>
        /// 优化空间 最优解
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit2(int[] prices)
        {
            int len = prices.Length;
            if (len < 2) return 0;

            int[] dp = new int[2];
            dp[0] = 0;
            dp[1] = -prices[0];
            for (int i = 1; i < len; i++)
            {
                dp[0] = Math.Max(dp[0], dp[1] + prices[i]);
                dp[1] = Math.Max(-prices[i], dp[1]);
            }
            return dp[0];
        }
    }
}
