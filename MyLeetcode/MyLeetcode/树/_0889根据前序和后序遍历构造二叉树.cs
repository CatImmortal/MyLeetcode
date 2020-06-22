using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/

    class _0889根据前序和后序遍历构造二叉树
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
        /// 存储前序遍历数组的元素值与对应下标
        /// </summary>
        private Dictionary<int, int> preDict = new Dictionary<int, int>();

        /// <summary>
        /// 存储后序遍历数组的元素值与对应下标
        /// </summary>
        private Dictionary<int, int> postDict = new Dictionary<int, int>();

        public TreeNode ConstructFromPrePost(int[] pre, int[] post)
        {
            for (int i = 0; i < pre.Length; i++)
            {
                preDict.Add(pre[i], i);
            }

            for (int i = 0; i < post.Length; i++)
            {
                postDict.Add(post[i], i);
            }

            return ConstructFromPrePost(pre, post, 0, pre.Length - 1, 0, post.Length - 1);
        }

        public TreeNode ConstructFromPrePost(int[] pre, int[] post, int preL, int preR, int postL, int postR)
        {
            if (preL > preR || postL > postR)
            {
                return null;
            }

            //前序遍历左边界 就是当前子树的头节点
            TreeNode node = new TreeNode(pre[preL]);

            if (preL == preR || postL == postR)
            {
                return node;
            }

            int leftPreL = preL + 1;
            int leftTreeLenght = postDict[pre[leftPreL]] - postL;  //左子树长度
            int leftPreR = leftPreL + leftTreeLenght;

            int rightPreL = leftPreR + 1;
            int rightPreR = preR;

            int leftPostL = postL;
            int leftPostR = postL + leftTreeLenght;

            int rightPostL = leftPostR + 1;
            int rightPostR = postR - 1;


            node.left = ConstructFromPrePost(pre, post, leftPreL, leftPreR, leftPostL, leftPostR);
            node.right = ConstructFromPrePost(pre, post, rightPreL, rightPreR, rightPostL, rightPostR);

            return node;
        }
    }
}
