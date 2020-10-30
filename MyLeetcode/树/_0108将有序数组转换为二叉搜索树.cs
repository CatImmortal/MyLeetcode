using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/convert-sorted-array-to-binary-search-tree/

    class _0108将有序数组转换为二叉搜索树
    {


        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return null;
            }

            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBST(int[] nums, int left, int right)
        {
            if (left > right || left > nums.Length - 1 || right < 0)
            {
                return null;
            }

            if (left == right)
            {
                return new TreeNode(nums[left]);
            }


            
            int mid = (int)Math.Ceiling((left + right) / 2.0f);

            TreeNode root = new TreeNode(nums[mid]);
            root.left = SortedArrayToBST(nums, left, mid - 1);
            root.right = SortedArrayToBST(nums, mid + 1, right);

            return root;

        }
    }
}
