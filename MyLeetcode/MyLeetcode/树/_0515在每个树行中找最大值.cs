using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/find-largest-value-in-each-tree-row/

    class _0515在每个树行中找最大值
    {
        public IList<int> LargestValues(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<TreeNode> queue2 = new Queue<TreeNode>();

            queue1.Enqueue(root);

            while (queue1.Count > 0)
            {
                //记录当前层最大值
                int max = int.MinValue;

                //把queue1里的所有node都出队，并把它们的子节点都暂时放进queue2里
                while (queue1.Count > 0)
                {
                    TreeNode node = queue1.Dequeue();

                    if (node.val > max)
                    {
                        max = node.val;
                    }

                    if (node.left != null)
                    {
                        queue2.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue2.Enqueue(node.right);
                    }
                }

                result.Add(max);


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
