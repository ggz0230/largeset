using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_Tree
{
    //46. 全排列
    //https://leetcode-cn.com/problems/permutations/

    /// <summary>
    /// 递归 回溯
    /// </summary>
    public class B46_permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums.Length == 0)
            {
                return res;
            }

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
