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

        //key-子树元素和 value-出现次数
        private Dictionary<int, int> dict = new Dictionary<int, int>();

        public int[] FindFrequentTreeSum(TreeNode root)
        {
            PostOrder(root);

            List<int> list = new List<int>();

            //当前出现最多次数的子树元素和的出现次数
            int maxCount = 0;

            foreach (KeyValuePair<int, int> item in dict)
            {
                if (item.Value == maxCount)
                {
                    list.Add(item.Key);
                }
                else if (item.Value > maxCount)
                {
                    maxCount = item.Value;
                    list.Clear();
                    list.Add(item.Key);
                }
            }

            return list.ToArray();
        }

        private int PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = PostOrder(root.left);
            int right = PostOrder(root.right);
            root.val += left + right;

            if (!dict.ContainsKey(root.val))
            {
                dict.Add(root.val, 1);
            }
            else
            {
                dict[root.val] += 1;
            }

            return root.val;
        }


    }


}








