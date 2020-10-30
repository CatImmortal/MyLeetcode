using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/range-sum-of-bst/

    class _0938二叉搜索树的范围和
    {

        public int RangeSumBST(TreeNode root, int L, int R)
        {
            int result = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (root != null)
            {
                stack.Push(root);
            }


            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                if (node.val >= L && node.val <= R)
                {
                    result += node.val;
                }



                //pop root后先push right，再push left，以实现前序遍历

                if (node.right != null && node.val <= R)
                {
                    //当前节点的值比R小 才push right
                    stack.Push(node.right);
                }

                if (node.left != null && node.val >= L)
                {
                    //当前节点的值比L大 才push left
                    stack.Push(node.left);
                }

            }

            return result;


        }
    }
}
