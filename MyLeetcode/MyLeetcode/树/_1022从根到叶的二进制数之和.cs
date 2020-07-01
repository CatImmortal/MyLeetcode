using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/sum-of-root-to-leaf-binary-numbers/

    class _1022从根到叶的二进制数之和
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }



        public int SumRootToLeaf(TreeNode root)
        {
            List<string> result = BinaryTreePaths(root);
            int sum = 0;
            for (int i = 0; i < result.Count; i++)
            {
                sum += BinaryStr2Int(result[i]);
            }
            return sum;
        }

        public List<string> BinaryTreePaths(TreeNode root)
        {
            List<string> result = new List<string>();
            Preorder(root, "", result);
            return result;
        }

        private void Preorder(TreeNode root, string str, List<string> result)
        {
            if (root == null)
            {
                return;
            }

            str += root.val;

            if (root.left == null && root.right == null)
            {
                result.Add(str);
                return;
            }


            Preorder(root.left, str, result);
            Preorder(root.right, str, result);

        }


        private int BinaryStr2Int(string str)
        {
            int sum = 0;
            int pow = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == '1')
                {
                    sum += (int)Math.Pow(2, pow);
                }

                pow++;
            }

            return sum;
        }

        int mod = (int)(Math.Pow(10, 9) + 7);

        public int SumRootToLeaf2(TreeNode root)
        {
            return SumRootToLeaf2Helper(root, 0);   
        }

        private int SumRootToLeaf2Helper(TreeNode root,int n)
        {
            if (root == null)
            {
                return 0;
            }

            n = n * 2 + root.val;

            if (root.left == null && root.right == null)
            {
                return n;
            }

            return (SumRootToLeaf2Helper(root.left, n) + SumRootToLeaf2Helper(root.right, n)) % mod;

        }
    }
}
