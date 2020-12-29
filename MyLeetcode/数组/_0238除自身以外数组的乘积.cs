using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    class _0238除自身以外数组的乘积
    {
        //https://leetcode-cn.com/problems/product-of-array-except-self/

        public int[] ProductExceptSelf(int[] nums)
        {
            // left 和 right 分别表示左右两侧的乘积列表
            int[] left = new int[nums.Length]; //left[i]表示nums[i]左侧所有数乘积
            int[] right = new int[nums.Length];//right[i]表示nums[i]右侧所有数乘积

            int[] answer = new int[nums.Length];

            left[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                //left[i]处的数就是nums[i-1]的左侧所有数的乘积再乘上nums[i-1]
                left[i] = left[i - 1] * nums[i - 1];
            }

            right[nums.Length - 1] = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                //right[i]处的数就是nums[i+1]的右侧所有数的乘积再乘上nums[i+1]
                right[i] = right[i + 1] * nums[i + 1];
            }

            //将i的左右乘积相乘
            for (int i = 0; i < nums.Length; i++)
            {
                answer[i] = left[i] * right[i];
            }

            return answer;
        }

        public int[] ProductExceptSelf2(int[] nums)
        {
            int[] answer = new int[nums.Length];

            //先计算左侧乘积
            answer[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            //算上右侧乘积
            int right = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                answer[i] = answer[i] * right;
                right *= nums[i];  //// right 需要包含右边所有的乘积，所以计算下一个结果时需要将当前值乘到 right 上
            }

            return answer;
        }
    }
}
