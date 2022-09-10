using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 26. 删除排序数组中的重复项
    /// https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array
    /// </summary>
    public class A26_remove_duplicates_from_sorted_array
    {
        /// <summary>
        /// 双指针法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int i = 0, j = 1;
            while (j < nums.Length)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
                j++;
            }
            return i + 1;
        }


        public int RemoveDuplicates2(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            int p = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[p] != nums[i])
                {
                    nums[++p] = nums[i];
                }
            }
            return p + 1;
        }

    }
}
