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
using MyLeetcode.二分查找;
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
            _0033搜索旋转排序数组 p = new _0033搜索旋转排序数组();
            int[] nums = {4,5,6,7,0,1,2 };
            p.Search(nums,0);

        }





    }


}








