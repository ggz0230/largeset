using System;
using System.Collections.Generic;
using System.Text;

namespace _02_stack_quque
{
    /// <summary>
    /// 239. 滑动窗口最大值
    /// https://leetcode-cn.com/problems/sliding-window-maximum/
    /// </summary>
    public class C239_sliding_window_maximum
    {
        /// <summary>
        /// 双向队列
        /// 时间复杂度O(n)
        /// 空间复杂度O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length < 2) return nums;
            // 双向队列 保存当前窗口最大值的数组位置 保证队列中数组位置的数值按从大到小排序
            LinkedList<int> queue = new LinkedList<int>();
            // 结果数组
            int[] result = new int[nums.Length - k + 1];
            // 遍历nums数组
            for (int i = 0; i < nums.Length; i++)
            {
                // 保证从大到小 如果前面数小则需要依次弹出，直至满足要求
                while (queue.Count > 0 && nums[i] >= nums[queue.Last.Value])
                {
                    queue.RemoveLast();
                }
                // 添加当前值对应的数组下标
                queue.AddLast(i);
                // 判断当前队列中队首的值是否有效
                if (i - queue.First.Value == k)
                {
                    queue.RemoveFirst();
                }
                // 当窗口长度为k时 保存当前窗口中最大值
                if (i + 1 >= k)
                {
                    result[i + 1 - k] = nums[queue.First.Value];
                }
            }
            return result;
        }

        /// <summary>
        /// 动态规划 看不懂
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow2(int[] nums, int k)
        {
            int n = nums.Length;
            if (n * k == 0) return new int[0];
            if (k == 1) return nums;

            int[] left = new int[n];
            left[0] = nums[0];
            int[] right = new int[n];
            right[n - 1] = nums[n - 1];
            for (int i = 1; i < n; i++)
            {
                // from left to right
                if (i % k == 0) left[i] = nums[i];  // block_start
                else left[i] = Math.Max(left[i - 1], nums[i]);

                // from right to left
                int j = n - i - 1;
                if ((j + 1) % k == 0) right[j] = nums[j];  // block_end
                else right[j] = Math.Max(right[j + 1], nums[j]);
            }

            int[] output = new int[n - k + 1];
            for (int i = 0; i < n - k + 1; i++)
                output[i] = Math.Max(left[i + k - 1], right[i]);

            return output;
        }

        //还有单调队列 没去研究

    }
}
