﻿using System;
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

            TreeNode n1 = new TreeNode(5);
            TreeNode n2 = new TreeNode(4);
            TreeNode n3 = new TreeNode(7);
            TreeNode n4 = new TreeNode(3);
            TreeNode n5 = new TreeNode(2);
            TreeNode n6 = new TreeNode(-1);
            TreeNode n7 = new TreeNode(9);
        }


        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
 


        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
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

        public TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return root;
            }

            //中序遍历
            List<TreeNode> nodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode node = root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    //不断push left进去 一直push到头
                    stack.Push(node);
                    node = node.left;
                }

                if (stack.Count > 0)
                {
                    //push到头了 取一个出来操作 然后push一个right进去
                    node = stack.Pop();
                    nodes.Add(node);
                    node = node.right;
                }
            }

            for (int i = 0; i < nodes.Count - 1; i++)
            {
                nodes[i].left = null;
                nodes[i].right = nodes[i + 1];
            }

            return nodes[0];
        }
    }



}








