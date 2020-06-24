using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode
{

    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(2);
            TreeNode n4 = new TreeNode(2);
            TreeNode n5 = new TreeNode(2);


        }


        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

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

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == p || root == q)
            {
                return root;
            }

            if (root != null)
            {
                TreeNode leftNode = LowestCommonAncestor(root.left, p, q);
                TreeNode rightNode = LowestCommonAncestor(root.right, p, q);

                if (leftNode != null || rightNode != null)
                {
                    return root;
                }

                if (leftNode != null)
                {
                    return leftNode;
                }

                if (rightNode != null)
                {
                    return rightNode;
                }
            }

            return null;
        }

    }



}








