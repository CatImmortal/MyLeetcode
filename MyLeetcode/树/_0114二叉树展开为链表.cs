using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/flatten-binary-tree-to-linked-list/

    class _0114二叉树展开为链表
    {
        private List<TreeNode> nodes = new List<TreeNode>();

        public void Flatten(TreeNode root)
        {
            //将前序遍历结果收集到nodes
            //同时断开节点间的连接
            PreOrder(root);

            //展开为单链表
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                nodes[i].right = nodes[i + 1];
            }
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            nodes.Add(root);

            PreOrder(root.left);
            PreOrder(root.right);

            root.left = null;
            root.right = null;
        }

        public void Flatten2(TreeNode root)
        {
            while (root != null)
            {
                //左子树为 null，直接考虑下一个节点
                if (root.left == null)
                {
                    root = root.right;
                }
                else
                {
                    // 找左子树最右边的节点
                    TreeNode pre = root.left;
                    while (pre.right != null)
                    {
                        pre = pre.right;
                    }

                    //将右子树插入到左子树最右节点
                    pre.right = root.right;

                    //将左子树移到右子树处
                    root.right = root.left;
                    root.left = null;

                    // 考虑下一个节点
                    root = root.right;
                }
            }
        }
    }
}
