using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 66. 加一
    /// https://leetcode-cn.com/problems/plus-one/
    /// </summary>
    public class A66_plus_one
    {

        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;
        }


    }
}
