using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/leaf-similar-trees/

    class _0872叶子相似的树
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> result1 = PreorderTraversal(root1);
            List<int> result2 = PreorderTraversal(root2);
            if (result1.Count != result2.Count)
            {
                return false;
            }

            for (int i = 0; i < result1.Count; i++)
            {
                if (result1[i] != result2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public List<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Preorder(root, result);
            return result;
        }

        private void Preorder(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                result.Add(root.val);
            }

            Preorder(root.left, result);
            Preorder(root.right, result);
        }
    }
}
