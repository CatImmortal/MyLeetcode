using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/complete-binary-tree-inserter/

    class _0919完全二叉树插入器
    {
        public class CBTInserter
        {

            private List<TreeNode> nodes = new List<TreeNode>();

            public CBTInserter(TreeNode root)
            {
                nodes.Add(new TreeNode(-1));

                //按层序遍历将整棵树收集到nodes里
                LevelOrder(root);
            }

            private void LevelOrder(TreeNode root)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    TreeNode node = queue.Dequeue();

                    nodes.Add(node);

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }

            public int Insert(int v)
            {
                TreeNode node = new TreeNode(v);
                nodes.Add(node);

                int parentPos = (nodes.Count - 1) / 2;
                TreeNode parent = nodes[parentPos];


                if ((nodes.Count - 1) % 2 == 0)
                {
                    parent.left = node;
                }
                else
                {
                    parent.right = node;
                }

                return parent.val;
            }

            public TreeNode Get_root()
            {
                return nodes[1];
            }
        }
    }
}
