using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    class _0073矩阵置零
    {
        public void SetZeroes(int[][] matrix)
        {
            //记录出现过0元素的行列号
            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();

            int rowNum = matrix.Length;
            int colNum = matrix[0].Length;

            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    if (matrix[i][j]==0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    if (rows.Contains(i) || cols.Contains(j))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }


        //-------------------------------------------------
        public void SetZeroes2(int[][] matrix)
        {
            int rowNum = matrix.Length;
            int colNum = matrix[0].Length;

            bool row0Flag = false;  //第一行是否有0的标记
            bool col0Flag = false;  //第一列是否有0的标记

            //检查第一行是否有0
            for (int j = 0; j < colNum; j++)
            {
                if (matrix[0][j] == 0)
                {
                    row0Flag = true;
                    break;
                }
            }

            //检查第一列是否有0
            for (int i = 0; i < rowNum; i++)
            {
                if (matrix[i][0] == 0)
                {
                    col0Flag = true;
                    break;
                }
            }

            //出现0的地方 要把对于的第一行 第一列 分别设为0
            for (int i = 1; i < rowNum; i++)
            {
                for (int j = 1; j < colNum; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            //置0
            for (int i = 1; i < rowNum; i++)
            {
                for (int j = 1; j < colNum; j++)
                {
                    if (matrix[i][0]==0||matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            //特殊处理第一行第一列
            if (row0Flag)
            {
                for (int j = 0; j < colNum; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            if (col0Flag)
            {
                for (int i = 0; i < rowNum; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }
    }
}
