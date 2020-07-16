using System;
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

            TreeNode n1 = new TreeNode(2);
            TreeNode n2 = new TreeNode(1);
            TreeNode n3 = new TreeNode(4);

            TreeNode n4 = new TreeNode(1);
            TreeNode n5 = new TreeNode(0);
            TreeNode n6 = new TreeNode(3);

            n1.left = n2;
            n1.right = n3;

            n4.left = n5;
            n4.right = n6;

            Console.WriteLine(666);
        }





    }

    public class FindElements
    {

        private TreeNode root;

        public FindElements(TreeNode root)
        {
            PreOrder(root, 0);

            this.root = root;   
        }

        private void PreOrder(TreeNode root,int rootVal)
        {
            if (root == null)
            {
                return;
            }

            root.val = rootVal;
            PreOrder(root.left, rootVal * 2 + 1);
            PreOrder(root.right, rootVal * 2 + 2);
        }

        public bool Find(int target)
        {
            return Find(root, target);
        }

        private bool Find(TreeNode root,int target)
        {
            if (root == null || root.val > target)
            {
                return false;
            }

            if (root.val == target)
            {
                return true;
            }

            return Find(root.left, target) || Find(root.right, target);
        }
    }

}








