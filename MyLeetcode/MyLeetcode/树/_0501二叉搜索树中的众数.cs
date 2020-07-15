using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/find-mode-in-binary-search-tree/

    class _0501二叉搜索树中的众数
    {

        private List<int> values = new List<int>();  //存放众数的列表
        int curVal = 0;  //当前需要统计出现次数的数字
        int max = 0;  //当前众数的出现次数
        int count = 0;  //当前数字的出现次数



        public int[] FindMode(TreeNode root)
        {
            if (root == null)
            {
                return new int[0];
            }

            InOrder(root);

            return values.ToArray();


        }

        private void InOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left);

            if (curVal == root.val)
            {
                count++;
            }
            else
            {
                count = 1;
                curVal = root.val;
            }

            if (count == max)
            {
                //和已有众数次数一样
                values.Add(curVal);
            }
            else if (count > max)
            {
                //比已有众数次数多
                max = count;
                values.Clear();
                values.Add(curVal);
            }

            InOrder(root.right);
        }
    }
}
