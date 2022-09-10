using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 283. 移动零
    /// https://leetcode-cn.com/problems/move-zeroes
    /// https://leetcode.com/problems/move-zeroes
    /// 输入: [0,1,0,3,12]
    /// 输出: [1,3,12,0,0]
    /// </summary>
    public class A283_MoveZeroe
    {

        /// <summary>
        /// 双下标
        /// 时间复杂度 O(n)  线数
        /// 空间复杂度
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j] = nums[i];
                    if (i != j)
                    {
                        nums[i] = 0;
                    }
                    j++;
                }
            }
        }

        /// <summary>
        /// 类似冒泡
        /// </summary>
        public void MoveZeroes2(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    int temp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = temp;
                    j++;
                }
            }
        }

    }
}
