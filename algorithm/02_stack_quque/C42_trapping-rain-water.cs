using System;
using System.Collections.Generic;
using System.Text;

namespace _02_stack_quque
{
    /// <summary>
    /// 42. 接雨水
    /// https://leetcode-cn.com/problems/trapping-rain-water/
    /// </summary>
    public class C42_trapping_rain_water
    {
        /// <summary>
        /// 动态规划
        /// 时间复杂度O(n)
        /// 空间复杂度O(n)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            int sum = 0;
            int[] max_left = new int[height.Length];
            int[] max_right = new int[height.Length];

            for (int i = 1; i < height.Length - 1; i++)
            {
                max_left[i] = Math.Max(max_left[i - 1], height[i - 1]);
            }

            for (int i = height.Length - 2; i > 0; i--)
            {
                max_right[i] = Math.Max(max_right[i + 1], height[i + 1]);
            }

            for (int i = 1; i < height.Length - 1; i++)
            {
                int min = Math.Min(max_left[i], max_right[i]);
                if (min > height[i])
                {
                    sum = sum + (min - height[i]);
                }
            }

            return sum;
        }

        /// <summary>
        /// 双指针 优化了动态规划
        /// 时间复杂度O(n)
        /// 空间复杂度O(n)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap2(int[] height)
        {
            int sum = 0;
            int max_left = 0;
            int[] max_right = new int[height.Length];
            for (int i = height.Length - 2; i >= 0; i--)
            {
                max_right[i] = Math.Max(max_right[i + 1], height[i + 1]);
            }
            for (int i = 1; i < height.Length - 1; i++)
            {
                max_left = Math.Max(max_left, height[i - 1]);
                int min = Math.Min(max_left, max_right[i]);
                if (min > height[i])
                {
                    sum = sum + (min - height[i]);
                }
            }
            return sum;
        }

        /// <summary>
        /// 双指针 继续优化了动态规划
        /// 时间复杂度O(n)
        /// 空间复杂度O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap3(int[] height)
        {
            int sum = 0;
            int max_left = 0, max_right = 0;
            int left = 1, right = height.Length - 2; // 加右指针进去
            for (int i = 1; i < height.Length - 1; i++)
            {
                //从左到右更
                if (height[left - 1] < height[right + 1])
                {
                    max_left = Math.Max(max_left, height[left - 1]);
                    int min = max_left;
                    if (min > height[left])
                    {
                        sum = sum + (min - height[left]);
                    }
                    left++;
                }
                else
                {
                    //从右到左更
                    max_right = Math.Max(max_right, height[right + 1]);
                    int min = max_right;
                    if (min > height[right])
                    {
                        sum = sum + (min - height[right]);
                    }
                    right--;
                }
            }
            return sum;
        }


        /// <summary>
        /// 栈 比较容易理解和写
        /// 时间复杂度O(n)
        /// 空间复杂度O(n)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap4(int[] height)
        {
            int sum = 0;
            Stack<int> stack = new Stack<int>();
            int current = 0;
            while (current < height.Length)
            {
                //如果栈不空并且当前指向的高度大于栈顶高度就一直循环
                while (stack.Count > 0 && height[current] > height[stack.Peek()])
                {
                    int h = height[stack.Pop()]; //取出要出栈的元素
                    if (stack.Count == 0) break;// 栈空就出去
                    int distance = current - stack.Peek() - 1; //两堵墙之前的距离。
                    int min = Math.Min(height[stack.Peek()], height[current]);//左右2堵墙最矮的高度
                    sum = sum + distance * (min - h);
                }
                stack.Push(current); //当前指向的墙入栈
                current++; //指针后移
            }
            return sum;
        }

        /// <summary>
        /// LeetCode上最快的解法
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap5(int[] height)
        {
            if (height.Length <= 2) return 0;

            int n = height.Length;
            int head = 0;
            int tail = n - 1;
            int leftMax = height[0];
            int rightMax = height[n - 1];
            int ans = 0;

            while (head < tail)
            {
                leftMax = Math.Max(leftMax, height[head]);
                rightMax = Math.Max(rightMax, height[tail]);

                if (leftMax < rightMax) ans += leftMax - height[head++];
                else ans += rightMax - height[tail--];
            }

            return ans;
        }


    }
}
