using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace _06_Tree
{
    public class Test
    {
        //前 中左右
        //中 左中右
        //后 左右中

        
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums.Length == 0) return res;
            HashSet<int> path = new HashSet<int>();
            dfs(nums, res, path);
            return res;
        }

        private void dfs(int[] nums, IList<IList<int>> res, HashSet<int> path)
        {
            if (path.Count == nums.Length)
            {
                res.Add(path.ToList());
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (path.Contains(nums[i])) continue;
                path.Add(nums[i]);
                dfs(nums, res, path);
                path.Remove(nums[i]);
            }
        }


    }

}
