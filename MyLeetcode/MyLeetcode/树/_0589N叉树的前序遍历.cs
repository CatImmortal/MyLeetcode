using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/n-ary-tree-preorder-traversal/

    class _0589N叉树的前序遍历
    {
        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public IList<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            Stack<Node> stack = new Stack<Node>();

            if (root != null)
            {
                stack.Push(root);
            }


            while (stack.Count != 0)
            {
                Node node = stack.Pop();
                result.Add(node.val);

                //出栈根节点后将所有子节点依次倒着入栈
                if (node.children != null)
                {
                    for (int i = node.children.Count - 1; i >= 0; i--)
                    {
                        stack.Push(node.children[i]);
                    }
                }
            }

            return result;


        }
    }
}
