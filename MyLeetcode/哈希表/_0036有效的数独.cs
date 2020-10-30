using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数独
{
    //https://leetcode-cn.com/problems/valid-sudoku/

    class _0036有效的数独
    {
        public bool IsValidSudoku(char[][] board)
        {
            //行 列 九宫格的字典数组
            Dictionary<int, int>[] rows = new Dictionary<int, int>[9];
            Dictionary<int, int>[] cols = new Dictionary<int, int>[9];
            Dictionary<int, int>[] boxes = new Dictionary<int, int>[9];

            for (int i = 0; i < 9; i++)
            {
                rows[i] = new Dictionary<int, int>();
                cols[i] = new Dictionary<int, int>();
                boxes[i] = new Dictionary<int, int>();
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char num = board[i][j];

                    if (num == '.')
                    {
                        continue;
                    }

                    int n = num;

                    //计算九宫格下标
                    int box_index = (i / 3) * 3 + j / 3;

                    if (rows[i].ContainsKey(n))
                    {
                        rows[i][n] += 1;
                    }
                    else
                    {
                        rows[i][n] = 1;
                    }

                    if (cols[j].ContainsKey(n))
                    {
                        cols[j][n] += 1;
                    }
                    else
                    {
                        cols[j][n] = 1;
                    }

                    if (boxes[box_index].ContainsKey(n))
                    {
                        boxes[box_index][n] += 1;
                    }
                    else
                    {
                        boxes[box_index][n] = 1;
                    }

                    if (rows[i][n] > 1 || cols[j][n] > 1|| boxes[box_index][n] > 1)
                    {
                        //有重复元素
                        return false;
                    }



                }
            }

            return true;
        }
    }
}
