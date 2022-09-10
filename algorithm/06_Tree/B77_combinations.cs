using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_Tree
{
    //77. 组合
    //https://leetcode-cn.com/problems/combinations


    /// <summary>
    /// 递归 回溯 深度优先  剪支
    /// </summary>
    public class B77_combinations1 
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (k <= 0 || n < k)
            {
                return res;
            }
            // 从 1 开始是题目的设定
            LinkedList<int> path = new LinkedList<int>();
            Dfs(n, k, 1, path, res);
            return res;
        }

        private void Dfs(int n, int k, int begin, LinkedList<int> path, IList<IList<int>> res)
        {
            // 递归终止条件是：path 的长度等于 k
            if (path.Count == k)
            {
                res.Add(path.ToList());
                return;
            }

            // 遍历可能的搜索起点
            for (int i = begin; i <= n - (k - path.Count) + 1; i++)
            {
                // 向路径变量里添加一个数
                path.AddLast(i);
                // 下一轮搜索，设置的搜索起点要加 1，因为组合数理不允许出现重复的元素
                Dfs(n, k, i + 1, path, res);
                // 重点理解这里：深度优先遍历有回头的过程，因此递归之前做了什么，递归之后需要做相同操作的逆向操作
                path.RemoveLast();
            }
        }

    }

    public class B77_combinations2
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (k <= 0 || n < k)
            {
                return res;
            }

            // 为了防止底层动态数组扩容，初始化的时候传入最大长度
            LinkedList<int> path = new LinkedList<int>();
            dfs(1, n, k, path, res);
            return res;
        }

        private void dfs(int begin, int n, int k, LinkedList<int> path, IList<IList<int>> res)
        {
            if (k == 0)
            {
                res.Add(path.ToList());
                return;
            }

            // 基础版本的递归终止条件：if (begin == n + 1) {
            if (begin > n - k + 1)
            {
                return;
            }
            // 不选当前考虑的数 begin，直接递归到下一层
            dfs(begin + 1, n, k, path, res);

            // 不选当前考虑的数 begin，递归到下一层的时候 k - 1，这里 k 表示还需要选多少个数
            path.AddLast(begin);
            dfs(begin + 1, n, k - 1, path, res);
            // 深度优先遍历有回头的过程，因此需要撤销选择
            path.RemoveLast();
        }
    }


}
