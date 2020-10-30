using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/two-sum-ii-input-array-is-sorted/

    class _0167两数之和2_输入有序数组
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int i = 0;
            int j = numbers.Length - 1;
            int[] result = new int[2];
            while (i < j)
            {
                int sum = numbers[i] + numbers[j];

                if (sum == target)
                {
                    result[0] = i + 1;
                    result[1] = j + 1;
                    break;
                }

                //根据大小关系移动双指针
                if (sum < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            return result;
        }
    }
}
