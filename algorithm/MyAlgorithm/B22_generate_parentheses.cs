using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 括号生成
    /// https://leetcode-cn.com/problems/generate-parentheses
    /// https://leetcode.com/problems/generate-parentheses
    /// </summary>
    public class B22_generate_parentheses
    {
        /// <summary>
        /// 暴力法 递归  不可行
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> res = new List<string>();
            dfs(new char[2 * n], 0);
            return res;

            void dfs(char[] current, int pos)
            {
                if (pos == current.Length)
                {
                    if (valid(current)) res.Add(new String(current));
                }
                else
                {
                    current[pos] = '(';
                    dfs(current, pos + 1);
                    current[pos] = ')';
                    dfs(current, pos + 1);
                }
            }

            bool valid(char[] current)
            {
                int b = 0;
                foreach (var item in current)
                {
                    if (item == '(') b++;
                    else b--;
                    if (b < 0) return false;
                }
                return b == 0;
            }
        }
    }

    /*
 回溯算法实际上一个类似枚举的搜索尝试过程，主要是在搜索尝试过程中寻找问题的解，当发现已不满足求解条件时，就 “回溯” 返回，尝试别的路径。回溯法是一种选优搜索法，按选优条件向前搜索，以达到目标。但当探索到某一步时，发现原先选择并不优或达不到目标，就退回一步重新选择，这种走不通就退回再走的技术为回溯法，而满足回溯条件的某个状态的点称为 “回溯点”。许多复杂的，规模较大的问题都可以使用回溯法，有“通用解题方法”的美称。

 回溯算法的基本思想是：从一条路往前走，能进则进，不能进则退回来，换一条路再试。
     */

    /// <summary>
    /// 深度优先  回溯算法  递归  做减法  剪支
    /// </summary>
    public class B22_generate_parentheses1
    {
        /// <summary>
        /// 入口函数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> res = new List<string>();
            if (n > 0) DFS("", n, n, res);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curStr"></param>
        /// <param name="left">左括号还有几个可以使用</param>
        /// <param name="right">右括号还有几个可以使用</param>
        /// <param name="res"></param>
        private void DFS(string curStr, int left, int right, List<string> res)
        {
            // 因为每一次尝试，都使用新的字符串变量，所以无需回溯
            // 在递归终止的时候，直接把它添加到结果集即可
            if (left == 0 && right == 0)
            {
                res.Add(curStr);
                return;
            }

            // 剪枝（如图，左括号可以使用的个数严格大于右括号可以使用的个数，才剪枝，注意这个细节）
            if (left > right) return;

            if (left > 0) DFS(curStr + "(", left - 1, right, res);
            if (right > 0) DFS(curStr + ")", left, right - 1, res);
        }
    }

    /// <summary>
    /// 深度优先  回溯算法  递归  做加法  剪支
    /// </summary>
    public class B22_generate_parentheses2
    {
        /// <summary>
        /// 入口
        /// </summary>
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> res = new List<string>();
            if (n > 0) DFS("", 0, 0, res, n);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curStr"></param>
        /// <param name="left">左括号用了多少个</param>
        /// <param name="right">右括号用了多少个</param>
        /// <param name="res"></param>
        /// <param name="n"></param>
        private void DFS(string curStr, int left, int right, List<string> res, int n)
        {
            if (left == n && right == n)
            {
                res.Add(curStr);
                return;
            }
            if (left < right) return;
            if (left < n) DFS(curStr + "(", left + 1, right, res, n);
            if (right < n) DFS(curStr + ")", left, right + 1, res, n);
        }

    }

    //广度优先解法 先不看

}
