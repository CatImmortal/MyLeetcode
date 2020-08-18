using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/rotate-array/

    class _0189旋转数组
    {
        public void Rotate(int[] nums, int k)
        {
            k %= nums.Length;

            //整体翻转
            Reverse(nums, 0, nums.Length - 1);

            //翻转前k个
            Reverse(nums, 0, k - 1);

            //翻转后nums.length - k
            Reverse(nums, k, nums.Length - 1);
        }

        /// <summary>
        /// 翻转指定范围的数组
        /// </summary>
        private void Reverse(int[] nums,int start,int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        public void Rotate2(int[] nums, int k)
        {
            k %= nums.Length;

            int count = 0;  //交换位置的次数

            for (int start = 0; count < nums.Length; start++)
            {
                int cur = start;  //当前位置

                int prev = nums[start];

                do
                {
                    //目标位置
                    int next = (cur + k) % nums.Length;

                    int temp = nums[next]; //等待寻找新位置的元素
                    nums[next] = prev;
                    prev = temp; 
                    cur = next;
                    count++;

                } while (start != cur);
            }
        }
    }
}
