using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/

    class _0106从中序与后序遍历序列构造二叉树
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        /// <summary>
        /// 存储中序遍历数组的元素值与对应下标
        /// </summary>
        private Dictionary<int, int> dict = new Dictionary<int, int>();

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                dict.Add(inorder[i], i);
            }


            return BuildTree(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);

        }

        private TreeNode BuildTree(int[] inorder, int[] postorder, int inL, int inR, int postL, int postR)
        {
            if (inL > inR || postL > postR)
            {
                return null;
            }

            //后序遍历数组的末尾 是子树根节点
            TreeNode node = new TreeNode(postorder[postR]);

            int rootIn = dict[postorder[postR]];  //根节点在中序遍历数组的位置

            int leftInL = inL;
            int leftInR = rootIn - 1;

            int rightInL = rootIn + 1;
            int rightInR = inR;

            int leftTreeLenght = leftInR - leftInL;  //左子树长度


            int leftPostL = postL;
            int leftPostR = postL + leftTreeLenght;

            int rightPostL = leftPostR + 1;
            int rightPostR = postR - 1;

            node.left = BuildTree(inorder, postorder,leftInL,leftInR,leftPostL,leftPostR);
            node.right = BuildTree(inorder, postorder, rightInL,rightInR,rightPostL,rightPostR);
            
            return node;
        }
    }
}
