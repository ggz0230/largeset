using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _02_stack_quque
{
    /// <summary>
    /// 84. 柱状图中最大的矩形
    /// https://leetcode-cn.com/problems/largest-rectangle-in-histogram
    /// https://leetcode.com/problems/largest-rectangle-in-histogram
    /// </summary>
    public class C84_LargestRectangleInHistogram
    {

        /// <summary>
        /// 暴力法
        /// 时间复杂度O(n^2)
        /// 空间复杂度O(1)
        /// https://leetcode-cn.com/problems/largest-rectangle-in-histogram/solution/bao-li-jie-fa-zhan-by-liweiwei1419/
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleArea(int[] heights)
        {
            int len = heights.Length;
            // 特判
            if (len == 0) return 0;

            int res = 0;
            for (int i = 0; i < len; i++)
            {

                // 找左边最后 1 个大于等于 heights[i] 的下标
                int left = i;
                int curHeight = heights[i];
                while (left > 0 && heights[left - 1] >= curHeight) left--;

                // 找右边最后 1 个大于等于 heights[i] 的索引
                int right = i;
                while (right < len - 1 && heights[right + 1] >= curHeight) right++;

                res = Math.Max(res, (right - left + 1) * curHeight);
            }
            return res;
        }

        /// <summary>
        /// 栈+哨兵
        /// 时间复杂度O(n)
        /// 空间复杂度O(n)
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleArea2(int[] heights)
        {
            // 这里为了代码简便，在柱体数组的头和尾加了两个高度为 0 的柱体。
            int[] arr = new int[heights.Length + 2];

            Array.Copy(heights, 0, arr, 1, heights.Length);

            Stack<int> stack = new Stack<int>();
            int res = 0;
            //[2,1,5,6,2,3]
            //[0,2,1,5,6,2,3,0]
            for (int i = 0; i < arr.Length; i++)
            {
                // 对栈中柱体来说，栈中的下一个柱体就是其「左边第一个小于自身的柱体」；
                // 若当前柱体 i 的高度小于栈顶柱体的高度，说明 i 是栈顶柱体的「右边第一个小于栈顶柱体的柱体」。
                // 因此以栈顶柱体为高的矩形的左右宽度边界就确定了，可以计算面积🌶️ ～
                while (stack.Count != 0 && arr[i] < arr[stack.Peek()])
                {
                    int height = arr[stack.Pop()];
                    int area = (i - stack.Peek() - 1) * height;//面积=宽度*高度
                    res = Math.Max(res, area);
                }
                stack.Push(i);
            }

            return res;
        }

        /// <summary>
        /// 栈 官方的 看不懂
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleArea3(int[] heights)
        {
            int n = heights.Length;
            int[] left = new int[n];
            int[] right = new int[n];
            Array.Fill(right, n);

            Stack<int> st = new Stack<int>();
            for (int i = 0; i < n; ++i)
            {
                while (st.Count > 0 && heights[st.Peek()] >= heights[i])
                {
                    right[st.Pop()] = i;
                }
                left[i] = (st.Count == 0 ? -1 : st.Peek());
                st.Push(i);
            }

            int ans = 0;
            for (int i = 0; i < n; ++i)
            {
                ans = Math.Max(ans, (right[i] - left[i] - 1) * heights[i]);
            }
            return ans;
        }

    }
}
