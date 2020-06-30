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
            TreeNode n3 = new TreeNode(1);
            TreeNode n4 = new TreeNode(0);
            TreeNode n5 = new TreeNode(1);
            TreeNode n6 = new TreeNode(0);
            TreeNode n7 = new TreeNode(1);

            n1.left = n2;
            n1.right = n3;

            n2.left = n4;
            n2.right = n5;

            n3.left = n6;
            n3.right = n7;

            p.SumRootToLeaf(n1);
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



        public int SumRootToLeaf(TreeNode root)
        {
            List<string> result = BinaryTreePaths(root);
            int sum = 0;
            for (int i = 0; i < result.Count; i++)
            {
                sum += BinaryStr2Int(result[i]);
            }
            return sum;
        }

        public List<string> BinaryTreePaths(TreeNode root)
        {
            List<string> result = new List<string>();
            Preorder(root, "",result);
            return result;
        }

        private void Preorder(TreeNode root, string str, List<string> result)
        {
            if (root == null)
            {
                return;
            }

            str += root.val;

            if (root.left == null && root.right == null)
            {
                result.Add(str);
                return;
            }


            Preorder(root.left, str, result);
            Preorder(root.right, str, result);

        }


        private int BinaryStr2Int(string str)
        {
            int sum = 0;
            int pow = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == '1')
                {
                    sum += (int)Math.Pow(2, pow);
                }

                pow++;
            }

            return sum;
        }


    }



}








