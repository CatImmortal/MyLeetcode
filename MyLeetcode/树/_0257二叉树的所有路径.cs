using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/binary-tree-paths/

    class _0257二叉树的所有路径
    {

        List<string> ans = new List<string>();

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            Preorder(root, "");
            return ans;
        }

        private void Preorder(TreeNode root, string str)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                str += root.val;
                ans.Add(str);
                return;
            }

            str += root.val + "->";
            Preorder(root.left, str);
            Preorder(root.right, str);

        }
    }
}
