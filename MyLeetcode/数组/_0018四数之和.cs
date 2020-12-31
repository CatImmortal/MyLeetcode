using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.数组
{
    class _0018四数之和
    {
        //https://leetcode-cn.com/problems/4sum/

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> ans = new List<IList<int>>();

            if (nums == null || nums.Length < 4)
            {
                return ans;
            }

            Array.Sort(nums);

            int length = nums.Length;

            for (int i = 0; i < length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    //跳过重复解
                    continue;
                }

                if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target)
                {
                    //后续都会比target大 结束循环
                    break;
                }

                if (nums[i] + nums[length - 3] + nums[length - 2] + nums[length - 1] < target)
                {
                    //后续最大都会比target小 结束循环
                    continue;
                }

                for (int j = i + 1; j < length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                    {
                        //跳过重复解
                        continue;
                    }
                    if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target)
                    {
                        //后续都会比target大 结束循环
                        break;
                    }
                    if (nums[i] + nums[j] + nums[length - 2] + nums[length - 1] < target)
                    {
                        // //后续最大会比target小 跳过循环
                        continue;
                    }

                    //双指针
                    int left = j + 1;
                    int right = length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum == target)
                        {
                            //加入解答
                            ans.Add(new List<int>() { nums[i], nums[j], nums[left], nums[right] });

                            //跳过重复解
                            while (left < right && nums[left] == nums[left + 1])
                            {
                                left++;
                            }

                            while (left < right && nums[right] == nums[right - 1])
                            {
                                right--;
                            }

                            left++;
                            right--;

                        }
                        else if (sum < target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }

                 
                }
            }

            return ans;
        }
    }
}
