using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/count-complete-tree-nodes/

    class _0222完全二叉树的节点个数
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = GetLevel(root.left);
            int right = GetLevel(root.right);

            if (left == right)
            {
                //left == right。
                //说明此时虽然最后一层不满，但左子树一定是满二叉树，因为节点已经填充到右子树了，左子树必定已经填满了。
                //所以左子树的节点总数我们可以直接得到，是2 ^ left - 1，加上当前这个root节点，则正好是2 ^ left。再对右子树进行递归统计。
                return CountNodes(root.right) + (1 << left);
            }
            else
            {
                //left != right。
                //说明此时虽然最后一层不满，但右子树一定是满二叉树（右子树此时比左子树少一层），可以直接得到右子树的节点个数。
                //同理，右子树节点 + root节点，总数为2 ^ right。再对左子树进行递归查找。
                return CountNodes(root.left) + (1 << right);
            }

        }

        /// <summary>
        /// 获取完全二叉树的层数
        /// </summary>
        private int GetLevel(TreeNode root)
        {
            int level = 0;
            while (root != null)
            {
                level++;
                root = root.left;
            }
            return level;
        }
    }
}
