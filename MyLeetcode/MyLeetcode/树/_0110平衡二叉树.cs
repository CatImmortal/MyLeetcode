using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/balanced-binary-tree/

    class _0110平衡二叉树
    {

        private Dictionary<TreeNode, int> dict = new Dictionary<TreeNode, int>();

        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }


            bool isBalanced = Math.Abs(GetHeight(root.left) - GetHeight(root.right)) <= 1;

            return isBalanced && IsBalanced(root.left) && IsBalanced(root.right);
        }

        /// <summary>
        /// 获取树高度
        /// </summary>
        private int GetHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int height;
            if (!dict.TryGetValue(root,out height))
            {
                int leftHeight = GetHeight(root.left);
                int rightHeight = GetHeight(root.right);
                height = Math.Max(leftHeight, rightHeight) + 1;
                dict[root] = height;
            }


            return height;
        }

        //------------------------

        public bool IsBalanced2(TreeNode root)
        {
            return GetHeight2(root) >= 0;
        }

        private int GetHeight2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = GetHeight2(root.left);

            //左子树不平衡
            if (leftHeight == -1)
            {
                return -1;
            }

            int rightHeight = GetHeight2(root.right);

            //右子树不平衡
            if (rightHeight == -1)
            {
                return -1;
            }

            //自身不平衡
            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1;
            }

            //平衡 返回高度
            return Math.Max(leftHeight, rightHeight) + 1;
            
        }
    }
}
