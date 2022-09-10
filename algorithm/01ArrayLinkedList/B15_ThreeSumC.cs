using System;
using System.Collections.Generic;
using System.Text;

namespace _01ArrayLinkedList
{
    /// <summary>
    /// 15. 三数之和  （高频老题） （中等） 
    /// https://leetcode-cn.com/problems/3sum
    /// https://leetcode.com/problems/3sum
    /// </summary>
    public class B15_ThreeSumC
    {

        /// <summary>
        /// 先排序+双指针 https://leetcode-cn.com/problems/3sum/solution/3sumpai-xu-shuang-zhi-zhen-yi-dong-by-jyd/
        /// 时间复杂度 O(N^2)
        /// 空间复杂度 O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            for (int k = 0; k < nums.Length - 2; k++)
            {
                if (nums[k] > 0) break;
                if (k > 0 && nums[k] == nums[k - 1]) continue;
                int i = k + 1, j = nums.Length - 1;
                while (i < j)
                {
                    int sum = nums[k] + nums[i] + nums[j];
                    if (sum < 0)
                    {
                        while (i < j && nums[i] == nums[++i]) ;
                    }
                    else if (sum > 0)
                    {
                        while (i < j && nums[j] == nums[--j]) ;
                    }
                    else
                    {
                        res.Add(new List<int>() { nums[k], nums[i], nums[j] });
                        while (i < j && nums[i] == nums[++i]) ;
                        while (i < j && nums[j] == nums[--j]) ;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 暴力法 3个for循环 不可行
        /// 时间复杂度 O(N^3)
        /// 空间复杂度 O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            { // 每个人
                for (int j = i + 1; j < nums.Length - 1; j++)
                { // 依次拉上其他每个人
                    for (int k = j + 1; k < nums.Length; k++)
                    { // 去问剩下的每个人
                        if (nums[i] + nums[j] + nums[k] == 0)
                        { // 我们是不是可以一起组队
                            res.Add(new List<int>() { nums[i], nums[j], nums[k] });
                            //需要去重复的代码
                        }
                    }
                }
            }
            return res;
        }


      


    }
}
