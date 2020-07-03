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
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);

            n1.left = n2;
            n1.right = n3;

            n2.left = n4;
            n2.right = n5;

            int sum = p.SumOfLeftLeaves(n1);
            Console.WriteLine(sum);
        }


        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }



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

        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            
            bool isBalanced = Math.Abs(GetHeight(root.left) - GetHeight(root.right)) <= 1;

            return isBalanced && IsBalanced(root.left) && IsBalanced(root.right);
        }

        /// <summary>
        /// 获取树高度
        /// </summary>
        private int GetHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);
            int height = Math.Max(leftHeight, rightHeight) + 1;

            return height;
        }

    }



}








