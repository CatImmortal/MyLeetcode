﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode
{
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

    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            TreeNode n1 = new TreeNode(3);
            TreeNode n2 = new TreeNode(1);
            TreeNode n3 = new TreeNode(4);

            TreeNode n4 = new TreeNode(2);
            //TreeNode n5 = new TreeNode(0);
            //TreeNode n6 = new TreeNode(3);

            n1.left = n2;
            n1.right = n3;

            n2.right = n4;


        }

        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }

            if (root1 == null || root2 == null)
            {
                return false;   
            }

            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            stack1.Push(root1);
            stack2.Push(root2);

            while (stack1.Count != 0)
            {
                TreeNode node1 = stack1.Pop();
                TreeNode node2 = stack2.Pop();

                if (node1.val != node2.val)
                {
                    return false;
                }

                if (IsEquals(node1.left,node2.left) && IsEquals(node1.right,node2.right))
                {
                    //子节点相同
                    if (node1.left != null)
                    {
                        stack1.Push(node1.left);
                        stack2.Push(node2.left);
                    }

                    if (node1.right != null)
                    {
                        stack1.Push(node1.right);
                        stack2.Push(node2.right);
                    }
                }
                else if (IsEquals(node1.left, node2.right) && IsEquals(node1.right, node2.left))
                {
                    //子节点镜像
                    if (node1.left != null)
                    {
                        stack1.Push(node1.left);
                        stack2.Push(node2.right);
                    }

                    if (node1.right != null)
                    {
                        stack1.Push(node1.right);
                        stack2.Push(node2.left);
                    }
                }
                else
                {
                    //子节点即不相同也不镜像 返回false
                    return false;
                }


            }


            return true;

        }

        /// <summary>
        /// 判断两个节点是否相同
        /// </summary>
        private bool IsEquals(TreeNode root1,TreeNode root2)
        {
           
            if (root1 == null && root2 == null)
            {
                return true;
            }

            if (root1 ==null || root2 == null)
            {
                return false;
            }

            return root1.val == root2.val;
        }


    }


}








