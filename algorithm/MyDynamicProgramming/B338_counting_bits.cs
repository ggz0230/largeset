using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicProgramming
{
    /// <summary>
    /// 338. 比特位计数 （中等）
    /// https://leetcode-cn.com/problems/counting-bits
    /// </summary>
    public class B338_counting_bits
    {
        /// <summary>
        /// 动态规划 + 位运算
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int[] CountBits(int num)
        {
            int[] bits = new int[num + 1];
            for (int i = 1; i <= num; i++)
            {
                bits[i] = bits[i & (i - 1)] + 1;
            }
            return bits;
        }
    }
}
