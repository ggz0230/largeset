using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace _08_DivideRule_Recall
{
    /// <summary>
    /// 78. 子集
    /// https://leetcode-cn.com/problems/subsets
    /// https://leetcode.com/problems/subsets
    /// </summary>
    public class B78_Subsets
    {
        #region 分治  有错误
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            if (nums == null) return ans;
            Dfs(ans, nums, new List<int>(), 0);
            return ans;
        }

        private void Dfs(IList<IList<int>> ans, int[] nums, List<int> list, int index)
        {
            if (index == nums.Length)
            {
                ans.Add(list);
                return;
            }
            Dfs(ans, nums, list, index + 1);
            list.Add(nums[index]);
            Dfs(ans, nums, list, index + 1);

            list.RemoveAt(list.Count - 1);
        }


        #endregion

        /// <summary>
        /// 递归
        /// 时间复杂度和空间复杂度 O(2^n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets2(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return ans;

            ans.Add(new List<int>());

            foreach (var num in nums)
            {
                int cnt = ans.Count;
                for (int i = 0; i < cnt; i++)
                {
                    ans.Add(new List<int>(ans[i]) { num });
                }
            }

            return ans;
        }




        #region MyRegion
        IList<IList<int>> res = new List<IList<int>>();
        public IList<IList<int>> Subsets3(int[] nums)
        {
            for (int i = 0; i < nums.Length + 1; i++)
                Backtracking(i, new LinkedList<int>(), 0, nums);
            return res;
        }

        private void Backtracking(int count, LinkedList<int> link, int idx, int[] nums)
        {
            if (link.Count == count)
            {
                res.Add(link.ToList());
                return;
            }
            for (int i = idx; i < nums.Length; i++)
            {
                link.AddLast(nums[i]);
                Backtracking(count, link, i + 1, nums);
                link.RemoveLast();
            }
        }
        #endregion

    }
}
