using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/merge-sorted-array/

    class _0088合并两个有序数组
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1.Length == 0 || nums2.Length == 0)
            {
                return;
            }

            //用来存放排序后元素的辅助数组
            int[] helper = new int[m + n];

            int i = 0;
            int j = 0;
            int index = 0;

            while (i < m || j < n)
            {
                //4种情况处理
                if (i == m && j < n)
                {
                    //i指针到头 j指针没到头
                    helper[index] = nums2[j];
                    j++;
                }
                else if (i < m && j == n)
                {
                    //j指针到头 i指针没到头
                    helper[index] = nums1[i];
                    i++;
                }
                else if (nums1[i] <= nums2[j])
                {
                    //两个指针都没到头 num1<=num2
                    helper[index] = nums1[i];
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    //两个指针都没到头 num1>num2
                    helper[index] = nums2[j];
                    j++;
                }

                index++;

            }

            //将辅助数组的元素全部复制到nums1中
            for (index = 0; index < helper.Length; index++)
            {
                nums1[index] = helper[index];
            }
        }

        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1;  //指向nums1最后一个有效元素

            int p2 = n - 1;  //指向nums2末尾

            int p3 = m + n - 1;  //指向nums1末尾

            while (p1 >= 0 && p2 >= 0)
            {
                //把较大的元素放到nums1数组末尾
                if (nums1[p1] > nums2[p2])
                {
                    nums1[p3] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[p3] = nums2[p2];
                    p2--;
                }

                p3--;
            }

            //如果还有数组有剩余
            //就表示该数组剩余的所有元素都比另一个数组的最小元素要小
            //直接安排到nums1头部

            //将nums2剩余元素复制到nums1头部
            //处理nums2还有剩余的情况
            Array.Copy(nums2, 0, nums1, 0, p2 + 1);

        }
    }
}
