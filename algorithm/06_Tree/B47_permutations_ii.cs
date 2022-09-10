using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_Tree
{
    //47. 全排列 II
    //https://leetcode-cn.com/problems/permutations-ii/

    /// <summary>
    /// 递归 回溯 剪支
    /// </summary>
    public class B47_permutations_ii
    {

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums.Length == 0)
            {
                return res;
            }

            // 排序（升序或者降序都可以），排序是剪枝的前提
            Array.Sort(nums);

            bool[] used = new bool[nums.Length];
            // 使用 Deque 是 Java 官方 Stack 类的建议
            LinkedList<int> path = new LinkedList<int>();
            dfs(nums, 0, used, path, res);
            return res;
        }

        private void dfs(int[] nums, int depth, bool[] used, LinkedList<int> path, IList<IList<int>> res)
        {
            if (depth == nums.Length)
            {
                res.Add(path.ToList());
                return;
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (used[i]) continue;

                // 剪枝条件：i > 0 是为了保证 nums[i - 1] 有意义
                // 写 !used[i - 1] 是因为 nums[i - 1] 在深度优先遍历的过程中刚刚被撤销选择
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;

                path.AddLast(nums[i]);
                used[i] = true;

                dfs(nums, depth + 1, used, path, res);
                // 回溯部分的代码，和 dfs 之前的代码是对称的
                used[i] = false;
                path.RemoveLast();
            }
        }

    }



}
