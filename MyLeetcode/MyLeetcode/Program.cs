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


        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {

            Stack<TreeNode> stack1 = new Stack<TreeNode>();

            if (root1 != null)
            {
                stack1.Push(root1);
            }


            while (stack1.Count != 0)
            {
                TreeNode node = stack1.Pop();
                result.Add(node.val);

                //pop root后先push right，再push left，以实现前序遍历

                if (node.right != null)
                {
                    stack1.Push(node.right);
                }

                if (node.left != null)
                {
                    stack1.Push(node.left);
                }



            }
        }


    }



}








