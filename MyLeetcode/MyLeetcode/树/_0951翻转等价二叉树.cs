using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/flip-equivalent-binary-trees/

    class _0951翻转等价二叉树
    {
        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }

            if (root1 == null || root2 == null)
            {
                return false;
            }

            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            stack1.Push(root1);
            stack2.Push(root2);

            while (stack1.Count != 0)
            {
                TreeNode node1 = stack1.Pop();
                TreeNode node2 = stack2.Pop();

                if (node1.val != node2.val)
                {
                    return false;
                }

                if (IsEquals(node1.left, node2.left) && IsEquals(node1.right, node2.right))
                {
                    //子节点相同
                    if (node1.left != null)
                    {
                        stack1.Push(node1.left);
                        stack2.Push(node2.left);
                    }

                    if (node1.right != null)
                    {
                        stack1.Push(node1.right);
                        stack2.Push(node2.right);
                    }
                }
                else if (IsEquals(node1.left, node2.right) && IsEquals(node1.right, node2.left))
                {
                    //子节点镜像
                    if (node1.left != null)
                    {
                        stack1.Push(node1.left);
                        stack2.Push(node2.right);
                    }

                    if (node1.right != null)
                    {
                        stack1.Push(node1.right);
                        stack2.Push(node2.left);
                    }
                }
                else
                {
                    //子节点即不相同也不镜像 返回false
                    return false;
                }


            }


            return true;

        }

        /// <summary>
        /// 判断两个节点是否相同
        /// </summary>
        private bool IsEquals(TreeNode root1, TreeNode root2)
        {

            if (root1 == null && root2 == null)
            {
                return true;
            }

            if (root1 == null || root2 == null)
            {
                return false;
            }

            return root1.val == root2.val;
        }

        public bool FlipEquiv2(TreeNode root1, TreeNode root2)
        {
            if (root1 == root2)
            {
                return true;
            }

            if (root1 == null || root2 == null || root1.val != root2.val)
            {
                return false;
            }

            //返回左右子树是否 相等或镜像
            return (FlipEquiv2(root1.left, root2.left) && FlipEquiv2(root1.right, root2.right)) 
                    || (FlipEquiv2(root1.left, root2.right) && FlipEquiv2(root1.right, root2.left));
        }
    }
}
