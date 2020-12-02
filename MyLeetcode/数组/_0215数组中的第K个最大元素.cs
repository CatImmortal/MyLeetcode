using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/kth-largest-element-in-an-array/

    class _0215数组中的第K个最大元素
    {
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            int index = nums.Length - k;
            return nums[index];
        }

        public int FindKthLargest2(int[] nums, int k)
        {
            //快排切分

            int left = 0;
            int right = nums.Length - 1;

            int target = nums.Length - k;

            while (true)
            {
                int index = Partition(nums, left, right);
                if (index == target)
                {
                    return nums[index];
                }
                else if (index < target)
                {
                    left = index + 1;
                }
                else
                {
                    right = index - 1;
                }
            }
        }

        private int Partition(int[] nums,int left,int right)
        {
            int pivot = nums[left];
            int j = left;

            for (int i = left + 1; i <= right; i++)
            {
                if (nums[i] < pivot)
                {
                    j++;

                    //i位置的数比pivot小 交换i j
                    //把小于pivot的数都放到前面去
                    int temp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = temp;

                    
                }
            }

            //最后把pivot和j上的数交换 以达到j之前的所有数 都比pivot小
            // 在之前遍历的过程中，满足 [left + 1, j] < pivot，并且 (j, i] >= pivot
            int temp2 = nums[left];
            nums[left] = nums[j];
            nums[j] = temp2;
            // 交换以后 [left, j - 1] < pivot, nums[j] = pivot, [j + 1, right] >= pivot
            return j;
        }
    }
}
