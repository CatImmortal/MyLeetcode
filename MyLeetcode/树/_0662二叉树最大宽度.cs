using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/maximum-width-of-binary-tree/

    class _0662二叉树最大宽度
    {
        public int WidthOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();

            //保存节点索引
            LinkedList<int> list = new LinkedList<int>();

            queue.Enqueue(root);
            list.AddFirst(1);

            int ans = 1;

            while (queue.Count > 0)
            {

                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    int curIndex = list.First.Value;
                    list.RemoveFirst();

                    //计算左右子节点索引
                    if (node.left != null )
                    {
                        queue.Enqueue(node.left);
                        list.AddLast(curIndex * 2);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                        list.AddLast(curIndex * 2 + 1);
                    }
                }

                //通过链表中第一个节点和最后一个节点的索引来计算该层宽度
                if (list.Count >= 2)
                {
                    ans = Math.Max(ans, list.Last.Value - list.First.Value + 1);
                }
            }

            return ans;
        }

    }
}
