using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/convert-bst-to-greater-tree/

    class _0538把二叉搜索树转换为累加树
    {

        public TreeNode ConvertBST(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return root;
            }

            //按中序遍历的顺序将所有树节点收集到list中
            List<TreeNode> result = new List<TreeNode>();
            Inorder(root, result);

            for (int i = result.Count - 2; i >= 0; i--)
            {
                //计算节点值
                result[i].val += result[i + 1].val;
            }

            return root;
        }

        private void Inorder(TreeNode root, List<TreeNode> result)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.left, result);
            result.Add(root);
            Inorder(root.right, result);
        }

        int sum = 0;
        public TreeNode ConvertBST2(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            ConvertBST2(root.right);

            
            root.val += sum;
            sum = root.val;

            ConvertBST2(root.left);

            return root;    
        }
    }
}
