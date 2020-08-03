using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/smallest-subtree-with-all-the-deepest-nodes/

    class _0865具有所有最深结点的最小子树
    {
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            List<TreeNode> result = LevelOrder(root);

            TreeNode node1 = result[0];

            for (int i = 1; i < result.Count; i++)
            {
                TreeNode node2 = result[i];

                //不断调用这个方法 获取node1 和 node2 的最近公共祖先
                node1 = LowestCommonAncestor(root, node1, node2);
            }

            return node1;
        }

        /// <summary>
        /// 层序遍历获取最底下一层的节点
        /// </summary>
        private List<TreeNode> LevelOrder(TreeNode root)
        {
            List<TreeNode> result = new List<TreeNode>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<TreeNode> queue2 = new Queue<TreeNode>();

            queue1.Enqueue(root);

            while (queue1.Count > 0)
            {

                //把queue1里的所有node都出队，并把它们的子节点都暂时放进queue2里
                while (queue1.Count > 0)
                {
                    TreeNode node = queue1.Dequeue();

                    result.Add(node);

                    if (node.left != null)
                    {
                        queue2.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue2.Enqueue(node.right);
                    }
                }


                //把queue2里的所有node都放进queue1中
                while (queue2.Count > 0)
                {
                    queue1.Enqueue(queue2.Dequeue());
                    result.Clear();
                }
            }

            return result;

        }

        /// <summary>
        /// 获取p和q在root下的最近公共祖先
        /// </summary>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            // LowestCommonAncestor的返回值如果不为null（p和q都不存在root下）
            //那么返回值是p和q其中至少一个的公共祖先（或者是其本身）

            TreeNode leftNode = LowestCommonAncestor(root.left, p, q);
            TreeNode rightNode = LowestCommonAncestor(root.right, p, q);

            if (leftNode != null && rightNode != null)
            {
                //p和q分别在左子树和右子树中 root是它俩的公共祖先
                return root;
            }

            if (leftNode != null)
            {
                //p和q都在左子树 leftNode是它俩的公共祖先
                return leftNode;
            }

            if (rightNode != null)
            {
                //p和q都在右子树 rightNode是它俩的公共祖先
                return rightNode;
            }

            return null;
        }


        public TreeNode SubtreeWithAllDeepest2(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            int leftDepth = GetDepth(root.left);
            int rightDepth = GetDepth(root.right);

            //左右子树高度相等 返回root
            if (leftDepth == rightDepth)
            {
                return root;
            }

            //否则递归到深度更大的那边找
            if (leftDepth > rightDepth)
            {
                return SubtreeWithAllDeepest2(root.left);
            }
            else
            {
                return SubtreeWithAllDeepest2(root.right);
            }
        }

        private int GetDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Math.Max(GetDepth(root.left), GetDepth(root.right));
        }
    }
}
