using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 63. 不同路径 II （中等）
    /// https://leetcode-cn.com/problems/unique-paths-ii
    /// 动态规划
    /// </summary>
    public class B63_unique_paths_ii
    {

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.Length == 0) return 0;

            // 定义 dp 数组并初始化第 1 行和第 1 列。
            int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
            int[,] dp = new int[m, n];

            for (int j = 0; j < n && obstacleGrid[0][j] == 0; j++) dp[0, j] = 1;

            for (int i = 0; i < m && obstacleGrid[i][0] == 0; i++) dp[i, 0] = 1;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 0) dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }

       
        /// <summary>
        /// 优化空间 最优解
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles3(int[][] obstacleGrid)
        {
            int width = obstacleGrid[0].Length;
            int[] dp = new int[width];
            dp[0] = 1;
            foreach (var row in obstacleGrid)
            {
                for (int j = 0; j < width; j++)
                {
                    if (row[j] == 1)
                    {
                        dp[j] = 0;
                    }
                    else if (j > 0)
                    {
                        dp[j] += dp[j - 1];
                    }
                }
            }
            return dp[width - 1];
        }

    }
}
