using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/maximum-depth-of-n-ary-tree/

    class _0559N叉树的最大深度
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

        private int ans = 0;

        public int MaxDepth(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            MaxDepth(root, 1);
            return ans;
        }
        public void MaxDepth(Node root, int depth)
        {
            if (depth > ans)
            {
                ans = depth;
            }
            if (root.children != null)
            {
                for (int i = 0; i < root.children.Count; i++)
                {
                    MaxDepth(root.children[i], depth + 1);
                }
            }

        }
    }
}
