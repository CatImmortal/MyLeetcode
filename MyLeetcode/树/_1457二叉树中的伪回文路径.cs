using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/pseudo-palindromic-paths-in-a-binary-tree/

    class _1457二叉树中的伪回文路径
    {
        private int ans = 0;

        private Dictionary<int, int> dict = new Dictionary<int, int>();

        public int PseudoPalindromicPaths(TreeNode root)
        {
            PreOrder(root, new List<int>());
            return ans;
        }

        private void PreOrder(TreeNode root,List<int> list)
        {
            if (root == null)
            {
                return;
            }

            list.Add(root.val);

            if (root.left == null && root.right == null && Check(list))
            {
                ans++;
            }

            PreOrder(root.left, list);
            PreOrder(root.right, list);

            //返回前删除掉自己
            list.RemoveAt(list.Count - 1);
        }


        private bool Check(List<int> list)
        {
            dict.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                if (!dict.ContainsKey(list[i]))
                {
                    dict.Add(list[i], 1);
                }
                else
                {
                    dict[list[i]] += 1;
                }
            }

            //统计出现次数奇数的数字的个数
            int count = 0;
            foreach (KeyValuePair<int, int> item in dict)
            {
                if (item.Value %2 == 1)
                {
                    count++;
                }
            }

            return count <= 1;
        }

        public int PseudoPalindromicPaths2(TreeNode root)
        {
            PreOrder2(root, 0);
            return ans;
        }

        private void PreOrder2(TreeNode node,int temp)
        {
            if (node == null)
            {
                return;
            }

            //用一个二进制数来表示路径上各节点值的出现次数
            //node节点的val为几就左移几位
            temp ^= (1 << node.val);

            if (node.left == null && node.right == null)
            {
                //叶子节点 判断是否为伪回文
                //temp为0 说明路径上各节点值出现次数均为偶数次
                //(temp & temp-1) == 0 说明在temp的二进制表示中 最多只出现一个1 即最多只有一个节点出现了奇数次

                if (temp == 0 || (temp & temp-1) == 0)
                {
                    ans++;
                }
            }

            PreOrder2(node.left, temp);
            PreOrder2(node.right, temp);
        }
    }
}
