using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

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


            n1.right = n2;

            n2.left = n3;
            n2.right = n5;

            p.IsCousins(n1, 5, 3);
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

        int min1 = int.MaxValue;
        int min2 = int.MaxValue;
        bool flag = false;

        public int FindSecondMinimumValue(TreeNode root)
        {
            PreOrder(root);
            if (! flag)
            {
                return -1;
            }
            return min2;
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            if (root.val < min1)
            {
                min1 = root.val;
            }
            else if (root.val > min1 && root.val <= min2)
            {
                min2 = root.val;
                flag = true;
            }

            PreOrder(root.left);
            PreOrder(root.right);
        }





    }



}








