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

        public Node Connect(Node root)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return root;
            }

            if (root.left != null && root.right != null)
            {
                root.left.next = root.right;
                root.right.next = GetNextNoNullChild(root);
            }

            if (root.left == null)
            {
                root.right.next = GetNextNoNullChild(root);
            }

            if (root.right == null)
            {
                root.left.next = GetNextNoNullChild(root);
            }

            //这里要注意：先递归右子树，否则右子树根节点next关系没建立好，左子树到右子树子节点无法正确挂载
            root.right = Connect(root.right);
            root.left = Connect(root.left);

            return root;
        }

     

        /// <summary>
        /// 一路向右找到有可作为next指向的子节点的根节点
        /// </summary>
        private Node GetNextNoNullChild(Node root)
        {
            while (root.next != null)
            {
                if (root.next.left != null)
                {
                    return root.next.left;
                }

                if (root.next.right != null)
                {
                    return root.next.right;
                }

                root = root.next;
            }

            return null;
        }


    }



}








