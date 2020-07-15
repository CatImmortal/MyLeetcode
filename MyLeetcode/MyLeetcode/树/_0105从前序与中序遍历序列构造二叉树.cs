using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/

    class _0105从前序与中序遍历序列构造二叉树
    {

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


            int rootIn = dict[preorder[preL]];  //根节点在中序遍历数组的位置

            int leftInL = inL;
            int leftInR = rootIn - 1;

            int rightInL = rootIn + 1;
            int rightInR = inR;

            int leftTreeLenght = leftInR - leftInL;  //左子树长度

            int leftPreL = preL + 1;
            int leftPreR = leftPreL + leftTreeLenght;

            int rightPreL = leftPreR + 1;
            int rightPreR = preR;

            node.left = BuildTree(preorder, inorder, leftPreL,leftPreR,leftInL,leftInR);
            node.right = BuildTree(preorder, inorder, rightPreL,rightPreR,rightInL,rightInR);


            return node;
        }

    }
}
