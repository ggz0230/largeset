using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 1. 两数之和
    /// https://leetcode-cn.com/problems/two-sum/
    /// </summary>
    public class A1_two_sum
    {

        /// <summary>
        /// 暴力法
        /// 时间复杂度 O(n^2)
        /// 空间复杂度 O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] + nums[i] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 两遍哈希表  空间换时间
        /// 时间复杂度 O(n)
        /// 空间复杂度 O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> keyValues = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!keyValues.ContainsKey(nums[i]))
                {
                    keyValues.Add(nums[i], i);
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (keyValues.ContainsKey(complement) && keyValues[complement] != i)
                {
                    return new int[] { i, keyValues[complement] };
                }
            }
            return null;
        }

        /// <summary>
        /// 两遍哈希表  空间换时间
        /// 时间复杂度 O(n)
        /// 空间复杂度 O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum3(int[] nums, int target)
        {
            Dictionary<int, int> keyValues = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];  //complement 补足
                if (keyValues.ContainsKey(complement)) // checks if compliment is in dict
                {
                    return new int[] { keyValues[complement], i };
                }
                else if (!keyValues.ContainsKey(nums[i])) // handles duplicates in array
                {
                    keyValues.Add(nums[i], i);
                }
            }
            return null;
        }

        public int[] TwoSum4(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dic.ContainsKey(complement))
                {
                    return new int[] { dic[complement], i };
                }
                dic[nums[i]] = i;
            }
            return null;
        }

        public int[] TwoSum5(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    return new int[] { dic[nums[i]], i };
                }
                dic[target - nums[i]] = i;
            }
            return null;
        }

    }
}
