using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/check-completeness-of-a-binary-tree/

    class _0958二叉树的完全性检验
    {
        public bool IsCompleteTree(TreeNode root)
        {
  
            Queue<TreeNode> queue = new Queue<TreeNode>();

            //前一个层次遍历到的节点
            TreeNode prev = root;

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                if (prev == null && node != null)
                {
                    //前一个为null 当前节点不为null 说明不连续
                    //返回false
                    return false;
                }

                if (node != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }

                prev = node;
               
            }


            return true;
        }

    }
}
