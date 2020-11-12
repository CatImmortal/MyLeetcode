using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.回溯算法
{
    //https://leetcode-cn.com/problems/subsets/

    class _0078子集
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            //迭代枚举
            List<IList<int>> ans = new List<IList<int>>();

            if (nums.Length == 0)
            {
                return ans;
            }

            List<int> path = new List<int>();

            //如果nums长度为3 那么mask就是从0到7
            for (int mask = 0; mask < (1 << nums.Length); mask++)
            {
                path.Clear();
                for (int i = 0; i < nums.Length; i++)
                {
                    //把在数组里所在位置 和mask二进制表示的1的位置 对应的数 加入到path中
                    //假设nums长度为3 mask的二进制为011 对应数组里的就是nums[1]和nums[2]处的数字 
                    if ((mask & (1 << i)) != 0)
                    {
                        path.Add(nums[i]);
                    }
                }
                ans.Add(new List<int>(path));
            }

            return ans;
        }

        public IList<IList<int>> Subsets2(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();

            if (nums.Length == 0)
            {
                return ans;
            }

            List<int> path = new List<int>();

            Dfs(0, nums, ans, path);

            return ans;
        }

        private void Dfs(int cur, int[] nums, List<IList<int>> ans, List<int> path)
        {
            if (cur == nums.Length)
            {
                ans.Add(new List<int>(path));
                return;
            }

            //选择当前位置的数
            path.Add(nums[cur]);
            Dfs(cur + 1, nums, ans, path);
            path.RemoveAt(path.Count - 1);  //撤回

            //不选择当前位置的数
            Dfs(cur + 1, nums, ans, path);

        }
    }
}
