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

            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(0);
            TreeNode n3 = new TreeNode(2);

            n1.left = n2;
            n1.right = n3;

            p.TrimBST(n1, 1, 1);
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


        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val > R)
            {
                //根节点值比右边界大 返回修剪后的左子树
                return TrimBST(root.left, L, R);
            }

            if (root.val < L)
            {
                //根节点值比左边界大 返回修剪后的右子树
                return TrimBST(root.right, L, R);
            }

            //否则两边都修剪
            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);
            return root;
        }

      
    }



}








