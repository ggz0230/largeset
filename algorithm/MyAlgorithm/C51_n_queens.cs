using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 51. N 皇后
    /// https://leetcode-cn.com/problems/n-queens
    /// https://leetcode.com/problems/n-queens
    /// </summary>
    public class C51_n_queens
    {
        /// <summary>
        /// 剪支
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> res = new List<IList<string>>();
            int[] queens = new int[n];
            Array.Fill(queens, -1);
            HashSet<int> columns = new HashSet<int>();
            HashSet<int> diagonals1 = new HashSet<int>();
            HashSet<int> diagonals2 = new HashSet<int>();
            backtrack(queens, 0);
            return res;

            void backtrack(int[] queens, int row)
            {
                if (row == n)
                {
                    List<string> board = generateBoard(queens);
                    res.Add(board);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (columns.Contains(i))
                        {
                            continue;
                        }
                        int diagonal1 = row - i;
                        if (diagonals1.Contains(diagonal1))
                        {
                            continue;
                        }
                        int diagonal2 = row + i;
                        if (diagonals2.Contains(diagonal2))
                        {
                            continue;
                        }
                        queens[row] = i;
                        columns.Add(i);
                        diagonals1.Add(diagonal1);
                        diagonals2.Add(diagonal2);
                        backtrack(queens, row + 1);
                        queens[row] = -1;
                        columns.Remove(i);
                        diagonals1.Remove(diagonal1);
                        diagonals2.Remove(diagonal2);
                    }
                }
            }

            List<string> generateBoard(int[] queens)
            {
                List<string> board = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    char[] row = new char[n];

                    Array.Fill(row, '.');
                    row[queens[i]] = 'Q';
                    board.Add(new string(row));
                }
                return board;
            }

        }


    }
}
