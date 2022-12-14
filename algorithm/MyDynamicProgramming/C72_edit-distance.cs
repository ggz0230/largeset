using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 72. 编辑距离 (困难)
    /// https://leetcode-cn.com/problems/edit-distance
    /// 动态规划
    /// </summary>
    public class C72_edit_distance
    {
        public int MinDistance(string word1, string word2)
        {
            int n1 = word1.Length;
            int n2 = word2.Length;
            int[,] dp = new int[n1 + 1, n2 + 1];
            // 第一行
            for (int j = 1; j <= n2; j++) dp[0, j] = dp[0, j - 1] + 1;
            // 第一列
            for (int i = 1; i <= n1; i++) dp[i, 0] = dp[i - 1, 0] + 1;

            for (int i = 1; i <= n1; i++)
            {
                for (int j = 1; j <= n2; j++)
                {
                    if (word1[i - 1] == word2[j - 1]) dp[i, j] = dp[i - 1, j - 1];
                    else dp[i, j] = Math.Min(Math.Min(dp[i - 1, j - 1], dp[i, j - 1]), dp[i - 1, j]) + 1;
                }
            }
            return dp[n1, n2];
        }
    }
}
