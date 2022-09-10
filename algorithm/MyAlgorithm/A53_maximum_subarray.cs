using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 53. 最大子序和
    /// https://leetcode-cn.com/problems/maximum-subarray
    /// </summary>
    public class A53_maximum_subarray
    {
        public int MaxSubArray(int[] nums)
        {
            int[] dp = nums;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
            }
            return dp.Max();
        }
    }
}
