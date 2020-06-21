using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    class _0105从前序与中序遍历序列构造二叉树
    {
        //https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/

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

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                dict.Add(inorder[i], i);
            }


            return BuildTree(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);

        }

        private TreeNode BuildTree(int[] preorder, int[] inorder, int preL, int preR, int inL, int inR)
        {
            if (preL > preR || inL > inR)
            {
                return null;
            }

            //前序遍历结果的开头 是子树根节点
            TreeNode node = new TreeNode(preorder[preL]);

            //取出根节点在中序遍历结果中的对应索引
            int head = dict[preorder[preL]];
            //head - inL就是左子树长度
            node.left = BuildTree(preorder, inorder, preL + 1, preL + (head - inL), inL, head - 1);
            node.right = BuildTree(preorder, inorder, preL + (head - inL) + 1, preR, head + 1, inR);


            return node;
        }

    }
}
