using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/longest-zigzag-path-in-a-binary-tree/

    class _1372二叉树中的最长交错路径
    {
        private int ans = 0;

        public int LongestZigZag(TreeNode root)
        {
            PreOrder(root.left, true, 1);
            PreOrder(root.right, false, 1);
            return ans;
        }

        private void PreOrder(TreeNode root,bool isLeft,int length)
        {
            if (root == null)
            {
                return;
            }

            //根据当前路径长度更新ans
            ans = Math.Max(ans, length);

            if (isLeft)
            {
                //当前节点是父节点的左子节点
                PreOrder(root.left, true, 1);//搜索左子树 不满足zigzag 长度重置为1
                PreOrder(root.right, false, length + 1);//搜索右子树 满足zigzag 长度+1
            }
            else
            {
                //当前节点是父节点的右子节点
                PreOrder(root.left, true, length + 1);//搜索左子树 满足zigzag 长度+1
                PreOrder(root.right, false, 1);//搜索右子树 不满足zigzag 长度重置为1
            }
        }
    
    }
}
