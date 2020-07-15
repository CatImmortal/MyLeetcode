using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/cousins-in-binary-tree/

    class _0993二叉树的堂兄弟节点
    {

        private Dictionary<int, int> depthDict = new Dictionary<int, int>();
        private Dictionary<int, TreeNode> parentDict = new Dictionary<int, TreeNode>();

        public bool IsCousins(TreeNode root, int x, int y)
        {
            PreOrder(root, null);

            return depthDict[x] == depthDict[y] && parentDict[x] != parentDict[y];
        }

        private void PreOrder(TreeNode root, TreeNode parent)
        {
            if (root == null)
            {
                return;
            }

            int depth = 0;
            if (parent != null)
            {
                depth = depthDict[parent.val] + 1;
            }
            depthDict.Add(root.val, depth);

            parentDict.Add(root.val, parent);

            PreOrder(root.left, root);
            PreOrder(root.right, root);
        }
    }
}
