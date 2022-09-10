using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 191. 位1的个数
    /// https://leetcode-cn.com/problems/number-of-1-bits
    /// </summary>
    public class A191_number_of_1_bits
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum++;
                n = n & (n - 1);
            }
            return sum;
        }
    }
}
