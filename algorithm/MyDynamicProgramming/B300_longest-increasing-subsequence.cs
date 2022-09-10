using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 300. 最长上升子序列 （中等）
    /// https://leetcode-cn.com/problems/longest-increasing-subsequence
    /// 动态规划
    /// </summary>
    public class B300_longest_increasing_subsequence
    {
        /// <summary>
        /// 动态规划 
        /// 时间复杂度 O(n^2)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int[] dp = new int[nums.Length];
            int res = 0;
            Array.Fill(dp, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i]) dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                res = Math.Max(res, dp[i]);
            }
            return res;
        }

        /// <summary>
        /// 正常人基本想不到这种解法 正常情况下能够给出动态规划解法就已经很不错了。 以下的二分查找的
        /// https://leetcode-cn.com/problems/longest-increasing-subsequence/solution/dong-tai-gui-hua-she-ji-fang-fa-zhi-pai-you-xi-jia
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS4(int[] nums)
        {
            int[] top = new int[nums.Length];
            // 牌堆数初始化为 0
            int piles = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                // 要处理的扑克牌
                int poker = nums[i];

                /***** 搜索左侧边界的二分查找 *****/
                int left = 0, right = piles;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (top[mid] > poker)
                    {
                        right = mid;
                    }
                    else if (top[mid] < poker)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                /*********************************/

                // 没找到合适的牌堆，新建一堆
                if (left == piles) piles++;
                // 把这张牌放到牌堆顶
                top[left] = poker;
            }
            // 牌堆数就是 LIS 长度
            return piles;
        }

        /// <summary>
        /// 动态规划+二分查找+贪心
        /// 时间复杂度 O(NlogN)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS2(int[] nums)
        {
            int len = nums.Length;
            if (len <= 1) return len;

            // tail 数组的定义：长度为 i + 1 的上升子序列的末尾最小是几
            int[] tail = new int[len];
            // 遍历第 1 个数，直接放在有序数组 tail 的开头
            tail[0] = nums[0];
            // end 表示有序数组 tail 的最后一个已经赋值元素的索引
            int end = 0;

            for (int i = 1; i < len; i++)
            {
                // 【逻辑 1】比 tail 数组实际有效的末尾的那个元素还大
                if (nums[i] > tail[end])
                {
                    // 直接添加在那个元素的后面，所以 end 先加 1
                    end++;
                    tail[end] = nums[i];
                }
                else
                {
                    // 使用二分查找法，在有序数组 tail 中
                    // 找到第 1 个大于等于 nums[i] 的元素，尝试让那个元素更小
                    int left = 0;
                    int right = end;
                    while (left < right)
                    {
                        // 选左中位数不是偶然，而是有原因的，原因请见 LeetCode 第 35 题题解
                        int mid = left + (right - left) / 2;
                        //int mid = left + ((right - left) >>> 1);
                        if (tail[mid] < nums[i])
                        {
                            // 中位数肯定不是要找的数，把它写在分支的前面
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid;
                        }
                    }
                    // 走到这里是因为 【逻辑 1】 的反面，因此一定能找到第 1 个大于等于 nums[i] 的元素
                    // 因此，无需再单独判断
                    tail[left] = nums[i];
                }
                // 调试方法
                // printArray(nums[i], tail);
            }
            // 此时 end 是有序数组 tail 最后一个元素的索引
            // 题目要求返回的是长度，因此 +1 后返回
            end++;
            return end;
        }

        /// <summary>
        /// 动态规划+二分查找
        /// 时间复杂度 O(NlogN)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS3(int[] nums)
        {
            int[] tails = new int[nums.Length];
            int res = 0;
            foreach (int num in nums)
            {
                int i = 0, j = res;
                while (i < j)
                {
                    int m = (i + j) / 2;
                    if (tails[m] < num) i = m + 1;
                    else j = m;
                }
                tails[i] = num;
                if (res == j) res++;
            }
            return res;
        }

    }
}
