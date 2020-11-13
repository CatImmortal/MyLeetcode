using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.排序
{
    //https://leetcode-cn.com/problems/sort-colors/

    class _0075颜色分类
    {
        public void SortColors(int[] nums)
        {
            int p0 = 0;

            int p2 = nums.Length - 1;

            for (int i = 0; i <= p2; i++)
            {
                //把2放到末尾 
                while (i <= p2 && nums[i] == 2)
                {
                    //防止交换后的还是2 所以循环处理
                    int temp = nums[i];
                    nums[i] = nums[p2];
                    nums[p2] = temp;
                    --p2;
                }

                //0放到前头
                if (nums[i] == 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[p0];
                    nums[p0] = temp;
                    ++p0;
                }
            }
        }
    }
}
