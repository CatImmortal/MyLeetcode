using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/find-elements-in-a-contaminated-binary-tree/

    class _1261在受污染的二叉树中查找元素
    {
        public class FindElements
        {

            private TreeNode root;

            public FindElements(TreeNode root)
            {
                PreOrder(root, 0);

                this.root = root;
            }

            private void PreOrder(TreeNode root, int rootVal)
            {
                if (root == null)
                {
                    return;
                }

                root.val = rootVal;
                PreOrder(root.left, rootVal * 2 + 1);
                PreOrder(root.right, rootVal * 2 + 2);
            }

            public bool Find(int target)
            {
                return Find(root, target);
            }

            private bool Find(TreeNode root, int target)
            {
                if (root == null || root.val > target)
                {
                    return false;
                }

                if (root.val == target)
                {
                    return true;
                }

                return Find(root.left, target) || Find(root.right, target);
            }
        }
    }
}
