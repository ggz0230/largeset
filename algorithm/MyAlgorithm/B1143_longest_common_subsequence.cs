using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 1143. 最长公共子序列
    /// https://leetcode-cn.com/problems/longest-common-subsequence
    /// </summary>
    public class B1143_longest_common_subsequence
    {

        public int LongestCommonSubsequence(string text1, string text2)
        {
            int[,] matrix = new int[text1.Length + 1, text2.Length + 1];

            for (int i1 = 0; i1 < text1.Length; i1++)
                for (int i2 = 0; i2 < text2.Length; i2++)
                    if (text1[i1] == text2[i2]) matrix[i1 + 1, i2 + 1] = matrix[i1, i2] + 1;
                    else matrix[i1 + 1, i2 + 1] = Math.Max(matrix[i1 + 1, i2], matrix[i1, i2 + 1]);

            return matrix[text1.Length, text2.Length];
        }


    }
}
