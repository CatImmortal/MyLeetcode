using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-tilt/

    class _0563二叉树的坡度
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        

        public int FindTilt(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            //获取左子树坡度
            int leftChildTilt = FindTilt(root.left);

            //获取右子树坡度
            int rightChildTilt = FindTilt(root.right);

            //获取根节点坡度
            int rootTilt = Math.Abs(GetValSum(root.left) - GetValSum(root.right));

            //加起来得到整棵树的坡度
            return leftChildTilt + rightChildTilt + rootTilt;
        }

        //获取树的结点和
        private int GetValSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftValSum = GetValSum(root.left);
            int rightValSum = GetValSum(root.right);
            return leftValSum + rightValSum + root.val;
        }




        private int tilt = 0;

        public int FindTilt2(TreeNode root)
        {
            PostOrder(root);
            return tilt;
        }

        /// <summary>
        /// 后序遍历 计算每个结点的结点和同时计算坡度
        /// </summary>
        private int PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = PostOrder(root.left);
            int right = PostOrder(root.right);

            //计算坡度 然后累加起来
            int tilt = Math.Abs(left - right);
            this.tilt += tilt;

            return left + right + root.val;

        }


    }
}
