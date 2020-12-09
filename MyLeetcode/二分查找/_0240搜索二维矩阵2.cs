using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.二分查找
{
    //https://leetcode-cn.com/problems/search-a-2d-matrix-ii/

    class _0240搜索二维矩阵2
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {

            //对每一行进行二分搜索

            int row = matrix.Length;
            if (row == 0)
            {
                return false;
            }

            int col = matrix[0].Length;

            for (int i = 0; i < row; i++)
            {
                if (matrix[i][0] > target)
                {
                    //这一行以及后面的元素都比target大 不用继续了
                    break;
                }

                if (matrix[i][col - 1] < target)
                {
                    //这一行的元素都比target小 跳过
                    continue;
                }

                //对这一行进行二分查找
                if (BinarySearch(matrix[i],target))
                {
                    return true;
                }
            }

            return false;

        }

        private bool BinarySearch(int[] nums,int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);

                if (nums[mid] == target)
                {
                    return true;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
            }

            return false;
        }

        public bool SearchMatrix2(int[][] matrix, int target)
        {
          
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return false;
            }

            //对于右上角的数字 左边的都小于它 下边的都大于它
            //所以从右上角开始 进行一种类似二分搜索树的查找

            int row = 0;
            int col = matrix[0].Length - 1;

            while (row < matrix.Length && col >= 0)
            {
                int num = matrix[row][col];

                if (num == target)
                {
                    return true;
                }
                else if (num < target)
                {
                    row++;
                }
                else if (num > target)
                {
                    col--;
                }
            }

            return false;
        }
    }
}
