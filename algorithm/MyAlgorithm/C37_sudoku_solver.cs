using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 37. 解数独
    /// https://leetcode-cn.com/problems/sudoku-solver
    /// 
    /// 递归 回溯 剪支  比较容易看懂
    /// </summary>
    public class C37_sudoku_solver
    {
        /// <summary>
        /// 入口
        /// </summary>
        /// <param name="board"></param>
        public void SolveSudoku2(char[][] board)
        {
            dfs(board, 0, 0);
        }

        private bool dfs(char[][] board, int row, int col)
        {
            for (int i = row; i < 9; i++, col = 0)
            { // note: must reset col here!
                for (int j = col; j < 9; j++)
                {
                    if (board[i][j] != '.') continue;
                    for (char num = '1'; num <= '9'; num++)
                    {
                        if (isValid(board, i, j, num))
                        {
                            board[i][j] = num;
                            if (dfs(board, i, j + 1))
                                return true;
                            board[i][j] = '.';
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        private bool isValid(char[][] board, int row, int col, char num)
        {
            int blkrow = (row / 3) * 3, blkcol = (col / 3) * 3; // Block no. is i/3, first element is i/3*3
            for (int i = 0; i < 9; i++)
                if (board[i][col] == num || board[row][i] == num || board[blkrow + i / 3][blkcol + i % 3] == num) return false;
            return true;
        }
    }

    /// <summary>
    /// 比较难理解
    /// </summary>
    public class C37_sudoku_solver2
    {
        public void SolveSudoku(char[][] board)
        {
            dfs(board, 0);
        }
        private bool dfs(char[][] board, int d)
        {
            if (d == 81) return true; //found solution
            int i = d / 9, j = d % 9;
            if (board[i][j] != '.') return dfs(board, d + 1);//prefill number skip

            bool[] flag = new bool[10];
            validate(board, i, j, flag);
            for (int k = 1; k <= 9; k++)
            {
                if (flag[k])
                {
                    board[i][j] = (char)('0' + k);
                    if (dfs(board, d + 1)) return true;
                }
            }
            board[i][j] = '.'; //if can not solve, in the wrong path, change back to '.' and out
            return false;
        }
        private void validate(char[][] board, int i, int j, bool[] flag)
        {
            Array.Fill(flag, true);
            for (int k = 0; k < 9; k++)
            {
                if (board[i][k] != '.') flag[board[i][k] - '0'] = false;
                if (board[k][j] != '.') flag[board[k][j] - '0'] = false;
                int r = i / 3 * 3 + k / 3;
                int c = j / 3 * 3 + k % 3;
                if (board[r][c] != '.') flag[board[r][c] - '0'] = false;
            }
        }
    }

}
