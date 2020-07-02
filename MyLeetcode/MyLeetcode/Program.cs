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
            TreeNode n2 = new TreeNode(0);
            TreeNode n3 = new TreeNode(1);
            TreeNode n4 = new TreeNode(0);
            TreeNode n5 = new TreeNode(1);
            TreeNode n6 = new TreeNode(0);
            TreeNode n7 = new TreeNode(1);

            
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

        List<List<int>> ans = new List<List<int>>();
        List<int> list = new List<int>();
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            
        }

        private void PreOrder(TreeNode root,int sum)
        {

        }


    }



}








