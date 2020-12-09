using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.二分查找
{
    //https://leetcode-cn.com/problems/search-a-2d-matrix/

    class _0074搜索二维矩阵
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            //将二维数组扁平化为一维数组 然后进行二分查找

            //n = 每行元素个数
            //row = index / n
            //col = index % n

            int m = matrix.Length;
            if (m == 0)
            {
                return false;
            }

            int n = matrix[0].Length;

            int left = 0;
            int right = m * n - 1;

            while (left <= right)
            {
                int midIndex = left + ((right - left) >> 1);

                int item = matrix[midIndex / n][midIndex % n];

                if (item == target)
                {
                    return true;
                }
                else if (item < target)
                {
                    //收缩左边界
                    left = midIndex + 1;
                }
                else if (item > target)
                {
                    //收缩右边界
                    right = midIndex - 1;
                }
            }

            return false;
        }
    }
}
