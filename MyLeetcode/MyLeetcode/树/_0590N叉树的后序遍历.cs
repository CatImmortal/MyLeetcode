using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/n-ary-tree-postorder-traversal/

    class _0590N叉树的后序遍历
    {

        public IList<int> Postorder(Node root)
        {
            List<int> result = new List<int>();
            Stack<Node> stack = new Stack<Node>();

            if (root != null)
            {
                stack.Push(root);
            }

            //前一次遍历到的节点
            Node prev = null;

            while (stack.Count > 0)
            {
                Node node = stack.Peek();

                if (
                    (node.children == null || node.children.Count == 0)
                    || (prev != null && (prev == node.children[node.children.Count - 1]))
                    )
                {
                    //当前节点没有子节点
                    //或者 当前节点的最后一个子节点被遍历过了
                    //就遍历当前节点
                    stack.Pop();
                    result.Add(node.val);
                    prev = node;
                }
                else
                {
                    //否则将当前节点的所有子节点倒着入栈
                    for (int i = node.children.Count - 1; i >= 0; i--)
                    {
                        stack.Push(node.children[i]);
                    }
                }
            }

            return result;

            //总结 非递归前序遍历的变形
            //在遍历当前节点前加个判断 不能直接遍历 要等子节点都被遍历后才可以
        }
    }
}
