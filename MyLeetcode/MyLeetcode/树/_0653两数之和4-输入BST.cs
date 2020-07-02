using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    class _0653两数之和4_输入BST
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public bool FindTarget(TreeNode root, int k)
        {
            List<int> result = new List<int>();
            InOrder(root, result);

            int i = 0;
            int j = result.Count - 1;

            while (i < j)
            {
                int sum = result[i] + result[j];

                if (sum == k)
                {
                    return true;
                }

                if (sum < k)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            return false;
        }

        private void InOrder(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left, result);

            result.Add(root.val);

            InOrder(root.right, result);
        }

        public bool FindTarget2(TreeNode root, int k)
        {
            return Find(root, k, new HashSet<int>());
        }

        private bool Find(TreeNode root,int k,HashSet<int> set)
        {
            if (root == null)
            {
                return false;
            }

            if (set.Contains(k - root.val))
            {
                //set里存在需要的另一个数
                return true;    
            }

            set.Add(root.val);
            return Find(root.left, k, set) || Find(root.right, k, set);
        }
    }
}
