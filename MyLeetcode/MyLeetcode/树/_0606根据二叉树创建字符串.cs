using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/construct-string-from-binary-tree/

    class _0606根据二叉树创建字符串
    {
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        StringBuilder sb = new StringBuilder();

        public string Tree2str(TreeNode t)
        {
            string result = PreOrder(t);
            return result;
        }

        private string PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return string.Empty;
            }

            string str1 = root.val.ToString();
            string str2 = PreOrder(root.left);
            string str3 = PreOrder(root.right);

            sb.Clear();
            sb.Append(str1);

            if (root.right != null)
            {
                //有右子节点的情况下 不管左子节点是否为null 都append上
                sb.Append($"({str2})");
                sb.Append($"({str3})");
            }
            else if (root.left != null)
            {
                //没有右子节点的情况下 只有左子节点不为null 才append
                sb.Append($"({str2})");
            }



            return sb.ToString();
        }
    }
}
