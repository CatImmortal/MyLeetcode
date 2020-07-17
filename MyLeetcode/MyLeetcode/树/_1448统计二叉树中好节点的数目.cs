using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/count-good-nodes-in-binary-tree/

    class _1448统计二叉树中好节点的数目
    {
        private int ans = 0;

        public int GoodNodes(TreeNode root)
        {
            PreOrder(root, int.MinValue);
            return ans;
        }

        private void PreOrder(TreeNode root, int pathMaxNum)
        {
            if (root == null)
            {
                return;
            }

            //当前节点值>=当前路径最大值 
            //是好节点
            if (root.val >= pathMaxNum)
            {
                ans++;
                pathMaxNum = root.val;
            }


            PreOrder(root.left, pathMaxNum);
            PreOrder(root.right, pathMaxNum);
        }
    }
}
