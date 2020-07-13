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
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);

            n1.left = n2;
            n1.right = n3;

            n2.left = n4;
            n2.right = n5;

            int[] nums = { 3, 2, 1, 6, 0, 5 };
            TreeNode node = p.ConstructMaximumBinaryTree(nums);
            Console.WriteLine(666);
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

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            TreeNode root = ConstructMaximumBinaryTree(nums, 0, nums.Length - 1);
            return root;
        }

        private TreeNode ConstructMaximumBinaryTree(int[] nums, int leftIndex, int rightIndex)
        {
            if (leftIndex < 0 || rightIndex >= nums.Length || leftIndex > rightIndex)
            {
                return null;
            }

            if (leftIndex == rightIndex)
            {
                return new TreeNode(nums[leftIndex]);
            }

            //给定范围内的数组最大值的索引
            int maxIndex = leftIndex;
            for (int i = leftIndex; i <= rightIndex; i++)
            {
                if (nums[i] > nums[maxIndex])
                {
                    maxIndex = i;
                }
            }

            TreeNode root = new TreeNode(nums[maxIndex]);
            root.left = ConstructMaximumBinaryTree(nums, leftIndex, maxIndex - 1);
            root.right = ConstructMaximumBinaryTree(nums, maxIndex + 1, rightIndex);
            return root;
        }


    }



}








