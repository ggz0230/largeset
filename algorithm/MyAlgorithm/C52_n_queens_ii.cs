using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 52. N皇后 II
    /// https://leetcode-cn.com/problems/n-queens-ii
    /// </summary>
    public class C52_n_queens_ii
    {
        private int size;
        private int count;
        /// <summary>
        /// 位运算 终极解决方案 看不懂 看2个星期
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TotalNQueens(int n)
        {
            count = 0;
            size = (1 << n) - 1;
            Solve(0, 0, 0);
            return count;
        }
        public void Solve(int row, int id, int rd)
        {
            if (row == size)
            {
                count++;
                return;
            }
            int pos = size & (~(row | id | rd));
            while (pos != 0)
            {
                int p = pos & (-pos);
                pos -= p;
                Solve(row | p, (id | p) << 1, (rd | p) >> 1);
            }
        }
    }
}
