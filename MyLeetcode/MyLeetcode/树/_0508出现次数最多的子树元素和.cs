using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/most-frequent-subtree-sum/

    class _0508出现次数最多的子树元素和
    {
        //key-子树元素和 value-出现次数
        private Dictionary<int, int> dict = new Dictionary<int, int>();

        public int[] FindFrequentTreeSum(TreeNode root)
        {
            PostOrder(root);

            List<int> list = new List<int>();

            //当前出现最多次数的子树元素和的出现次数
            int maxCount = 0;

            foreach (KeyValuePair<int, int> item in dict)
            {
                if (item.Value == maxCount)
                {
                    list.Add(item.Key);
                }
                else if (item.Value > maxCount)
                {
                    maxCount = item.Value;
                    list.Clear();
                    list.Add(item.Key);
                }
            }

            return list.ToArray();
        }

        private int PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = PostOrder(root.left);
            int right = PostOrder(root.right);
            root.val += left + right;

            if (!dict.ContainsKey(root.val))
            {
                dict.Add(root.val, 1);
            }
            else
            {
                dict[root.val] += 1;
            }

            return root.val;
        }
    }
}
