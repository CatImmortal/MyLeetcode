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

        private List<TreeNode> nodes = new List<TreeNode>();

        public void Flatten(TreeNode root)
        {
            //将前序遍历结果收集到nodes
            //同时断开节点间的连接
            PreOrder(root);

            //展开为单链表
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                nodes[i].right = nodes[i + 1];
            }
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            nodes.Add(root);

            PreOrder(root.left);
            PreOrder(root.right);

            root.left = null;
            root.right = null;
        }


    }


}








