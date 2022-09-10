using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 62. 不同路径 （中等）
    /// https://leetcode-cn.com/problems/unique-paths
    /// 动态规范
    /// </summary>
    public class B62_unique_paths
    {
        public int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];
            for (int i = 0; i < n; i++) dp[0, i] = 1;
            for (int i = 0; i < m; i++) dp[i, 0] = 1;
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }

        /// <summary>
        /// 优化空间 只保留当前行和上一行的数据就行了
        /// </summary>
        /// <returns></returns>
        public int UniquePaths2(int m, int n)
        {
            int[] pre = new int[n];//上一行
            int[] cur = new int[n];//当前行
            Array.Fill(pre, 1);
            Array.Fill(cur, 1);
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    cur[j] = cur[j - 1] + pre[j];
                }
                pre = (int[])cur.Clone();
            }
            return pre[n - 1];
        }

        /// <summary>
        /// 优化空间 最优解
        /// </summary>
        /// <returns></returns>
        public int UniquePaths3(int m, int n)
        {
            int[] cur = new int[n];
            Array.Fill(cur, 1);
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    cur[j] += cur[j - 1];
                }
            }
            return cur[n - 1];
        }

    }
}
