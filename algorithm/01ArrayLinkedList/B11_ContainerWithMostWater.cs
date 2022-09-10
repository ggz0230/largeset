using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 11. 盛最多水的容器 （中等）
    /// https://leetcode-cn.com/problems/container-with-most-water
    /// https://leetcode.com/problems/container-with-most-water
    /// </summary>
    public class B11_ContainerWithMostWater
    {
        /// <summary>
        /// 左右边界i j 向中间收敛
        /// 时间复杂度 线性 O(n)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea2(int[] height)
        {
            int max = 0;
            for (int i = 0, j = height.Length - 1; i < j;)
            {
                int minHeight = height[i] < height[j] ? height[i++] : height[j--];
                int area = (j - i + 1) * minHeight;
                max = Math.Max(max, area);
            }
            return max;
        }


        /// <summary>
        /// 暴力法  2个for 嵌套循环  
        /// 时间复杂度 O(n^2)  指数
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int max = 0;
            for (int i = 0; i < height.Length - 1; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    int area = (j - i) * Math.Min(height[i], height[j]);
                    max = Math.Max(max, area);
                }
            }
            return max;
        }



    }
}
