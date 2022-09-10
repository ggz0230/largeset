using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlgorithm
{
    /// <summary>
    /// 36. 有效的数独
    /// https://leetcode-cn.com/problems/valid-sudoku
    /// </summary>
    public class B36_valid_sudoku
    {
        /// <summary>
        /// 最简洁 目前最优方案 国际版光头强的
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku2(char[][] board)
        {
            HashSet<string> set = new HashSet<string>();//不会重复的
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    char number = board[i][j];
                    if (number != '.')
                        if (!set.Add(number + " in row " + i) ||
                            !set.Add(number + " in column " + j) ||
                            !set.Add(number + " in block " + i / 3 + "-" + j / 3))
                            return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 就按照从左往右、从上往下的顺序遍历一次board，完成3个条件的检验
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[][] board)
        {
            int[,] row = new int[9, 10];// 哈希表存储每一行的每个数是否出现过，默认初始情况下，每一行每一个数都没有出现过
                                        // 整个board有9行，第二维的维数10是为了让下标有9，和数独中的数字9对应。
            int[,] col = new int[9, 10];// 存储每一列的每个数是否出现过，默认初始情况下，每一列的每一个数都没有出现过
            int[,] box = new int[9, 10];// 存储每一个box的每个数是否出现过，默认初始情况下，在每个box中，每个数都没有出现过。整个board有9个box
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // 遍历到第i行第j列的那个数,我们要判断这个数在其所在的行有没有出现过，
                    // 同时判断这个数在其所在的列有没有出现过
                    // 同时判断这个数在其所在的box中有没有出现过
                    if (board[i][j] == '.')
                    {
                        continue;
                    }
                    int curNum = board[i][j] - '0';
                    if (row[i, curNum] == 1)
                    {
                        return false;
                    }
                    if (col[j, curNum] == 1)
                    {
                        return false;
                    }
                    if (box[j / 3 + (i / 3) * 3, curNum] == 1)
                    {
                        return false;
                    }
                    // 之前都没出现过，现在出现了，就给它置为1，下次再遇见就能够直接返回false了
                    row[i, curNum] = 1;
                    col[j, curNum] = 1;
                    box[j / 3 + (i / 3) * 3, curNum] = 1;
                }
            }
            return true;
        }

        public static void Show()
        {
            string str = "[['5','3','.','.','7','.','.','.','.'],['6','.','.','1','9','5','.','.','.'],['.','9','8','.','.','.','.','6','.'],['8','.','.','.','6','.','.','.','3'],['4','.','.','8','.','3','.','.','1'],['7','.','.','.','2','.','.','.','6'],['.','6','.','.','.','.','2','8','.'],['.','.','.','4','1','9','.','.','5'],['.','.','.','.','8','.','.','7','9']]";
            char[][] M = JsonConvert.DeserializeObject<char[][]>(str);
            new B36_valid_sudoku().IsValidSudoku2(M);
        }

    }
}
