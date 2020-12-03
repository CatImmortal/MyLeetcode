using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.二分查找
{
    //https://leetcode-cn.com/problems/peak-index-in-a-mountain-array/

    class _0852山脉数组的峰顶索引
    {
        public int PeakIndexInMountainArray(int[] arr)
        {
            //暴力搜索

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return i;
                }
            }

            return 0;
        }

        public int PeakIndexInMountainArray2(int[] arr)
        {
            //二分查找


            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);

                if (mid == 0)
                {
                    mid++;
                }
                else if (mid == arr.Length - 1)
                {
                    mid--;
                }

                //通过对比mid和它旁边数的大小关系判断

                int leftNum = arr[mid - 1];
                int midNum = arr[mid];
                int rightNum = arr[mid + 1];

                if (leftNum < midNum && midNum > rightNum)
                {
                    //找到峰顶了
                    return mid;
                }
                else if (leftNum < midNum && midNum < rightNum )
                {
                    //在峰顶左侧 收缩左边界
                    left = mid + 1;
                }
                else if (leftNum > midNum && midNum > rightNum)
                {
                    //在峰顶右侧 收缩右边界
                    right = mid - 1;
                }

                
            }

            return -1;
        }

        public int PeakIndexInMountainArray3(int[] arr)
        {

            //二分查找
            //在山脉数组上使用二分查找，找出满足 arr[i] < arr[i+1] 的最大 i
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                int mid = left + ((right - left) >> 1);

                if (arr[mid] < arr[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
    }
}
