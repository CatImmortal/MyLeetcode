using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    //https://leetcode-cn.com/problems/3sum/

    class _0015三数之和
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();
            Array.Sort(nums);

            int length = nums.Length;

            for (int i = 0; i < length; i++)
            {
                if (nums[i] > 0)
                {
                    //当前数大于0 说明后面的数也大于0 直接返回
                    return ans;
                }

                if (i > 0 && nums[i] == nums[i - 1])
                {
                    //跳过重复元素
                    continue;
                }

                //开始双指针搜索剩余两个数
                int cur = nums[i];
                int left = i + 1;
                int right = length - 1;

                while (left < right)
                {
                    int sum = cur + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        List<int> list = new List<int>()
                        {
                            cur,nums[left],nums[right]
                        };

                        ans.Add(list);

                        //跳过重复解
                        while (left < right && nums[left + 1] == nums[left])
                        {
                            left++;
                        }
                        while (left < right && nums[right - 1] == nums[right])
                        {
                            right--;
                        }

                        //移动双指针 寻找当前数的下一组解
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        //总和太小 移动左指针
                        left++;
                    }
                    else
                    {
                        //总和太大 移动右指针
                        right--;
                    }
                }
            }

            return ans;
        }
    }
}
