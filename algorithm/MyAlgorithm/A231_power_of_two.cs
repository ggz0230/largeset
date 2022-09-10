using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 231. 2的幂
    /// https://leetcode-cn.com/problems/power-of-two
    /// </summary>
    public class A231_power_of_two
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

    }
}
