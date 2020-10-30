using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/second-minimum-node-in-a-binary-tree/

    class _0671二叉树中第二小的节点
    {
        
        private int min2 = - 1;
        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null || root.left == null)
            {
                return -1;
            }

            int min1 = root.val;
            FindSecondMinimumValue(root, min1);
            return min2;
        }


        private void FindSecondMinimumValue(TreeNode root,int min1)
        {
            if (root == null)
            {
                return;
            }

            if (root.val > min1)
            {
                if (min2 == -1 || root.val < min2)
                {
                    min2 = root.val;
                }
            }

            FindSecondMinimumValue(root.left, min1);
            FindSecondMinimumValue(root.right, min1);
        }



    }
}
