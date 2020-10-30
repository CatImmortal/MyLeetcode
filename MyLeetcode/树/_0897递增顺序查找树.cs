using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetcode.树
{
    //https://leetcode-cn.com/problems/increasing-order-search-tree/

    class _0897递增顺序查找树
    {

        public TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return root;
            }

            //中序遍历
            List<TreeNode> nodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode node = root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    //不断push left进去 一直push到头
                    stack.Push(node);
                    node = node.left;
                }

                if (stack.Count > 0)
                {
                    //push到头了 取一个出来操作 然后push一个right进去
                    node = stack.Pop();
                    nodes.Add(node);
                    node = node.right;
                }
            }

            for (int i = 0; i < nodes.Count - 1; i++)
            {
                nodes[i].left = null;
                nodes[i].right = nodes[i + 1];
            }

            return nodes[0];
        }


        public TreeNode IncreasingBST2(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return root;
            }

            TreeNode dummyRoot = new TreeNode(0);
            TreeNode parent = dummyRoot;

            //中序遍历
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode node = root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    //不断push left进去 一直push到头
                    stack.Push(node);
                    node = node.left;
                }

                if (stack.Count > 0)
                {
                    //push到头了 取一个出来操作 然后push一个right进去
                    node = stack.Pop();
                    
                    //置空左子节点 然后成为parent的右子节点
                    //最后转移parent
                    node.left = null;
                    parent.right = node;
                    parent = node;
                    
                    node = node.right;
                }
            }

            return dummyRoot.right;
        }


    }
}
