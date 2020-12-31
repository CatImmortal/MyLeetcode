using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/spiral-matrix/

    class _0054螺旋矩阵
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            //按圈模拟

            List<int> list = new List<int>();

            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return list;    
            }

            int rowNum = matrix.Length;  //行数
            int colNum = matrix[0].Length;  //列数

            
            int left = 0;
            int right = colNum - 1;
            int top = 0;
            int bottom = rowNum - 1;

            while (left <= right && top <= bottom)
            {
                for (int col = left; col <= right; col++)
                {
                    //最上方一排
                    list.Add(matrix[top][col]);
                }

                for (int row = top + 1; row <= bottom; row++)
                {
                    //最右侧一排
                    list.Add(matrix[row][right]);
                }

                if (left < right && top < bottom)
                {
                    for (int col = right - 1; col > left; col--)
                    {
                        //最下方一排
                        list.Add(matrix[bottom][col]);
                    }

                    for (int row = bottom; row > top; row--)
                    {
                        //最左侧一排
                        list.Add(matrix[row][left]);
                    }
                }

                //缩圈
                left++;
                right--;
                top++;
                bottom--;
            }


            return list;    

        
        }
    }
}
