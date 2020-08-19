using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/rotate-image/

    class _0048旋转图像
    {
        public void Rotate(int[][] matrix)
        {
            int[][] clone = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                clone[i] = new int[matrix.Length];

                for (int j = 0; j < matrix.Length; j++)
                {
                    clone[i][j] = matrix[i][j];
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    //新的第i行第j列元素 取 clone的第length - 1 - j行第i列元素

                    matrix[i][j] = clone[clone.Length - 1 - j][i];
                }
            }
        }

        //----------------------------------------------------------

        public void Rotate2(int[][] matrix)
        {
            //先转置 然后翻转每一行

            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int tmp = matrix[j][i];
                    matrix[j][i] = matrix[i][j];
                    matrix[i][j] = tmp;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int tmp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = tmp;
                }
            }

          

           
        }
    }
}
