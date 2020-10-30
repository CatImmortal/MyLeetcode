using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/flip-binary-tree-to-match-preorder-traversal/

    class _0971翻转二叉树以匹配先序遍历
    {
        private int index = 0;
        private int[] voyage;
        private List<int> ans = new List<int>();
        public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {
            this.voyage = voyage;

            PreOrder(root);

            if (ans.Count > 0 && ans[0] == -1)
            {
                ans.Clear();
                ans.Add(-1);
            }

            return ans;
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            if (root.val != voyage[index])
            {
                //根节点不匹配voyage
                ans.Clear();
                ans.Add(-1);
                return;
            }

            index++;

            if (index < voyage.Length && root.left != null && root.left.val != voyage[index])
            {
                //左子节点不匹配 尝试翻转调用
                ans.Add(root.val);
                PreOrder(root.right);
                PreOrder(root.left);
            }
            else
            {
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }

        //-----------------------------

        public IList<int> FlipMatchVoyage2(TreeNode root, int[] voyage)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            int index = 0;
            List<int> ans = new List<int>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                if (node.val != voyage[index])
                {
                    //根节点不匹配
                    ans.Clear();
                    ans.Add(-1);
                    return ans;
                }

                index++;

                if (node.left != null && node.left.val != voyage[index])
                {
                    //左子节点不匹配 翻转

                    ans.Add(node.val);

                    stack.Push(node.left);

                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }
                }
                else
                {
                    if (node.right != null)
                    {
                        stack.Push(node.right);
                    }

                    if (node.left != null)
                    {
                        stack.Push(node.left);
                    }
                }

               
            }

            return ans;
        }
    }
}
