using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-level-order-traversal-ii/

    class _0107二叉树的层次遍历2
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> result = LevelOrder(root);

            int left = 0;
            int right = result.Count - 1;
            while (left < right)
            {
                //把正常层序遍历结果翻转一下即可
                IList<int> temp = result[left];
                result[left] = result[right];
                result[right] = temp;

                left++;
                right--;
            }

            return result;
        }

        private IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<TreeNode> queue2 = new Queue<TreeNode>();

            queue1.Enqueue(root);

            while (queue1.Count > 0)
            {
                List<int> list = new List<int>();
                result.Add(list);

                //把queue1里的所有node都出队，并把它们的子节点都暂时放进queue2里
                while (queue1.Count > 0)
                {
                    TreeNode node = queue1.Dequeue();
                    list.Add(node.val);
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
                }
            }

            return result;

        }
    }
}
