using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 190. 颠倒二进制位
    /// https://leetcode-cn.com/problems/reverse-bits
    /// </summary>
    public class A190_reverse_bits
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public uint reverseBits(uint n)
        {
            uint ans = 0;
            for (int i = 0; i < 32; i++)
            {
                ans = (ans << 1) + (n & 1);
                n >>= 1;
            }
            return ans >> 0;
        }
    }
}
