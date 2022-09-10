using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 70 爬楼梯
    /// https://leetcode-cn.com/problems/climbing-stairs
    /// https://leetcode.com/problems/climbing-stairs
    /// </summary>
    public class A70_ClimbingStairs
    {

        /// <summary>
        /// 动态规划    
        /// 时间复杂度 O(n)  线性
        /// 空间复杂度 O(n)  线性
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs2(int n)
        {
            if (n == 1) return 1;//特殊情况，n=1往下走会报错

            int[] arr = new int[n + 1];
            arr[1] = 1;
            arr[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[n];
        }

        /// <summary>
        /// 斐波那契数列 动态规划优化空间
        /// 时间复杂度 O(n)  线数
        /// 空间复杂度 O(1)  常数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs3(int n)
        {
            if (n == 1) return 1;
            int first = 1;
            int second = 2;
            for (int i = 3; i <= n; i++)
            {
                int third = first + second;
                first = second;
                second = third;
            }
            return second;
        }

        /// <summary>
        /// 递归  超出时间限制，不能通过
        /// 时间复杂度 O(2^n)  指数
        /// 空间复杂度 O(n)  线性
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n <= 2) return n;
            return ClimbStairs(n - 2) + ClimbStairs(n - 1);
        }

        /// <summary>
        /// 递归+缓存
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs1(int n)
        {
            int[] cached = new int[n + 1];//缓存
            return ClimbDP(n);

            int ClimbDP(int n)  //递归函数
            {
                if (n <= 2) return n;

                if (cached[n] != 0)
                {
                    return cached[n];
                }
                else
                {
                    cached[n] = ClimbDP(n - 1) + ClimbDP(n - 2);
                    return cached[n];
                }
            }

        }


    }
}
