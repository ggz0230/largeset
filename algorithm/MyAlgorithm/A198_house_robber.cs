using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 198. 打家劫舍
    /// https://leetcode-cn.com/problems/house-robber
    /// 动态规范  
    /// </summary>
    public class A198_house_robber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob2(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            int res = Math.Max(dp[0], dp[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
                res = Math.Max(res, dp[i]);
            }
            return res;
        }

        /// <summary>
        /// 终极解决方案 优化了空间复杂度 O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob3(int[] nums)
        {
            int prevMax = 0;
            int currMax = 0;
            foreach (var item in nums)
            {
                int temp = currMax;
                currMax = Math.Max(prevMax + item, currMax);
                prevMax = temp;
            }
            return currMax;
        }


        /// <summary>
        /// 可读性差
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;
            int[,] a = new int[n, 2];

            a[0, 0] = 0;
            a[0, 1] = nums[0];

            for (int i = 1; i < n; i++)
            {
                a[i, 0] = Math.Max(a[i - 1, 0], a[i - 1, 1]);
                a[i, 1] = a[i - 1, 0] + nums[i];
            }
            return Math.Max(a[n - 1, 0], a[n - 1, 1]);
        }


       
    }
}
