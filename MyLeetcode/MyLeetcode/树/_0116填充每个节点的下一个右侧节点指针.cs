using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node/

    class _0116填充每个节点的下一个右侧节点指针
    {

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public Node Connect(Node root)
        {
            Connect(root, null);
            return root;
        }

        private void Connect(Node root, Node brother)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return;
            }

            root.left.next = root.right;
            root.right.next = brother?.left;

            Connect(root.left, root.right);
            Connect(root.right, brother?.left);
        }
    }
}
