using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/move-zeroes/

    class _0283移动零
    {
        public void MoveZeroes(int[] nums)
        {
            //此指针之前的所有元素都是非零的
            int lastNonZero = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    //将非零元素交换
                    int temp = nums[lastNonZero];
                    nums[lastNonZero] = nums[i];
                    nums[i] = temp;

                    lastNonZero++;
                }
            }

            
        }

      


    }
}
