using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 64. 最小路径和 （中等）
    /// https://leetcode-cn.com/problems/minimum-path-sum
    /// 动态规划 
    /// </summary>
    public class B64_minimum_path_sum
    {

        public int MaxProfit(int[] prices)
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
