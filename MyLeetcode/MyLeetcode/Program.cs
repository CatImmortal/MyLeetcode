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

            n1.left = n2;
            n1.right = n3;

            n2.left = n4;
            n3.left = n5;

            p.IsSymmetric(n1);

        }


        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                //没有根节点 对称
                return false;
            }

            if (root.left == null && root.right == null)
            {
                //只有根节点 对称
                return true;
            }

            if (root.left == null || root.right == null )
            {
                //根节点只有左子树或只有右子树 不对称
                return false;
            }



            return true;

        }


        public void Func(int num,Action callback)
        {
            for (int i = 0; i < num; i++)
            {
                callback();
            }
        }

        public void Func2<T>(IEnumerable<T> c, Action<T> callback)
        {
            foreach (var item in c)
            {
                callback(item);
            }
        }
    }



}








