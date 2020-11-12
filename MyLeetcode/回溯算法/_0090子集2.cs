using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.回溯算法
{
    //https://leetcode-cn.com/problems/subsets-ii/

    class _0090子集2
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();

            if (nums.Length == 0)
            {
                return ans;
            }

            List<int> path = new List<int>();

            //标记当前深度搜索路径下 各个位置的数字是否已选择过
            bool[] used = new bool[nums.Length];

            Array.Sort(nums);

            Dfs(0, nums, ans, path,used);

            return ans;
        }

        private void Dfs(int cur, int[] nums, List<IList<int>> ans, List<int> path,bool[] used)
        {
            if (cur == nums.Length)
            {
                ans.Add(new List<int>(path));
                return;
            }


            if (cur > 0 && nums[cur] == nums[cur - 1] && !used[cur - 1])
            {
                //要剪枝的情况 上一个元素相同且没被选过 意味着是在树的同一层 会有重复
                Dfs(cur + 1, nums, ans, path, used);
                return;
            }
          

            //选择当前位置的数
            path.Add(nums[cur]);
            used[cur] = true;
            Dfs(cur + 1, nums, ans, path,used);
            path.RemoveAt(path.Count - 1);
            used[cur] = false;

            //不选择当前位置的数
            Dfs(cur + 1, nums, ans, path,used);
        }
    }
}
