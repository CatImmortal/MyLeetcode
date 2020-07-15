using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/deepest-leaves-sum/

    class _1302层数最深叶子节点的和
    {

        public int DeepestLeavesSum(TreeNode root)
        {
            List<List<int>> result = LevelOrder(root);

            //层序遍历结果的最后一层节点
            List<int> list = result[result.Count - 1];

            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        public List<List<int>> LevelOrder(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
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
