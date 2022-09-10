using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 746. 使用最小花费爬楼梯
    /// https://leetcode-cn.com/problems/min-cost-climbing-stairs
    /// </summary>
    public class N746_min_cost_climbing_stairs
    {

        public int MinCostClimbingStairs(int[] cost)
        {
            int size = cost.Length;
            int[] dp = new int[size];
            dp[0] = 0;
            dp[1] = Math.Min(cost[0], cost[1]);
            for (int i = 2; i < size; i++)
            {
                dp[i] = Math.Min(cost[i] + dp[i - 1], cost[i - 1] + dp[i - 2]);
            }
            return dp[size];
        }

        /// <summary>
        /// 优化了空间
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs2(int[] cost)
        {
            int dp0 = 0;
            int dp1 = Math.Min(cost[0], cost[1]);
            int min = 0;
            for (int i = 2; i < cost.Length; i++)
            {
                min = Math.Min(dp1 + cost[i], dp0 + cost[i - 1]);
                dp0 = dp1;
                dp1 = min;
            }
            return min;
        }

    }
}
