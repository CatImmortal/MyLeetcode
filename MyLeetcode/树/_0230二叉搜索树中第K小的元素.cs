using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/kth-smallest-element-in-a-bst/

    class _0230二叉搜索树中第K小的元素
    {

        public int KthSmallest(TreeNode root, int k)
        {
            int index = InOrder(root, k);
            return index;
        }

        private int InOrder(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            //表示当前中序遍历的是第几个元素
            int index = 0;

            TreeNode node = root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    //不断push left进去 一直push到头
                    stack.Push(node);
                    node = node.left;
                }

                if (stack.Count > 0)
                {
                    //push到头了 取一个出来操作 然后push一个right进去
                    node = stack.Pop();

                    index++;
                    if (index == k)
                    {
                        return node.val;
                    }

                    node = node.right;
                }
            }

            return 0;
        }
    }
}
