using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/maximum-binary-tree-ii/

    class _0998最大二叉树2
    {
        public TreeNode InsertIntoMaxTree(TreeNode root, int val)
        {
            List<int> list = new List<int>();
            InOrder(root, list);

            //附加新值 然后重新构建最大二叉树
            list.Add(val);

            TreeNode newRoot = ConstructMaximumBinaryTree(list, 0, list.Count - 1);

            return newRoot;
        }

        private void InOrder(TreeNode root,List<int> list)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left, list);

            list.Add(root.val);

            InOrder(root.right, list);
        }

        private TreeNode ConstructMaximumBinaryTree(List<int> nums, int leftIndex, int rightIndex)
        {
            if (leftIndex < 0 || rightIndex >= nums.Count || leftIndex > rightIndex)
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
