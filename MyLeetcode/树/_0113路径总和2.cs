using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/path-sum-ii/

    class _0113路径总和2
    {
        private IList<IList<int>> ans = new List<IList<int>>();

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            PreOrder(root, new List<int>(), sum);
            return ans;
        }

        private void PreOrder(TreeNode root,List<int> list,int sum)
        {
            if (root == null)
            {
                return;
            }

            list.Add(root.val);

            //处理叶子节点的情况
            if (root.left == null && root.right == null && root.val == sum)
            {

                //加入解答集合

                List<int> ansList = new List<int>(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    ansList.Add(list[i]);
                }

                ans.Add(ansList);
            }

            PreOrder(root.left, list,sum - root.val);
            PreOrder(root.right, list,sum - root.val);

            //退出前把自身移除掉
            list.RemoveAt(list.Count - 1);
        }
    }
}
