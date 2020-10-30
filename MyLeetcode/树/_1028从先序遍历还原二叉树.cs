using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/recover-a-tree-from-preorder-traversal/

    class _1028从先序遍历还原二叉树
    {
        private int curIndex = 0;
        private int curDepth = 0;

        public TreeNode RecoverFromPreorder(string S)
        {
            return PreOrder(0, S.ToCharArray());
        }

        private TreeNode PreOrder(int depth,char[] nodes)
        {
            int val = 0;

            //解析节点值
            while (curIndex < nodes.Length && nodes[curIndex] != '-')
            {
                val = val * 10 + (nodes[curIndex] - '0');

                curIndex++;
            }

            curDepth = 0;

            //解析右侧节点深度
            while (curIndex < nodes.Length && nodes[curIndex] == '-')
            {
                curIndex++;
                curDepth++;
            }

            TreeNode node = new TreeNode(val);
            if (curDepth > depth)
            {
                node.left = PreOrder(curDepth, nodes);
            }
            if (curDepth > depth)
            {
                node.right = PreOrder(curDepth, nodes);
            }

            return node;

        }


    }
}
