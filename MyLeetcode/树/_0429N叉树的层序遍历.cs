using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/n-ary-tree-level-order-traversal/

    class _0429N叉树的层序遍历
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<Node> queue1 = new Queue<Node>();
            Queue<Node> queue2 = new Queue<Node>();

            queue1.Enqueue(root);

            while (queue1.Count > 0)
            {
                List<int> list = new List<int>();
                result.Add(list);

                //把queue1里的所有node都出队，并把它们的子节点都暂时放进queue2里
                while (queue1.Count > 0)
                {
                    Node node = queue1.Dequeue();
                    list.Add(node.val);

                    foreach (Node child in node.children)
                    {
                        queue2.Enqueue(child);
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
