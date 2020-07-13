using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/maximum-binary-tree/

    class _0654最大二叉树
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            TreeNode root = ConstructMaximumBinaryTree(nums, 0, nums.Length - 1);
            return root;
        }

        private TreeNode ConstructMaximumBinaryTree(int[] nums, int leftIndex, int rightIndex)
        {
            if (leftIndex < 0 || rightIndex >= nums.Length || leftIndex > rightIndex)
            {
                return null;
            }

            if (leftIndex == rightIndex)
            {
                return new TreeNode(nums[leftIndex]);
            }

            //给定范围内的数组最大值的索引
            int maxIndex = leftIndex;
            for (int i = leftIndex; i <= rightIndex; i++)
            {
                if (nums[i] > nums[maxIndex])
                {
                    maxIndex = i;
                }
            }

            TreeNode root = new TreeNode(nums[maxIndex]);
            root.left = ConstructMaximumBinaryTree(nums, leftIndex, maxIndex - 1);
            root.right = ConstructMaximumBinaryTree(nums, maxIndex + 1, rightIndex);
            return root;
        }
    }
}
