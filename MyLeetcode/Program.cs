using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLeetcode.数组;
using MyLeetcode.栈;
using MyLeetcode.哈希表;
using MyLeetcode.动态规划;
using MyLeetcode.回溯算法;

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
            //_0079单词搜索 p = new _0079单词搜索();

            //char[][] param = new char[2][];
            //param[0] = new char[] { 'a','b'};
            //param[1] = new char[] {'c','d'};


            //p.Exist(param, "cdba");

            List<Program> list = new List<Program>(100);
            if (list[10] == null)
            {
                Console.WriteLine(666);
            }
        }





    }


}








