using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/find-bottom-left-tree-value/

    class _0513找树左下角的值
    {
        public int FindBottomLeftValue(TreeNode root)
        {
            return LevelOrder(root);
        }

        public int LevelOrder(TreeNode root)
        {
            int ans = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                TreeNode node = queue.Dequeue();
                ans = node.val;

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
            }

            return ans;
        }
    }
}
