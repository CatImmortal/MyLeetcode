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
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(2);
            TreeNode n4= new TreeNode(2);
            TreeNode n5 = new TreeNode(2);


            int[] pre = { 2,1};
            int[] post = {1,2 };
            p.ConstructFromPrePost(pre, post);
        }


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

        public TreeNode ConstructFromPrePost(int[] pre, int[] post,int preL,int preR,int postL,int postR)
        {
            if (preL > preR || postL > postR)
            {
                return null;
            }

            //前序遍历左边界 就是当前子树的头节点
            TreeNode node = new TreeNode(pre[preL]);

            if (preL >= pre.Length - 1 || postR <= 0)
            {
                return node;
            }

            int leftPreL = preL + 1;  //左子树的pre左边界位置就是preL + 1 即左子树的根节点
            int rightPreR = preR;  //右子树的pre右边界位置就是preR 即pre数组最右侧

            int leftPostL = postL;  //左子树的post左边界位置就是postL 即post数组最左侧
            int rightPostR = postR - 1;  //右子树的post右边界位置就是preR - 1 即右子树的根节点

            int rightPreL = preDict[post[rightPostR]];  //右子树的pre左边界元素就是右子树的post右边界元素 即右子树的根节点
            int leftPreR = rightPreL - 1;  //左子树的pre右边界位置就是rightPreL - 1
            
            int leftPostR = postDict[pre[leftPreL]];  //左子树的post右边界元素就是左子树的pre左边界元素 即左子树的根节点
            int rightPostL = leftPostR + 1;  //右子树的post左边界位置就是左子树的leftPostR + 1
           

            node.left = ConstructFromPrePost(pre, post, leftPreL, leftPreR, leftPostL, leftPostR);
            node.right = ConstructFromPrePost(pre, post, rightPreL, rightPreR, rightPostL, rightPostR);

            return node;
        }

    }



}








