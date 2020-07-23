using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/sum-root-to-leaf-numbers/

    class _0129求根到叶子节点数字之和
    {

        private int ans = 0;

        public int SumNumbers(TreeNode root)
        {
            PreOrder(root, new List<int>());
            return ans;
        }

        private void PreOrder(TreeNode root, List<int> list)
        {
            if (root == null)
            {
                return;
            }

            list.Add(root.val);

            //叶子节点
            if (root.left == null && root.right == null)
            {
                ans += List2Int(list);
            }

            PreOrder(root.left, list);
            PreOrder(root.right, list);

            //返回前要把自己加上去的值移除掉
            list.RemoveAt(list.Count - 1);
        }

        private int List2Int(List<int> list)
        {
            int num = 0;
            int pow = 1;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                num += list[i] * pow;
                pow *= 10;
            }
            return num;
        }


        public int SumNumbers2(TreeNode root)
        {
            return PreOrder2(root, 0);
        }

        private int PreOrder2(TreeNode root,int i)
        {
            if (root == null)
            {
                return 0;
            }

            int num = i * 10 + root.val;
            if (root.left == null && root.right == null)
            {
                return num;
            }
            return PreOrder2(root.left, num) + PreOrder2(root.right, num);
        }
    }
}
