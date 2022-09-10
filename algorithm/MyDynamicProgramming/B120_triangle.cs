using System;
using System.Collections.Generic;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 120. 三角形最小路径和 (中等)
    /// https://leetcode-cn.com/problems/triangle
    /// 动态规划
    /// </summary>
    public class B120_triangle
    {

        /// <summary>
        /// 动态规划  自低向上
        /// 时间复杂度：O(N^2)  N 为三角形的行数
        /// 空间复杂度：O(N^2)  N 为三角形的行数
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal(IList<IList<int>> triangle)//ok
        {
            int n = triangle.Count;
            // dp[i][j] 表示从点 (i, j) 到底边的最小路径和。
            int[,] dp = new int[n + 1, n + 1];
            // 从三角形的最后一行开始递推。
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    dp[i, j] = Math.Min(dp[i + 1, j], dp[i + 1, j + 1]) + triangle[i][j];
                }
            }
            return dp[0, 0];
        }


        /// <summary>
        /// 动态规划 优化空间复杂度
        /// 时间复杂度：O(N^2)  N 为三角形的行数
        /// 空间复杂度：O(N)    N 为三角形的行数
        /// 2
        /// 3,4
        /// 6,5,7
        /// 4,1,8,3
        /// </summary>
        /// <param name="triangle">[[2],[3,4],[6,5,7],[4,1,8,3]]</param>
        /// <returns></returns>
        public int MinimumTotal2(IList<IList<int>> triangle)//ok
        {
            if (triangle == null || triangle.Count == 0) return 0;

            int n = triangle.Count;
            int[] dp = new int[n + 1];
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[j + 1]) + triangle[i][j];
                }
            }
            return dp[0];

        }

    }
}
