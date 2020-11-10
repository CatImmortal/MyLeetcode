using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.回溯算法
{
    //https://leetcode-cn.com/problems/permutations-ii/

    class _0047全排列2
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();

            if (nums.Length == 0)
            {
                return ans;
            }

            //排序是剪枝的前提
            Array.Sort(nums);

            //标记各个位置的数字是否已选择
            bool[] used = new bool[nums.Length];

            List<int> path = new List<int>();

            Dfs(nums, 0, path, used, ans);

            return ans;
        }

        private void Dfs(int[] nums, int depth, List<int> path, bool[] used, List<IList<int>> ans)
        {
            if (depth == nums.Length)
            {
                //递归到头 叶子节点 将路径列表复制后放入解答
                ans.Add(new List<int>(path));
                return;
            }

            //在非叶子结点处，产生不同的分支
            //这一操作的语义是：在还未选择的数中依次选择一个元素作为下一个位置的元素
            //这显然得通过一个循环实现。
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }

                //搜索起点相同 nums[i] == nums[i - 1] 就有可能重复路径
                //!used[i - 1]表示当前数字和前面重复的在同一层上，继续下去路径会重复
                //否则当前数字在前面重复的下一层，继续下去路径不会重复
                //总结，搜索起点相同并且在同一层上 路径就会重复 应该进行剪枝
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                {
                    continue;
                }

                path.Add(nums[i]);  //未选择过 放入路径列表
                used[i] = true;

                Dfs(nums, depth + 1, path, used, ans);

                //回溯 恢复现场
                used[i] = false;
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
