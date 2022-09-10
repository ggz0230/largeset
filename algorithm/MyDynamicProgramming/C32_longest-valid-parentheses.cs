using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 最长有效括号 （困难） 太复杂了 暂时不会做
    /// https://leetcode-cn.com/problems/longest-valid-parentheses
    /// </summary>
    public class C32_longest_valid_parentheses
    {

        public int LongestValidParentheses(string s)
        {
            int maxans = 0;
            int[] dp = new int[s.Length];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (s[i - 1] == '(')
                    {
                        dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                    }
                    else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                    {
                        dp[i] = dp[i - 1] + ((i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                    }
                    maxans = Math.Max(maxans, dp[i]);
                }
            }
            return maxans;
        }

    }
}
